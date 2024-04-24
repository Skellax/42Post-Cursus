<h1 align = 'center'> DrQuine </h1>

<h2>Description</h2>

<p align = 'justify'>A quine is a computer program (a kind of metaprogram) whose output and source
code are identical. As a challenge or for fun, some programmers try to write the shortest
quine in a given programming language.
The operation that consist of simply opening the source file and displaying it is
considered cheating. More generally, a program that uses any data entry cannot be
considered a valid quine. A trivial solution is a program whose source code is empty.
Indeed, the execution of such a program produces for most languages no output, that is
to say the source code of the program. </p>

<h2>Rules</h2>
<p align = 'justify'>you can validate this project without ASM if you want the 100% you need to 
finsihed the 3 exercices in C and ASM ! < /p> 

<ul>
  <li>File only .s for asm</li>
  <li>Need 3 programs with named Cooleen, Grace and Sully</li>
  <li>Your Makefile doesn't relink</li>
  <li>No Segfault, bus Error...</li>
</ul>

<h3>Colleen</h3>

<ul>
  <li>The executable must be named Colleen</li>
  <li>When executed, the program must display on the standard output an output
identical to the source code of the file used to compile the program. </li>
  <li>The source code must contain at least:
    <ul>
      <li>A main function </li>
      <li>Two different comments</li>
      <li>One of the comments must be present in the main function</li>
      <li>One of the comments must be present outside of your program.</li>
      <li>Another function in addition to the main function (which of course will be
called)</li>
</ul>

You can test you executable with this line command.
If there a no difference, it's good !

 ``` ./Colleen > tmp_Colleen ; diff tmp_Colleen Colleen.c ```

 <h3>Grace</h3>

 <ul>
   <li>The executqble ,ust be nq,ed Grqce</li>
   <li>When executed, the program writes in a file named Grace_kid.c for C and Grace_kid.s</li>
   <li>The source code must strickly contain</li>
   <ul>
     <li>No main declared</li>
     <li>Three defines only</li>
     <li>One comment</li>
   </ul>
   <li>Yhe program will run by calling a macro</li>
 </ul>

 <h3>Sully</h3>
 
 <ul>
   <li>Yhe executable must be named Sully</li>
   <li>When executed the program writes in a file named Sully_X.c?Sully_X.s> The X will be an integer given in the source. Once the fil is created, the program co;piles this file and then runs the new program(wich will have the name of its source file).</li>
   <li>Stopping the programs depends on the file name : the resulting program will be executed only if the interger X is freateror equals that zero</li>
   <li>An integer is thergore present in the source of your program and will have to evolbe by decrementing every time you create a source file frome the execution of the program.</li>
   <li>You have no constraints on the source code, appart from the integer that will be set to 5 at first.</li>
 </ul>

 
<h2>Links</h2>

 def of quine: https://en.wikipedia.org/wiki/Quine_(computing)
