section .text

;ssize_t read(int fd, void *buf, size_t count);

;read()  attempts to read up to count bytes from file descriptor fd into
;the buffer starting at buf.

;On files that support seeking, the read operation commences at the file
;offset, and the file offset is incremented by the number of bytes read.
;If the file offset is at or past the end of file, no  bytes  are  read,
;and read() returns zero.

;If count is zero, read() may detect the errors described below.  In the
;absence of any errors, or if read() does not check for errors, a read()
;with a count of 0 returns zero and has no other effects.

;rdi = fd
;rsi = *buf
;rdx = count


global ft_read

    ft_read:
        mov rax, 0 ;syscall read
        syscall ;call read
        cmp rax, 0
        jl error ; if rax < 0 jump to the error 
        ret
    
    error:
        mov rax, -1  ; return -1
        ret