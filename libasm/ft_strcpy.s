section .text

;char *strcpy(char *dest, const char *src);

;The  strcpy()  function  copies the string pointed to by src, including
;the terminating null byte ('\0'), to the buffer  pointed  to  by  dest.
;The  strings  may  not overlap, and the destination string dest must be
;large enough to receive the copy.  Beware  of  buffer  overruns!   (See
;BUGS.)

;rdi = dest
;rsi = src


global ft_strcpy

    ft_strcpy:
    xor rax, rax ; mov rax, 0

    loop:
    cmp byte [rsi + rax], 0 ; check if src[rcx] == '\0'
    je loopend  ;leave the loop if src[rcx] == '\0'  
    mov cl , [rsi + rax] ; move the src into cl 
    mov [rdi + rax], cl ; move the
    inc rax  ; move the next
    jmp loop

    loopend:
    mov cl, 0  ; add '\0' in the end of dest
    mov [rdi + rax], cl
    mov rax, rdi ; move the result into rcx 
    ret ; return rax 