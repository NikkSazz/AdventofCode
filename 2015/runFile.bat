@ehco off
REM Ensure the file name is passed as an argument
if "%-1"=="" (
	echo Usage: runFile.bat filename_without_extension
	exit /b 1
)

REM Variables
set ASM_FILE=%~1.asm
set OBJ_FILE=%~1.o
set EXE_FILE=%~1.exe

REM Step 1: Assemble the .asm file into an object file
nasm -f elf64 -o %OBJ_FILE% %ASM_FILE%
if errorlevel 1 (
    echo Assembly failed!
    exit /b 1
)

REM Step 2: Link the object file to create an executable
ld -o %~1 %OBJ_FILE%
if errorlevel 1 (
    echo Linking failed!
    exit /b 1
)

./%~1
