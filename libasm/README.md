<h1 align = 'center' >Libasm</h1>

<h2>Description</h2>

<p align = 'justify'>An assembly (or assembler) language, often abbreviated asm, is a low-level programming
language for a computer, or other programmable device, in which there is a very strong
(but often not one-to-one) correspondence between the language and the architecture’s
machine code instructions. Each assembly language is specific to a particular computer
architecture. In contrast, most high-level programming languages are generally portable
across multiple architectures but require interpreting or compiling. Assembly language
may also be called symbolic machine code.</p>

<h2>Rules</h2>

<ul>
  <li>Files only .s</li>
  <li>You must use nasm for compile</li>
  <li>Need a Makefile with all, re, clean, fclean</li>
  <li>The flags no-pie is forbidden !</li>
  <li>Your Makefile doesn't relink.</li>
  <li>You need to use your own test </li>
</ul>

<h2>Commands</h2>

```
  principals registers : rdi, rsi , rdx , r8, r9;
  return register: rax;
  others reigsters who could use for a loop : rbx, rcx;

  mov dest, src : move the src into the dest
  cmp rax, 0 : comparaison if rax with '\0'  for exemple
  je :  condition rax == '\0'
  jl: condition rax < 0
  jg: condition rax > 0
  jne: condition rax != '\0'
  jmp : use to move with differents instructions, you can create a loop thanks to the jump command for exemple.
  syscall: use to call function system like write , exit or read (each function system  have a specific number)

ex: rax, 60 ; 60 is the number to call exit function
      syscall 60
```

They have other command so don't hesitate to check all options :) ! 



<h2>Links</h2>

<p>For french students:</p>
<p>http://sdz.tdct.org/sdz/en-profondeur-avec-l-assembleur.html</p>
<p>https://www.youtube.com/watch?v=fvtd2Ut3MHw&list=PLrSOXFDHBtfEs7PCC6r44iXiX5gMlbjcR</p>

<p>For the others:</p>
<p>https://en.wikipedia.org/wiki/Assembly_language</p>
<p>https://www.investopedia.com/terms/a/assembly-language.asp#:~:text=An%20assembly%20language%20is%20a,to%20be%20readable%20by%20humans.</p>
<p>https://filippo.io/linux-syscall-table/</p>




