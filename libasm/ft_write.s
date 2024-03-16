section .text

;ssize_t write(int fd, const void *buf, size_t count);

;write() writes up to count bytes from the buffer starting at buf to the
;file referred to by the file descriptor fd.

;The number of bytes written may be less than  count  if,  for  example,
;there  is  insufficient space on the underlying physical medium, or the
;RLIMIT_FSIZE resource limit is encountered (see setrlimit(2)),  or  the
;call was interrupted by a signal handler after having written less than
;count bytes.  (See also pipe(7).)

;rdi = fd
;rsi = *buf 
;rdx = count

global ft_write

    ft_write:
        mov rax, 1 ;syscall write
        syscall ;call write
        cmp rax, 0  ;checked if we found a error
        jl error  ;if rax < 0 we jump in error fonction;
        ret 

    error:
        mov rax, -1  ; return -1
        ret