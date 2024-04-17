section .data
    msg db "section .data%2$c    msg db %3$c%1$s%3$c, 0%2$c%2$c;This program will print its own source when run%2$csection .text%2$c    extern printf%2$c    extern exit%2$c    global main%2$c    global colleen%2$c%2$ccolleen:%2$c    mov rdi, 0%2$c    call exit%2$c%2$cmain:%2$c    ;This program will print its own source when run%2$c    lea rdi, [rel msg]%2$c    mov rsi, rdi%2$c    mov rdx, 10%2$c    mov rcx, 34%2$c    call printf%2$c    call colleen", 0

;This program will print its own source when run
section .text
    extern printf
    extern exit
    global main
    global colleen

colleen:
    mov rdi, 0
    call exit

main:
    ;This program will print its own source when run
    lea rdi, [rel msg]
    mov rsi, rdi
    mov rdx, 10
    mov rcx, 34
    call printf
    call colleen