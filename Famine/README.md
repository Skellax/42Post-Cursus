<h1 align = 'center'> Famine </h1>

<div align = 'center'>
<img src="images.jpeg" widt=300>
</div>

<h2>Description</h2>
  <p>Famine is a binary you need to conceive that will modify one or multiple binaries ap-
plying some additional functions to it/them, without modifying the original behavior of
said binary(ies). So this time, we will limit ourselves to add a “signature” to this binary
and nothing else. Famine will have to apply this “signature” to all the binaries present
in a specific temporary folder. The “signature” is symbolized with a line containing your
specific logins and it could look like that:</p>

```Famine version 1.0 (c)oded by <first-login>-<second-login>```

<h2>Rules</h2>


<ul>
  <li>The executable must be named <b>Famine</b>.</li>
  <li>Your project must be written in C or assembly language nothing else.</li>
  <li>You program will not display anything neither on the standard output nor on the
error output.</li>
  <li>It is <b>MANDATORY</b> to work in a VM.</li>
  <li>The target operating system is free. However you will have to prepare an appropri-
ate VM for your p2p.</li>
  <li>Your program will have to act on the /tmp/test and /tmp/test2 folders or equivalent
according to your target operating system, and ONLY in those folders. The control
of the spreading of your program is your responsibility</li>
  <li><b>WARNING !</b> Only one infection on said binary is possible.</li>
  <li> Infections will be at first on the binaries of the operating system that have a 64 bits architecture.</li>
</ul>

<h3>Exemple</h3>

Prepare the field 

```
# ls -al ~/famine
total 736
drwxr-xr-x 3 root root 4096 May 24 08:03 .
drwxr-xr-x 5 root root 4096 May 24 07:32 ..
-rwxr-xr-x 1 root root 744284 May 24 08:03 Famine
```
We created sample.c for the test 

```
# nl sample.c
1 #include <stdio.h>
2 int
3 main(void) {
4 printf("Hello, World!\n");
5 return 0;
6 }
# gcc -m64 ~/Virus/sample/sample.c
#
```

We copy the binaries (tests +ls) 

```
# cp ~/Virus/sample/sample /tmp/test2/.
# ls -al /tmp/test
total 16
drwxr-xr-x 2 root root 4096 May 24 08:07 .
drwxrwxrwt 13 root root 4096 May 24 08:08 ..
-rwxr-xr-x 1 root root 6712 May 24 08:11 sample
# /tmp/test/sample
Hello, World!
# file /tmp/test/sample
/tmp/test/sample: ELF 64-bit LSB executable, x86-64, version 1 (SYSV), dynamically linked, interpreter /
lib64/ld-linux-x86-64.so.2, for GNU/Linux 2.6.32, BuildID[sha1]=938[...]10b, not stripped
# strings /tmp/test/sample | grep "wandre"
# cp /bin/ls /tmp/test2/
# ls -al /tmp/test2
total 132
drwxr-xr-x 2 root root 4096 May 24 08:11 .
drwxrwxrwt 14 root root 4096 May 24 08:11 ..
-rwxr-xr-x 1 root root 126480 May 24 08:12 ls
# file /tmp/test2/ls
/ tmp/test2/ls: ELF 64-bit LSB executable, x86-64, version 1 (SYSV), dynamically linked, interpreter /
lib64/ld-linux-x86-64.so.2, for GNU/Linux 2.6.32, BuildID[sha1]=67e[...]281, stripped
```

We run famine : 

```
# ./Famine
# strings /tmp/test/sample | grep "wandre"
Famine version 1.0 (c)oded oct-2015 by wandre
# /tmp/test/sample
Hello, World!
# strings /tmp/test2/ls | grep "wandre"
Famine version 1.0 (c)oded oct-2015 by wandre
# /tmp/test2/ls -la /tmp/test2/
total 132
drwxr-xr-x 2 root root 4096 May 24 08:11 .
drwxrwxrwt 14 root root 4096 May 24 08:17 ..
-rwxr-xr-x 1 root root 126480 May 24 08:12 ls
# gcc -m64 ~/Virus/sample/sample.c -o /tmp/test/sample
# ls -al /tmp/test
total 16
drwxr-xr-x 2 root root 4096 May 24 08:07 .
drwxrwxrwt 13 root root 4096 May 24 08:08 ..
-rwxr-xr-x 1 root root 6712 May 24 08:12 sample
# /tmp/test/sample
Hello, World!
# file /tmp/test/sample
/tmp/test/sample: ELF 64-bit LSB executable, x86-64, version 1 (SYSV), dynamically linked, interpreter /
lib64/ld-linux-x86-64.so.2, for GNU/Linux 2.6.32, BuildID[sha1]=93866
e4ce7a2fe18506bd6c6218e413156a8d10b, not stripped
# strings /tmp/test/sample | grep "wandre"
# /tmp/test2/ls -la /tmp/test2/
total 132
drwxr-xr-x 2 root root 4096 May 24 08:11 .
drwxrwxrwt 14 root root 4096 May 24 08:17 ..
-rwxr-xr-x 1 root root 126480 May 24 08:12 ls
# strings /tmp/test/sample | grep "wandre"
Famine version 1.0 (c)oded oct-2015 by wandre
```

link with my partner for this project :) : <a>https://github.com/BlankRose</a>
