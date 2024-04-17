;This program will print its own source when run
section .data
    msg db ";This program will print its own source when run%2$csection .data%2$c    msg db %3$c%1$s%3$c, 0%2$c    file db %3$cGrace_kid.s%3$c, 0%2$c    mode db %3$cw%3$c, 0%2$c%2$csection .text%2$c    extern fprintf%2$c    extern fopen%2$c    extern fclose%2$c    extern exit%2$c%2$c%%macro GRACE 0%2$cglobal main%2$cmain:%2$c    mov rdi, file%2$c    mov rsi, mode%2$c    call fopen%2$c    test rax, rax%2$c    jz _error%2$c    mov rdi, rax%2$c    mov r15, rax%2$c    lea rsi, [rel msg]%2$c    mov rdx, rsi%2$c    mov rcx, 10%2$c    mov r8, 34%2$c    call fprintf%2$c%2$c    mov rdi, r15%2$c    call fclose%2$c%2$c    _error:%2$c        mov rdi, 0%2$c        call exit%2$c%%endmacro%2$c%2$cGRACE", 0
    file db "Grace_kid.s", 0
    mode db "w", 0

section .text
    extern fprintf
    extern fopen
    extern fclose
    extern exit

%macro GRACE 0
global main
main:
    mov rdi, file
    mov rsi, mode
    call fopen
    test rax, rax
    jz _error
    mov rdi, rax
    mov r15, rax
    lea rsi, [rel msg]
    mov rdx, rsi
    mov rcx, 10
    mov r8, 34
    call fprintf

    mov rdi, r15
    call fclose

    _error:
        mov rdi, 0
        call exit
%endmacro

GRACE