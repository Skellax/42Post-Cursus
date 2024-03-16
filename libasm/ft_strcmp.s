section .text

;int strcmp(const char *s1, const char *s2);

;The  strcmp()  function compares the two strings s1 and s2.  The locale
;is not taken into account (for  a  locale-aware  comparison,  see  str‐
;coll(3)).  The comparison is done using unsigned characters.

;strcmp() returns an integer indicating the result of the comparison, as
;follows:

;• 0, if the s1 and s2 are equal;

;• a negative value if s1 is less than s2;

;• a positive value if s1 is greater than s2.

;rdi = s1;
;rsi = s2

global ft_strcmp

        ft_strcmp:
        xor rcx, rcx ; move rcx, 0
        xor rbx, rbx ; move rbx, 0 

        loop:
        mov al, byte [rdi + rcx]  
        mov bl, byte [rsi + rcx] 
        cmp al, 0  ; check the end of the first string
        je endloop
        cmp bl, 0  ; check the end of the second string
        je endloop
        cmp al, bl ; compare the two string
        jne endloop
        inc rcx ; rcx + 1 if the caracter is the same
        jmp loop 

        endloop:
            movzx rax, al  ; zero-extend al to rdx
            movzx r8, bl    ;zero-extend bl to r8
            sub rax, r8 ;s1 - s2
            ret 