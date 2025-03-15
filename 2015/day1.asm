.model small
.stack 100h

; using DOS API
;   invoked using sofware interrupt
;   int 21h (interrupt 21h using ah processor)
;   is used often to invoke interrupts, which do stuff
;   file access, string print, user input, ect.

.data
    ; Messages
    day_msg db 'Advent of Code 2015, Day ONE$' ; start of code
    part_one_msg db 'Part One: $'
    part_two_msg db 'Part Two: $'

    ; Stored information
    basement db 0   ; Index of charArr where floor == -1
    floor db 0  ; Floor, if '(' ++  if ')' --

    ; Files
    filename db '1.txt'
    file_handle dw 0
    open_failed_msg db 'Error opening file.$'

.Code
main:
    ; init data segment
    mov ax, @data
    mov ds, ax

    call printStrtMsg           ; 'Advent of Code 2015, Day ONE'

    ; Open file (filename)
    lea dx, filename
    mov ah, 3Ch                 ; DOS func to truncate file
    int 21h                     ; DOS interrupt
    jc open_failed              ; if failed to open file
    mov file_handle, ax         ; file data in file_handle

printStrtMsg:

    ; Print the message
    mov ah, 09h                 ; DOS function to print string
    lea dx, day_msg             ; Load address of message into DX
    int 21h                     ; Interrupt to call DOS function

    call newLine

newLine:
    
    ; linefeed plus a carriage return, 
    ; back to the beginning of the current line wihtout advancing to the next
    mov ah, 02h               ; DOS func for single char
    mov dl, 13                ; ascii for carriage return
    int 21h
    mov dl, 10                ; ascii for newLine
    int 21h

open_failed:
    ; Handle file open failure
    mov ah, 09h              ; DOS function to print string
    lea dx, open_failed_msg  ; Load failure message
    int 21h                  ; Call DOS interrupt
    mov ah, 4Ch              ; Exit program
    int 21h

end main