;This Program will print its own source when run
%define count 5
section .data
    msg db ";This Program will print its own source when run%2$c%%define count %4$d%2$csection .data%2$c    msg db %3$c%1$s%3$c, 0%2$c    filename db %3$cSully_%%d.s%3$c, 0%2$c    sul db %3$cSully_%%d%3$c, 0%2$c    cmd db %3$cnasm -f elf64 -o %%1$s.o %%2$s && ld -lc -dynamic-linker /usr/lib64/ld-linux-x86-64.so.2 -o %%1$s %%1$s.o --entry main && ./%%1$s%3$c, 0%2$c    mode db %3$cw%3$c, 0%2$c%2$csection .bss%2$c    FILENAME resb 100%2$c    SUL resb 100%2$c    EXE resb 600%2$c%2$csection .text%2$c    extern sprintf%2$c    extern fprintf%2$c    extern fopen%2$c    extern exit%2$c    extern system%2$c    extern fclose%2$c    global main%2$c%2$cmain:%2$c    mov r12, count%2$c    cmp r12, 0%2$c    jle error%2$c    dec r12%2$c%2$c    lea rdi, [rel FILENAME]%2$c    lea rsi, [rel filename]%2$c    mov rdx, count%2$c    call sprintf%2$c%2$c    lea rdi, [rel SUL]%2$c    lea rsi, [rel sul]%2$c    mov rdx, count%2$c    call sprintf%2$c%2$c    lea rdi, [rel EXE]%2$c    lea rsi, [rel cmd]%2$c    mov rdx, SUL%2$c    mov rcx, FILENAME%2$c    call sprintf%2$c%2$c    mov rdi, FILENAME%2$c    mov rsi, mode%2$c    call fopen%2$c%2$c    test rax, rax%2$c    jz error%2$c%2$c    mov rdi, rax%2$c    mov r15, rax%2$c    lea rsi, [rel msg]%2$c    mov rdx, rsi%2$c    mov rcx, 10%2$c    mov r8, 34%2$c    mov r9, r12%2$c    call fprintf%2$c%2$c    mov rdi, r15%2$c    call fclose%2$c%2$c    mov rdi, EXE%2$c    call system%2$c%2$cerror:%2$c    xor rdi, rdi%2$c    call exit", 0
    filename db "Sully_%d.s", 0
    sul db "Sully_%d", 0
    cmd db "nasm -f elf64 -o %1$s.o %2$s && ld -lc -dynamic-linker /usr/lib64/ld-linux-x86-64.so.2 -o %1$s %1$s.o --entry main && ./%1$s", 0
    mode db "w", 0

section .bss
    FILENAME resb 100
    SUL resb 100
    EXE resb 600

section .text
    extern sprintf
    extern fprintf
    extern fopen
    extern exit
    extern system
    extern fclose
    global main

main:
    mov r12, count
    cmp r12, 0
    jle error
    dec r12

    lea rdi, [rel FILENAME]
    lea rsi, [rel filename]
    mov rdx, count
    call sprintf

    lea rdi, [rel SUL]
    lea rsi, [rel sul]
    mov rdx, count
    call sprintf

    lea rdi, [rel EXE]
    lea rsi, [rel cmd]
    mov rdx, SUL
    mov rcx, FILENAME
    call sprintf

    mov rdi, FILENAME
    mov rsi, mode
    call fopen

    test rax, rax
    jz error

    mov rdi, rax
    mov r15, rax
    lea rsi, [rel msg]
    mov rdx, rsi
    mov rcx, 10
    mov r8, 34
    mov r9, r12
    call fprintf

    mov rdi, r15
    call fclose

    mov rdi, EXE
    call system

error:
    xor rdi, rdi
    call exit