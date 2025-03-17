section .data
    filename db 'file.txt', 0
    buffer db 256   ; stores contents of file in blocks of 256

section .bss
    file_desctiptor resd 1  ; identify an open file
    bytes_read resd 1

section .text
    global _start

_start:

    ; Open the file
    mov eax, 5                      ; sys_open system call number
    mov ebx, filename               ; Pointer to the filename
    mov ecx, 0                      ; Read-only mode
    int 0x80                         ; Make system call
    mov [file_descriptor], eax      ; Save the file descriptor
    mov [file_desctiptor], eax ; save

    ; did file open successfully?
    cmp eax, 0
    jl error_exit


read_loop:

    ; Read the file (256 bytes at a time)
    mov eax, 3                      ; sys_read system call number
    mov ebx, [file_descriptor]      ; File descriptor
    mov ecx, buffer                 ; Pointer to the buffer
    mov edx, 256                    ; Number of bytes to read
    int 0x80                         ; Make system call
    mov [bytes_read], eax           ; Store the number of bytes read

    ; if we read any bytes
    cmp eax, 0
    je close_file

    ; Print the contents read
    mov eax, 4                      ; sys_write system call number
    mov ebx, 1                      ; File descriptor for stdout
    mov ecx, buffer                 ; Pointer to the buffer
    mov edx, eax                    ; Number of bytes read
    int 0x80                         ; Make system call

    ; Loop to read the next chunk
    jmp read_loop

close_file:

    ; close file
    mov eax, 6          ; sys close
    mov ebx, [file_desctiptor]
    int 0x80

    ; Exit
    mov eax, 1          ; sys exit
    xor ebx, ebx
    int 0x80

error_exit:
    mov eax, 1          ; sys exit
    mov ebx, 1          ; indicates error
    int 0x80
