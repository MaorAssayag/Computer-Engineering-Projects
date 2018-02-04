using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

//*****//
// '>' is the recognized sign for the End of DATA in a current communictaion //
//*****//

namespace Terminal
{
    public partial class LightTerminal : Form
    {
        #region Fields
        //--------------------------------------------//

        System.IO.Ports.SerialPort port;
        byte[] SendBytes;
        //default parameters;
        string portName;
        int baudRate = 9600;
        int WordLength = 8;
        Parity actualParity = Parity.None;
        StopBits actualStopBit = StopBits.One;
        //for send parameters
        int paritySend;
        int StopBit;
        bool PcParaChange = false;
        bool ControllerParaChange = false;

        //--------------------------------------------//
        #endregion

        #region Initialization
        //--------------------------------------------//

        public LightTerminal()
        {
            InitializeComponent();
            TopMessageBox.Text = "> First choose PORT connection !\n";
        }

        //--------------------------------------------//
        #endregion

        #region Port methodes
        //--------------------------------------------//

        private void openPort() // open port by parameters
        {
            port.BaudRate = baudRate;
            port.Parity = actualParity;
            port.StopBits = actualStopBit;
            port.DataBits = WordLength;
            port.Open();
            port.DtrEnable = true;
            port.RtsEnable = true;
            try
            {
                PcParaChange = true;//the parameters change in the computer
                if (PcParaChange && ControllerParaChange) { openCommunication(); } // only than apply communication
            }
            catch
            {
                TopMessageBox.AppendText("Something didn't work, Please check your connection !\n");
            }
        }
        private void openCommunication()
        {
            TopMessageBox.Text = "> Connected to " + portName;
            ConnectButton.Enabled = false;
            DissconnectButton.Enabled = true;
            BaudrateBox.Enabled = true;//baud rate
            DatabitBox.Enabled = true;//BFS
            StopbitBox.Enabled = true;//stop bit
            ParityBox.Enabled = true;//pairty box
            CommandBox.Enabled = true; //otherwise you cant write commands
            CommandPanelButton.Enabled = true;//you can inter the command 
            SendPanelButton.Enabled = true; // files enabled
            RecievePanelButton.Enabled = true;
            StatusLabel.Text = "Connected";
            StatusLabel.BackColor = Color.LightGreen;
            PcParaChange = false;
            ControllerParaChange = false;
            SendPara.Enabled = false;
            ChangePara.Enabled = false;
            ReadParametersButton.Enabled = true;
        }
        private void closePort()
        {
            if (port != null && port.IsOpen)
            {
                port.DiscardInBuffer();
                port.Dispose();
                port.Close(); // close the port
            }
            StatusLabel.Text = "Disconnected";
            StatusLabel.BackColor = Color.IndianRed;
            DissconnectButton.Enabled = false;
            BaudrateBox.Enabled = false;//baud rate
            DatabitBox.Enabled = false;//BFS
            StopbitBox.Enabled = false;//stop bit
            ParityBox.Enabled = false;//pairty box
            CommandPanelButton.Enabled = false;//you can inter the command 
            SendPanelButton.Enabled = false; // files enabled
            RecievePanelButton.Enabled = false;
            SendPara.Enabled = false;
            if (ControllerParaChange != true)
            { ConnectButton.Enabled = true; }
        }

        //--------------------------------------------//
        #endregion

        #region DataReceived
        //--------------------------------------------//

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort currentPort = (SerialPort) sender;
            Thread.Sleep(200);
            try
            {
                String sign = currentPort.ReadLine();
                switch (sign)
                {
                    case "a": //port parmeters changed 
                        currentPort.DiscardInBuffer();// discard current data, if exsist
                        TopMessageBox.AppendText("Controller Parameters changed !");
                        closePort(); //close the port
                        ChangePara.Enabled = true; // enabled change in pc parametrs
                        SendPara.Enabled = false;
                        ControllerParaChange = true;// the controller has change his parameters
                        break;

                    case "l": //recieve list of files
                        FileListBox.BeginInvoke(new EventHandler(delegate { FileListBox.Items.Clear(); }));
                        string list = currentPort.ReadLine();
                        if (list == " ") { FileListBox.Items.Add("No files"); }
                        else
                        {
                            while (list != ">") // ='>'.
                            {
                                FileListBox.BeginInvoke(new EventHandler(delegate { FileListBox.Items.Add(list.ToString()); }));
                                Thread.Sleep(150);
                                list = currentPort.ReadLine();
                            }
                        }
                        break;

                    case "U": // Recieve controler port parameters - optional
                        string parameters = "Baud rate : " + currentPort.ReadLine() + " BPS, "
                                          + currentPort.ReadLine() + " Data bits,";
                        parameters += " 1 Start," + StopBit.ToString() + " Stop bit,";
                        currentPort.ReadLine();
                        parameters += currentPort.ReadLine() + " Parity";
                        sign = currentPort.ReadLine(); // for the final signal '>'
                        TopMessageBox.AppendText(parameters);
                        break;

                    case "S": // Recieve file
                        string current = currentPort.ReadExisting();
                        current = current.Substring(0, current.Length - 3);// dont save the last char '>' and 0x1A
                        string path = PathBox.Text;
                        string namefile = FileName.Text + ".txt";
                        int Duplicate = 0;
                        try
                        {
                            while (File.Exists(Path.Combine(path, namefile)))
                            {
                                Duplicate++;
                                namefile = FileName.Text + Duplicate.ToString() + ".txt";
                            }

                            using (FileStream fileToSave = File.Create(Path.Combine(path, namefile)))
                            {
                                Byte[] data = new UTF8Encoding(true).GetBytes(current);
                                fileToSave.Write(data, 0, data.Length);
                            }
                            TopMessageBox.AppendText("File saved !");
                        }
                        catch { TopMessageBox.AppendText("Error oucerd !"); }
                        break;

                    case "D":
                        TopMessageBox.AppendText("File saved in the controller ! \n");
                        currentPort.ReadLine();
                        break;

                    default:  // discard current data, if exsist
                        currentPort.ReadExisting();
                        break;
                }
            }
            catch { port.DiscardInBuffer(); }
        }

        //--------------------------------------------//
        #endregion

        #region UserInterface 
        //--------------------------------------------//

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (PortBox.Text == "Choose PORT")
            {
                TopMessageBox.AppendText("Please choose a port !");
            }
            else
            {
                port = new System.IO.Ports.SerialPort(portName, baudRate, actualParity, WordLength, actualStopBit);
                port.ReadTimeout = 2000;
                port.ReceivedBytesThreshold = 1500;
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                openCommunication();
            }
        }

        private void PortBox_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            PortBox.Items.Clear();
            for (int i = 0; i< ports.Length; i++) // Display each port name to the console. 
            {
                PortBox.Items.Add((string)ports[i]);
            }
        }

        private void ChangePara_Click(object sender, EventArgs e)
        {
           closePort();
           openPort();
           TopMessageBox.AppendText("Connected with new parameters !\n");
        }

        private void ReadParametersButton_Click(object sender, EventArgs e)
        {
            //print the parameters
            TopMessageBox.Clear();
            TopMessageBox.AppendText("Baud rate : " + baudRate.ToString() + " BPS, " + WordLength.ToString() + " Data bits," +
             "1 Start," + StopBit.ToString() + " Stop bit," + actualParity.ToString() + " Parity");
        }

        private void DissconnectButton_Click(object sender, EventArgs e)
        {
            closePort();
        }

        private void CommandBox_KeyUp(object sender, KeyEventArgs userKey)
        {
            if (userKey.KeyCode == Keys.Return) // Enter key
            {
                switch (CommandBox.Lines[CommandBox.Lines.Length - 2])// the last line(with indes [Length-1]) will be empty (the user press enter)
                {   
                    case "set red":
                        port.Write("1");
                        port.Write(">");
                        break;
                    case "set blue":
                        port.Write("2");
                        port.Write(">");
                        break;
                    case "set yellow":
                        port.Write("3");
                        port.Write(">");
                        break;
                    case "set green":
                        port.Write("4");
                        port.Write(">");
                        break;
                    case "set purpule":
                        port.Write("5");
                        port.Write(">");
                        break;
                    case "set white":
                        port.Write("6");
                        port.Write(">");
                        break;
                    case "set azule":
                        port.Write("7");
                        port.Write(">");
                        break;
                    case "clear rgb":
                        port.Write("C");
                        port.Write(">");
                        break;
                    case "reset":
                        port.Write("R");
                        port.Write(">");
                        break;
                    default: // else
                        TopMessageBox.Clear();
                        TopMessageBox.AppendText(" Valid Command's :  ");
                        TopMessageBox.AppendText(" 1. set red - Turn on red led ");
                        TopMessageBox.AppendText(" 2. set blue - Turn on blue led ");
                        TopMessageBox.AppendText(" 3. set yellow - Turn on yellow led ");
                        TopMessageBox.AppendText(" 4. set green - Turn on green led ");
                        TopMessageBox.AppendText(" 5. set azule - Turn on azule led ");
                        TopMessageBox.AppendText(" 6. set white - Turn on white led ");
                        TopMessageBox.AppendText(" 7. set purple - Turn on purple led ");
                        TopMessageBox.AppendText(" 8. clear rgb - Turn off rgb led ");
                        TopMessageBox.AppendText(" 9. reset - To reset the controller ");
                        TopMessageBox.AppendText(" 10. in Script only : delay X miliseconds ");
                        break;
                }
            }
        }

        private void SendfileButton_Click(object sender, EventArgs e)
        {
            if(FileNameBox.Text== "File Name")
            {
                TopMessageBox.AppendText("Please choose a file !");
                return;
            }
            port.Write("A");
            // using statement is for ensure that even if an exception occurs the code will be execute
            using (FileStream file = new FileStream(FileNameBox.Text, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryReader binary = new BinaryReader(file);
                SendBytes = new byte[4];
                byte[] size = BitConverter.GetBytes((int)file.Length);
                SendBytes[0] = size[0];
                SendBytes[1] = size[1];
                SendBytes[2] = size[2];
                SendBytes[3] = size[3];
                port.Write(SendBytes, 0, 4); //send the number of bytes (size) of the file
                port.Write(Path.GetFileName(FileNameBox.Text) + "\n");//send the name of the file
                port.Write(binary.ReadBytes((int)file.Length), 0, (int)file.Length);//send the data of the file
            }
            port.Write(">");
            TopMessageBox.AppendText("File sent !");
        }

        private void RecieveButton_Click(object sender, EventArgs e)
        {
            if (FileListBox.SelectedItem.ToString()=="No files")
            {
                TopMessageBox.AppendText("Please refresh the list and choose a file !");
            }
            else if (Directory.Exists(PathBox.Text))
            {
                port.Write("9"); // ask for this file
                port.Write(FileListBox.SelectedItem.ToString()); // send "filename.txt"
                port.Write(">");
            }
           else
            {
                TopMessageBox.AppendText("Please choose a valid directory !");
            }
        }

        private void ChoosefileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog window = new OpenFileDialog())
            {
                window.Filter = "Text Files (*.txt)|*.txt";
                if (window.ShowDialog() == DialogResult.OK)
                {
                    FileNameBox.Text = window.FileName; // show the file name
                }
            }
            SendfileButton.Enabled = true; // you can send the file
        }

        private void SaveInButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog window = new FolderBrowserDialog())
            {
                if (window.ShowDialog() == DialogResult.OK)
                {
                    PathBox.Text = window.SelectedPath;
                }
            }
            RecieveButton.Enabled = true;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            port.Write("8"); // ask for the list of files names
            port.Write(">");
        }

        private void TopMessageBox_TextChanged(object sender, EventArgs e)
        {
            TopMessageBox.AppendText("\r\n");
            TopMessageBox.ScrollToCaret();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendPara.Enabled = true;
            PcParaChange = false;
            ControllerParaChange = false;
        }

        private void CommandPanelButton_Click(object sender, EventArgs e)
        {
            CommandPanel.Visible = true; // command page
            ParametersPanel.Visible = false;
            SendfilePanel.Visible = false;
            RecieveFilePanel.Visible = false;
            InfoPanel.Visible = false;
            CommandBox.Enabled = true;
        }

        private void InfoButton_Click_1(object sender, EventArgs e)
        {
            InfoPanel.Visible = true; // info page
            ParametersPanel.Visible = false;
            CommandPanel.Visible = false;
            SendfilePanel.Visible = false;
            RecieveFilePanel.Visible = false;
        }

        private void ParametersPanelButton_Click(object sender, EventArgs e)//parameter button
        {
            ParametersPanel.Visible = true; //parameter page
            CommandPanel.Visible = false;
            SendfilePanel.Visible = false;
            RecieveFilePanel.Visible = false;
            InfoPanel.Visible = false;
        }

        private void PortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            portName = PortBox.Text;
        }

        private void SendPanelButton_Click(object sender, EventArgs e)//files button
        {
            SendfilePanel.Visible = true; // send files
            ParametersPanel.Visible = false;
            CommandPanel.Visible = false;
            RecieveFilePanel.Visible = false;
            InfoPanel.Visible = false;
        }

        private void RecievePanelButton_Click(object sender, EventArgs e)//info button
        {
            RecieveFilePanel.Visible = true; // recevie file
            ParametersPanel.Visible = false;
            CommandPanel.Visible = false;
            SendfilePanel.Visible = false;
            InfoPanel.Visible = false;
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {  this.Close();  }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {  this.WindowState = FormWindowState.Minimized;  }

        // mouse can move the form
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 300 ;
                mouseY = MousePosition.Y - 4;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        { mouseDown = false;  }

        private void SendPara_Click(object sender, EventArgs e)
        {
            SendBytes = new byte[8];
            // Starting sign - 'B'
            SendBytes[0] = BitConverter.GetBytes('B')[0];
            //Baud Rate
            byte[] temp = BitConverter.GetBytes(baudRate);
            SendBytes[1] = temp[0];
            SendBytes[2] = temp[1];
            SendBytes[3] = temp[2];
            SendBytes[4] = temp[3];
            //WordLength
            SendBytes[5] = BitConverter.GetBytes(8- WordLength)[0]; // 0,1,2,3 for 8,7,6,5 data bit
            //Stop Bit       
            SendBytes[6] = BitConverter.GetBytes(StopBit)[0];
            //Pairty Bit
            SendBytes[7] = BitConverter.GetBytes(paritySend)[0];
            port.Write(SendBytes, 0, 8);
            port.Write(">");
            TopMessageBox.AppendText("Parameters has been sent !");
        }

        private void BaudrateBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (baudRate != Int32.Parse(BaudrateBox.Text))
            {
                baudRate = Int32.Parse(BaudrateBox.Text);
                SendPara.Enabled = true;
                PcParaChange = false;
                ControllerParaChange = false;
            }
        }

        private void DatabitBox_SelectedValueChanged(object sender, EventArgs e)
        {   
            if (WordLength != int.Parse(DatabitBox.SelectedItem.ToString()))
            {
                WordLength = int.Parse(DatabitBox.SelectedItem.ToString());
                SendPara.Enabled = true;
                PcParaChange = false;
                ControllerParaChange = false;
            }
        }

        private void StopbitBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (StopBit != int.Parse(StopbitBox.SelectedItem.ToString()))
            {
                StopBit = int.Parse(StopbitBox.SelectedItem.ToString());
                switch (StopbitBox.SelectedItem.ToString())
                {
                    case "1":
                        actualStopBit = StopBits.One;
                        break;
                    case "2":
                        actualStopBit = StopBits.Two;
                        break;
                }
                SendPara.Enabled = true;
                PcParaChange = false;
                ControllerParaChange = false;
            }
        }

        private void ParityBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (paritySend != ParityBox.SelectedIndex)
            {
                String parity = ParityBox.SelectedItem.ToString();
                switch (parity)
                {
                    case "None":
                        actualParity = Parity.None;
                        paritySend = 0;
                        break;
                    case "Even":
                        actualParity = Parity.Even;
                        paritySend = 1;
                        break;
                    case "Odd":
                        actualParity = Parity.Odd;
                        paritySend = 2;
                        break;
                }
                SendPara.Enabled = true;
                PcParaChange = false;
                ControllerParaChange = false;
            }
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {  mouseDown = true; }

        //--------------------------------------------//
        #endregion
    }
}