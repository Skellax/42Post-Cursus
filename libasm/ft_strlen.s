section .text

;size_t strlen(const char *s);

;The strlen() function calculates the length of the string pointed to by
;s, excluding the terminating null byte ('\0').

;rdi = s

global ft_strlen

    ft_strlen:
        xor rax, rax  ;mov rcx, 0 

    loop:
        cmp byte [rdi + rax], 0
        je loopend ;  leave the loop if rdi[rax] == '\0'
        inc rax ; incremente the return value
        jmp loop

    loopend:
        ret ; return rax 
         