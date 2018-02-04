################################################################################
# Automatically-generated file. Do not edit!
################################################################################

-include ../makefile.local

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS_QUOTED += \
"../Sources/BoardSupport.c" \
"../Sources/DistSens.c" \
"../Sources/UART.c" \
"../Sources/UltraSonic.c" \
"../Sources/adc.c" \
"../Sources/arm_cm0.c" \
"../Sources/battery.c" \
"../Sources/main.c" \
"../Sources/mcg.c" \
"../Sources/motors.c" \
"../Sources/pit.c" \
"../Sources/sa_mtb.c" \
"../Sources/servo.c" \

C_SRCS += \
../Sources/BoardSupport.c \
../Sources/DistSens.c \
../Sources/UART.c \
../Sources/UltraSonic.c \
../Sources/adc.c \
../Sources/arm_cm0.c \
../Sources/battery.c \
../Sources/main.c \
../Sources/mcg.c \
../Sources/motors.c \
../Sources/pit.c \
../Sources/sa_mtb.c \
../Sources/servo.c \

OBJS += \
./Sources/BoardSupport.o \
./Sources/DistSens.o \
./Sources/UART.o \
./Sources/UltraSonic.o \
./Sources/adc.o \
./Sources/arm_cm0.o \
./Sources/battery.o \
./Sources/main.o \
./Sources/mcg.o \
./Sources/motors.o \
./Sources/pit.o \
./Sources/sa_mtb.o \
./Sources/servo.o \

C_DEPS += \
./Sources/BoardSupport.d \
./Sources/DistSens.d \
./Sources/UART.d \
./Sources/UltraSonic.d \
./Sources/adc.d \
./Sources/arm_cm0.d \
./Sources/battery.d \
./Sources/main.d \
./Sources/mcg.d \
./Sources/motors.d \
./Sources/pit.d \
./Sources/sa_mtb.d \
./Sources/servo.d \

OBJS_QUOTED += \
"./Sources/BoardSupport.o" \
"./Sources/DistSens.o" \
"./Sources/UART.o" \
"./Sources/UltraSonic.o" \
"./Sources/adc.o" \
"./Sources/arm_cm0.o" \
"./Sources/battery.o" \
"./Sources/main.o" \
"./Sources/mcg.o" \
"./Sources/motors.o" \
"./Sources/pit.o" \
"./Sources/sa_mtb.o" \
"./Sources/servo.o" \

C_DEPS_QUOTED += \
"./Sources/BoardSupport.d" \
"./Sources/DistSens.d" \
"./Sources/UART.d" \
"./Sources/UltraSonic.d" \
"./Sources/adc.d" \
"./Sources/arm_cm0.d" \
"./Sources/battery.d" \
"./Sources/main.d" \
"./Sources/mcg.d" \
"./Sources/motors.d" \
"./Sources/pit.d" \
"./Sources/sa_mtb.d" \
"./Sources/servo.d" \

OBJS_OS_FORMAT += \
./Sources/BoardSupport.o \
./Sources/DistSens.o \
./Sources/UART.o \
./Sources/UltraSonic.o \
./Sources/adc.o \
./Sources/arm_cm0.o \
./Sources/battery.o \
./Sources/main.o \
./Sources/mcg.o \
./Sources/motors.o \
./Sources/pit.o \
./Sources/sa_mtb.o \
./Sources/servo.o \


# Each subdirectory must supply rules for building sources it contributes
Sources/BoardSupport.o: ../Sources/BoardSupport.c
	@echo 'Building file: $<'
	@echo 'Executing target #1 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/BoardSupport.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/BoardSupport.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/DistSens.o: ../Sources/DistSens.c
	@echo 'Building file: $<'
	@echo 'Executing target #2 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/DistSens.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/DistSens.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/UART.o: ../Sources/UART.c
	@echo 'Building file: $<'
	@echo 'Executing target #3 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/UART.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/UART.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/UltraSonic.o: ../Sources/UltraSonic.c
	@echo 'Building file: $<'
	@echo 'Executing target #4 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/UltraSonic.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/UltraSonic.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/adc.o: ../Sources/adc.c
	@echo 'Building file: $<'
	@echo 'Executing target #5 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/adc.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/adc.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/arm_cm0.o: ../Sources/arm_cm0.c
	@echo 'Building file: $<'
	@echo 'Executing target #6 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/arm_cm0.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/arm_cm0.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/battery.o: ../Sources/battery.c
	@echo 'Building file: $<'
	@echo 'Executing target #7 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/battery.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/battery.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/main.o: ../Sources/main.c
	@echo 'Building file: $<'
	@echo 'Executing target #8 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/main.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/main.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/mcg.o: ../Sources/mcg.c
	@echo 'Building file: $<'
	@echo 'Executing target #9 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/mcg.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/mcg.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/motors.o: ../Sources/motors.c
	@echo 'Building file: $<'
	@echo 'Executing target #10 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/motors.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/motors.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/pit.o: ../Sources/pit.c
	@echo 'Building file: $<'
	@echo 'Executing target #11 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/pit.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/pit.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/sa_mtb.o: ../Sources/sa_mtb.c
	@echo 'Building file: $<'
	@echo 'Executing target #12 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/sa_mtb.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/sa_mtb.o"
	@echo 'Finished building: $<'
	@echo ' '

Sources/servo.o: ../Sources/servo.c
	@echo 'Building file: $<'
	@echo 'Executing target #13 $<'
	@echo 'Invoking: ARM Ltd Windows GCC C Compiler'
	"$(ARMSourceryDirEnv)/arm-none-eabi-gcc" "$<" @"Sources/servo.args" -MMD -MP -MF"$(@:%.o=%.d)" -o"Sources/servo.o"
	@echo 'Finished building: $<'
	@echo ' '


