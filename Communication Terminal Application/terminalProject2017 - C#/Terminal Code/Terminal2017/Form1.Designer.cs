namespace Terminal
{
    partial class LightTerminal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightTerminal));
            this.TopMessageBox = new System.Windows.Forms.RichTextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.PortBox = new System.Windows.Forms.ComboBox();
            this.BaudrateBox = new System.Windows.Forms.ComboBox();
            this.CommandBox = new System.Windows.Forms.RichTextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.SaveInButton = new System.Windows.Forms.Button();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.ChoosefileButton = new System.Windows.Forms.Button();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.ReadParametersButton = new System.Windows.Forms.Button();
            this.ChangePara = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.TextBox();
            this.DissconnectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InfoButton = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ParametersPanelButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CommandPanelButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.RecievePanelButton = new System.Windows.Forms.Button();
            this.SendPanelButton = new System.Windows.Forms.Button();
            this.ParametersPanel = new System.Windows.Forms.Panel();
            this.SendPara = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ParityBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StopbitBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DatabitBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SendfilePanel = new System.Windows.Forms.Panel();
            this.SendfileButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RecieveFilePanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RecieveButton = new System.Windows.Forms.Button();
            this.MessaePanel = new System.Windows.Forms.Panel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CommandPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoButton)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.ParametersPanel.SuspendLayout();
            this.SendfilePanel.SuspendLayout();
            this.RecieveFilePanel.SuspendLayout();
            this.MessaePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.CommandPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // TopMessageBox
            // 
            this.TopMessageBox.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.TopMessageBox.AutoWordSelection = true;
            this.TopMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.TopMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TopMessageBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.TopMessageBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopMessageBox.ForeColor = System.Drawing.Color.Ivory;
            this.TopMessageBox.Location = new System.Drawing.Point(30, 15);
            this.TopMessageBox.Name = "TopMessageBox";
            this.TopMessageBox.ReadOnly = true;
            this.TopMessageBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TopMessageBox.Size = new System.Drawing.Size(464, 154);
            this.TopMessageBox.TabIndex = 0;
            this.TopMessageBox.TabStop = false;
            this.TopMessageBox.Text = " > Please connect ";
            this.TopMessageBox.TextChanged += new System.EventHandler(this.TopMessageBox_TextChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(203, 39);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(113, 31);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // PortBox
            // 
            this.PortBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PortBox.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortBox.FormattingEnabled = true;
            this.PortBox.ItemHeight = 23;
            this.PortBox.Location = new System.Drawing.Point(26, 39);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(154, 31);
            this.PortBox.TabIndex = 3;
            this.PortBox.Text = "Choose PORT";
            this.PortBox.DropDown += new System.EventHandler(this.PortBox_DropDown);
            this.PortBox.SelectedIndexChanged += new System.EventHandler(this.PortBox_SelectedIndexChanged);
            // 
            // BaudrateBox
            // 
            this.BaudrateBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BaudrateBox.Enabled = false;
            this.BaudrateBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudrateBox.FormattingEnabled = true;
            this.BaudrateBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.BaudrateBox.Location = new System.Drawing.Point(27, 93);
            this.BaudrateBox.Name = "BaudrateBox";
            this.BaudrateBox.Size = new System.Drawing.Size(154, 33);
            this.BaudrateBox.TabIndex = 9;
            this.BaudrateBox.Text = "9600";
            this.BaudrateBox.SelectedIndexChanged += new System.EventHandler(this.BaudrateBox_SelectedValueChanged);
            this.BaudrateBox.SelectedValueChanged += new System.EventHandler(this.BaudrateBox_SelectedValueChanged);
            // 
            // CommandBox
            // 
            this.CommandBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.CommandBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandBox.Enabled = false;
            this.CommandBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandBox.ForeColor = System.Drawing.Color.White;
            this.CommandBox.Location = new System.Drawing.Point(27, 42);
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.Size = new System.Drawing.Size(619, 303);
            this.CommandBox.TabIndex = 0;
            this.CommandBox.Text = "";
            this.CommandBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommandBox_KeyUp);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(291, 165);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(95, 43);
            this.RefreshButton.TabIndex = 8;
            this.RefreshButton.Text = "Refresh\r\n";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // FileListBox
            // 
            this.FileListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileListBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 25;
            this.FileListBox.Items.AddRange(new object[] {
            "No files"});
            this.FileListBox.Location = new System.Drawing.Point(30, 163);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(246, 152);
            this.FileListBox.TabIndex = 7;
            // 
            // SaveInButton
            // 
            this.SaveInButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveInButton.FlatAppearance.BorderSize = 0;
            this.SaveInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.SaveInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveInButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveInButton.Location = new System.Drawing.Point(14, 56);
            this.SaveInButton.Name = "SaveInButton";
            this.SaveInButton.Size = new System.Drawing.Size(138, 33);
            this.SaveInButton.TabIndex = 5;
            this.SaveInButton.Text = "Save in..";
            this.SaveInButton.UseVisualStyleBackColor = false;
            this.SaveInButton.Click += new System.EventHandler(this.SaveInButton_Click);
            // 
            // PathBox
            // 
            this.PathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathBox.Cursor = System.Windows.Forms.Cursors.No;
            this.PathBox.Enabled = false;
            this.PathBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathBox.Location = new System.Drawing.Point(30, 93);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(544, 33);
            this.PathBox.TabIndex = 3;
            this.PathBox.Text = "Folder directory";
            this.PathBox.Click += new System.EventHandler(this.SaveInButton_Click);
            // 
            // ChoosefileButton
            // 
            this.ChoosefileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChoosefileButton.FlatAppearance.BorderSize = 0;
            this.ChoosefileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.ChoosefileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoosefileButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoosefileButton.Location = new System.Drawing.Point(14, 58);
            this.ChoosefileButton.Name = "ChoosefileButton";
            this.ChoosefileButton.Size = new System.Drawing.Size(182, 33);
            this.ChoosefileButton.TabIndex = 4;
            this.ChoosefileButton.Text = "Choose file..";
            this.ChoosefileButton.UseVisualStyleBackColor = true;
            this.ChoosefileButton.Click += new System.EventHandler(this.ChoosefileButton_Click);
            // 
            // FileNameBox
            // 
            this.FileNameBox.Cursor = System.Windows.Forms.Cursors.No;
            this.FileNameBox.Enabled = false;
            this.FileNameBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameBox.ForeColor = System.Drawing.Color.Black;
            this.FileNameBox.Location = new System.Drawing.Point(30, 98);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(544, 33);
            this.FileNameBox.TabIndex = 2;
            this.FileNameBox.Text = "File Name";
            // 
            // ReadParametersButton
            // 
            this.ReadParametersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReadParametersButton.FlatAppearance.BorderSize = 0;
            this.ReadParametersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.ReadParametersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadParametersButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadParametersButton.Location = new System.Drawing.Point(421, 10);
            this.ReadParametersButton.Name = "ReadParametersButton";
            this.ReadParametersButton.Size = new System.Drawing.Size(196, 36);
            this.ReadParametersButton.TabIndex = 7;
            this.ReadParametersButton.Text = "Read parameters";
            this.ReadParametersButton.UseVisualStyleBackColor = true;
            this.ReadParametersButton.Click += new System.EventHandler(this.ReadParametersButton_Click);
            // 
            // ChangePara
            // 
            this.ChangePara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangePara.Enabled = false;
            this.ChangePara.FlatAppearance.BorderSize = 0;
            this.ChangePara.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.ChangePara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangePara.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePara.Location = new System.Drawing.Point(421, 241);
            this.ChangePara.Name = "ChangePara";
            this.ChangePara.Size = new System.Drawing.Size(169, 75);
            this.ChangePara.TabIndex = 14;
            this.ChangePara.Text = "Change parameter\'s";
            this.ChangePara.UseVisualStyleBackColor = true;
            this.ChangePara.Click += new System.EventHandler(this.ChangePara_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.IndianRed;
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.StatusLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(457, 42);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(142, 26);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Disconnected";
            // 
            // DissconnectButton
            // 
            this.DissconnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DissconnectButton.Enabled = false;
            this.DissconnectButton.FlatAppearance.BorderSize = 0;
            this.DissconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.DissconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DissconnectButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DissconnectButton.Location = new System.Drawing.Point(314, 37);
            this.DissconnectButton.Name = "DissconnectButton";
            this.DissconnectButton.Size = new System.Drawing.Size(137, 36);
            this.DissconnectButton.TabIndex = 4;
            this.DissconnectButton.Text = "Disconnect";
            this.DissconnectButton.UseVisualStyleBackColor = true;
            this.DissconnectButton.Click += new System.EventHandler(this.DissconnectButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.InfoButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 516);
            this.panel1.TabIndex = 17;
            this.panel1.Tag = "";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(227, 50);
            this.pictureBox7.TabIndex = 20;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseDown);
            this.pictureBox7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseMove);
            this.pictureBox7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(59, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 44);
            this.label3.TabIndex = 19;
            this.label3.Text = "Terminal";
            // 
            // InfoButton
            // 
            this.InfoButton.BackColor = System.Drawing.Color.Transparent;
            this.InfoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InfoButton.Image = global::Terminal2017.Properties.Resources.light_bulb;
            this.InfoButton.Location = new System.Drawing.Point(4, 49);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(64, 64);
            this.InfoButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InfoButton.TabIndex = 18;
            this.InfoButton.TabStop = false;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Light";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.ParametersPanelButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 350);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.pictureBox5);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(66, 345);
            this.panel6.TabIndex = 18;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Image = global::Terminal2017.Properties.Resources.inbox__1_;
            this.pictureBox5.Location = new System.Drawing.Point(1, 284);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 42);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Terminal2017.Properties.Resources.parameters;
            this.pictureBox2.Location = new System.Drawing.Point(2, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Terminal2017.Properties.Resources.command;
            this.pictureBox4.Location = new System.Drawing.Point(3, 115);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Image = global::Terminal2017.Properties.Resources.mail;
            this.pictureBox3.Location = new System.Drawing.Point(-3, 199);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(66, 53);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // ParametersPanelButton
            // 
            this.ParametersPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ParametersPanelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.ParametersPanelButton.FlatAppearance.BorderSize = 5;
            this.ParametersPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ParametersPanelButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersPanelButton.ForeColor = System.Drawing.Color.White;
            this.ParametersPanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ParametersPanelButton.Location = new System.Drawing.Point(57, -3);
            this.ParametersPanelButton.Name = "ParametersPanelButton";
            this.ParametersPanelButton.Size = new System.Drawing.Size(182, 94);
            this.ParametersPanelButton.TabIndex = 2;
            this.ParametersPanelButton.Text = "Parameters";
            this.ParametersPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ParametersPanelButton.UseVisualStyleBackColor = true;
            this.ParametersPanelButton.Click += new System.EventHandler(this.ParametersPanelButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(150)))), ((int)(((byte)(225)))));
            this.panel3.Controls.Add(this.CommandPanelButton);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 257);
            this.panel3.TabIndex = 1;
            // 
            // CommandPanelButton
            // 
            this.CommandPanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.CommandPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CommandPanelButton.Enabled = false;
            this.CommandPanelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(150)))), ((int)(((byte)(225)))));
            this.CommandPanelButton.FlatAppearance.BorderSize = 5;
            this.CommandPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommandPanelButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandPanelButton.ForeColor = System.Drawing.Color.Transparent;
            this.CommandPanelButton.Location = new System.Drawing.Point(59, 0);
            this.CommandPanelButton.Name = "CommandPanelButton";
            this.CommandPanelButton.Size = new System.Drawing.Size(180, 89);
            this.CommandPanelButton.TabIndex = 6;
            this.CommandPanelButton.Text = "Command";
            this.CommandPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CommandPanelButton.UseVisualStyleBackColor = false;
            this.CommandPanelButton.Click += new System.EventHandler(this.CommandPanelButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(225)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.SendPanelButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 170);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(225)))));
            this.panel5.Controls.Add(this.RecievePanelButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(224, 84);
            this.panel5.TabIndex = 3;
            // 
            // RecievePanelButton
            // 
            this.RecievePanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.RecievePanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecievePanelButton.Enabled = false;
            this.RecievePanelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(150)))), ((int)(((byte)(225)))));
            this.RecievePanelButton.FlatAppearance.BorderSize = 5;
            this.RecievePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecievePanelButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecievePanelButton.ForeColor = System.Drawing.Color.Transparent;
            this.RecievePanelButton.Location = new System.Drawing.Point(57, 0);
            this.RecievePanelButton.Name = "RecievePanelButton";
            this.RecievePanelButton.Size = new System.Drawing.Size(182, 84);
            this.RecievePanelButton.TabIndex = 8;
            this.RecievePanelButton.Text = "Recieve Files";
            this.RecievePanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecievePanelButton.UseVisualStyleBackColor = false;
            this.RecievePanelButton.Click += new System.EventHandler(this.RecievePanelButton_Click);
            // 
            // SendPanelButton
            // 
            this.SendPanelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.SendPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendPanelButton.Enabled = false;
            this.SendPanelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(150)))), ((int)(((byte)(225)))));
            this.SendPanelButton.FlatAppearance.BorderSize = 5;
            this.SendPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendPanelButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendPanelButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendPanelButton.Location = new System.Drawing.Point(58, -2);
            this.SendPanelButton.Name = "SendPanelButton";
            this.SendPanelButton.Size = new System.Drawing.Size(171, 95);
            this.SendPanelButton.TabIndex = 4;
            this.SendPanelButton.Text = "Send Files";
            this.SendPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SendPanelButton.UseVisualStyleBackColor = false;
            this.SendPanelButton.Click += new System.EventHandler(this.SendPanelButton_Click);
            // 
            // ParametersPanel
            // 
            this.ParametersPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ParametersPanel.Controls.Add(this.SendPara);
            this.ParametersPanel.Controls.Add(this.label1);
            this.ParametersPanel.Controls.Add(this.ParityBox);
            this.ParametersPanel.Controls.Add(this.label7);
            this.ParametersPanel.Controls.Add(this.StopbitBox);
            this.ParametersPanel.Controls.Add(this.label6);
            this.ParametersPanel.Controls.Add(this.DatabitBox);
            this.ParametersPanel.Controls.Add(this.label4);
            this.ParametersPanel.Controls.Add(this.StatusLabel);
            this.ParametersPanel.Controls.Add(this.DissconnectButton);
            this.ParametersPanel.Controls.Add(this.BaudrateBox);
            this.ParametersPanel.Controls.Add(this.ChangePara);
            this.ParametersPanel.Controls.Add(this.ConnectButton);
            this.ParametersPanel.Controls.Add(this.PortBox);
            this.ParametersPanel.Location = new System.Drawing.Point(227, 170);
            this.ParametersPanel.Name = "ParametersPanel";
            this.ParametersPanel.Size = new System.Drawing.Size(621, 346);
            this.ParametersPanel.TabIndex = 18;
            // 
            // SendPara
            // 
            this.SendPara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendPara.Enabled = false;
            this.SendPara.FlatAppearance.BorderSize = 0;
            this.SendPara.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.SendPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendPara.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendPara.Location = new System.Drawing.Point(421, 165);
            this.SendPara.Name = "SendPara";
            this.SendPara.Size = new System.Drawing.Size(169, 75);
            this.SendPara.TabIndex = 24;
            this.SendPara.Text = "Send parameter\'s";
            this.SendPara.UseVisualStyleBackColor = true;
            this.SendPara.Click += new System.EventHandler(this.SendPara_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Parity bit";
            // 
            // ParityBox
            // 
            this.ParityBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ParityBox.Enabled = false;
            this.ParityBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParityBox.FormattingEnabled = true;
            this.ParityBox.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.ParityBox.Location = new System.Drawing.Point(26, 275);
            this.ParityBox.Name = "ParityBox";
            this.ParityBox.Size = new System.Drawing.Size(154, 33);
            this.ParityBox.TabIndex = 22;
            this.ParityBox.Text = "None";
            this.ParityBox.SelectedIndexChanged += new System.EventHandler(this.ParityBox_SelectedValueChanged);
            this.ParityBox.SelectedValueChanged += new System.EventHandler(this.ParityBox_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(209, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Stop bit";
            // 
            // StopbitBox
            // 
            this.StopbitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopbitBox.Enabled = false;
            this.StopbitBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopbitBox.FormattingEnabled = true;
            this.StopbitBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.StopbitBox.Location = new System.Drawing.Point(26, 216);
            this.StopbitBox.Name = "StopbitBox";
            this.StopbitBox.Size = new System.Drawing.Size(154, 33);
            this.StopbitBox.TabIndex = 20;
            this.StopbitBox.Text = "1";
            this.StopbitBox.SelectedIndexChanged += new System.EventHandler(this.StopbitBox_SelectedValueChanged);
            this.StopbitBox.SelectedValueChanged += new System.EventHandler(this.StopbitBox_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(209, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Bits per byte";
            // 
            // DatabitBox
            // 
            this.DatabitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DatabitBox.Enabled = false;
            this.DatabitBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabitBox.FormattingEnabled = true;
            this.DatabitBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.DatabitBox.Location = new System.Drawing.Point(26, 154);
            this.DatabitBox.Name = "DatabitBox";
            this.DatabitBox.Size = new System.Drawing.Size(154, 33);
            this.DatabitBox.TabIndex = 18;
            this.DatabitBox.Text = "8";
            this.DatabitBox.SelectedIndexChanged += new System.EventHandler(this.DatabitBox_SelectedValueChanged);
            this.DatabitBox.SelectedValueChanged += new System.EventHandler(this.DatabitBox_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Baud rate";
            // 
            // SendfilePanel
            // 
            this.SendfilePanel.BackColor = System.Drawing.Color.White;
            this.SendfilePanel.Controls.Add(this.FileNameBox);
            this.SendfilePanel.Controls.Add(this.SendfileButton);
            this.SendfilePanel.Controls.Add(this.label5);
            this.SendfilePanel.Controls.Add(this.ChoosefileButton);
            this.SendfilePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendfilePanel.Location = new System.Drawing.Point(227, 170);
            this.SendfilePanel.Name = "SendfilePanel";
            this.SendfilePanel.Size = new System.Drawing.Size(621, 346);
            this.SendfilePanel.TabIndex = 19;
            this.SendfilePanel.Visible = false;
            // 
            // SendfileButton
            // 
            this.SendfileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendfileButton.Enabled = false;
            this.SendfileButton.FlatAppearance.BorderSize = 0;
            this.SendfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.SendfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendfileButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendfileButton.Location = new System.Drawing.Point(14, 142);
            this.SendfileButton.Name = "SendfileButton";
            this.SendfileButton.Size = new System.Drawing.Size(106, 61);
            this.SendfileButton.TabIndex = 12;
            this.SendfileButton.Text = "Send";
            this.SendfileButton.UseVisualStyleBackColor = true;
            this.SendfileButton.Click += new System.EventHandler(this.SendfileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 36);
            this.label5.TabIndex = 10;
            this.label5.Text = "Send Files";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 36);
            this.label8.TabIndex = 11;
            this.label8.Text = "Recieve Files";
            // 
            // RecieveFilePanel
            // 
            this.RecieveFilePanel.BackColor = System.Drawing.Color.White;
            this.RecieveFilePanel.Controls.Add(this.label11);
            this.RecieveFilePanel.Controls.Add(this.FileName);
            this.RecieveFilePanel.Controls.Add(this.label10);
            this.RecieveFilePanel.Controls.Add(this.FileListBox);
            this.RecieveFilePanel.Controls.Add(this.RecieveButton);
            this.RecieveFilePanel.Controls.Add(this.PathBox);
            this.RecieveFilePanel.Controls.Add(this.SaveInButton);
            this.RecieveFilePanel.Controls.Add(this.label8);
            this.RecieveFilePanel.Controls.Add(this.ReadParametersButton);
            this.RecieveFilePanel.Controls.Add(this.RefreshButton);
            this.RecieveFilePanel.Location = new System.Drawing.Point(227, 170);
            this.RecieveFilePanel.Name = "RecieveFilePanel";
            this.RecieveFilePanel.Size = new System.Drawing.Size(621, 346);
            this.RecieveFilePanel.TabIndex = 20;
            this.RecieveFilePanel.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(452, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 25);
            this.label11.TabIndex = 16;
            this.label11.Text = ".txt";
            // 
            // FileName
            // 
            this.FileName.BackColor = System.Drawing.Color.White;
            this.FileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileName.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileName.Location = new System.Drawing.Point(302, 215);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(133, 26);
            this.FileName.TabIndex = 15;
            this.FileName.Text = "name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "Choose file to recieve";
            // 
            // RecieveButton
            // 
            this.RecieveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecieveButton.Enabled = false;
            this.RecieveButton.FlatAppearance.BorderSize = 0;
            this.RecieveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.RecieveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecieveButton.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecieveButton.Location = new System.Drawing.Point(458, 263);
            this.RecieveButton.Name = "RecieveButton";
            this.RecieveButton.Size = new System.Drawing.Size(141, 75);
            this.RecieveButton.TabIndex = 13;
            this.RecieveButton.Text = "Recieve";
            this.RecieveButton.UseVisualStyleBackColor = true;
            this.RecieveButton.Click += new System.EventHandler(this.RecieveButton_Click);
            // 
            // MessaePanel
            // 
            this.MessaePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.MessaePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MessaePanel.Controls.Add(this.TopMessageBox);
            this.MessaePanel.Controls.Add(this.MinimizeButton);
            this.MessaePanel.Controls.Add(this.pictureBox6);
            this.MessaePanel.Controls.Add(this.ExitButton);
            this.MessaePanel.ForeColor = System.Drawing.Color.Transparent;
            this.MessaePanel.Location = new System.Drawing.Point(224, -1);
            this.MessaePanel.Name = "MessaePanel";
            this.MessaePanel.Size = new System.Drawing.Size(621, 162);
            this.MessaePanel.TabIndex = 21;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("Castellar", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeButton.Location = new System.Drawing.Point(537, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(42, 53);
            this.MinimizeButton.TabIndex = 4;
            this.MinimizeButton.Text = "-";
            this.MinimizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Location = new System.Drawing.Point(-212, 4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(764, 50);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseDown);
            this.pictureBox6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseMove);
            this.pictureBox6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseUp);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(579, -7);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(43, 61);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // CommandPanel
            // 
            this.CommandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.CommandPanel.Controls.Add(this.label9);
            this.CommandPanel.Controls.Add(this.CommandBox);
            this.CommandPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.CommandPanel.Location = new System.Drawing.Point(227, 170);
            this.CommandPanel.Name = "CommandPanel";
            this.CommandPanel.Size = new System.Drawing.Size(621, 346);
            this.CommandPanel.TabIndex = 1;
            this.CommandPanel.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(18, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "> Write instruction";
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.White;
            this.InfoPanel.Controls.Add(this.pictureBox8);
            this.InfoPanel.Location = new System.Drawing.Point(227, 170);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(621, 346);
            this.InfoPanel.TabIndex = 21;
            this.InfoPanel.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Terminal2017.Properties.Resources.info;
            this.pictureBox8.Location = new System.Drawing.Point(7, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(484, 346);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            // 
            // LightTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(179)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(849, 507);
            this.Controls.Add(this.RecieveFilePanel);
            this.Controls.Add(this.ParametersPanel);
            this.Controls.Add(this.SendfilePanel);
            this.Controls.Add(this.CommandPanel);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.MessaePanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LightTerminal";
            this.Text = "Light";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoButton)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ParametersPanel.ResumeLayout(false);
            this.ParametersPanel.PerformLayout();
            this.SendfilePanel.ResumeLayout(false);
            this.SendfilePanel.PerformLayout();
            this.RecieveFilePanel.ResumeLayout(false);
            this.RecieveFilePanel.PerformLayout();
            this.MessaePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.CommandPanel.ResumeLayout(false);
            this.CommandPanel.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TopMessageBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox PortBox;
        private System.Windows.Forms.ComboBox BaudrateBox;
        private System.Windows.Forms.Button ReadParametersButton;
        private System.Windows.Forms.Button ChangePara;
        private System.Windows.Forms.RichTextBox CommandBox;
        private System.Windows.Forms.TextBox StatusLabel;
        private System.Windows.Forms.Button DissconnectButton;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Button SaveInButton;
        private System.Windows.Forms.Button ChoosefileButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox InfoButton;
        private System.Windows.Forms.Button ParametersPanelButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button CommandPanelButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button SendPanelButton;
        private System.Windows.Forms.Button RecievePanelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel ParametersPanel;
        private System.Windows.Forms.Panel SendfilePanel;
        private System.Windows.Forms.Panel RecieveFilePanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox StopbitBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox DatabitBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ParityBox;
        private System.Windows.Forms.Panel CommandPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SendfileButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel MessaePanel;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button RecieveButton;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SendPara;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox FileName;
        public System.Windows.Forms.ListBox FileListBox;
    }
}

