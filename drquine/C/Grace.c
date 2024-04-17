#include <stdio.h>
#define GRACE "#include <stdio.h>%2$c#define GRACE %3$c%1$s%3$c%2$c#define MAIN int main(){ FILE *f = fopen(%3$cGrace_kid.c%3$c, %3$cw%3$c); if (f != NULL){ fprintf(f, GRACE, GRACE, 10, 34);fclose(f);}else{ perror(%3$cerror%3$c);}}%2$c/*%2$c    This program will print its own source when run.%2$c*/%2$cMAIN"
#define MAIN int main(){ FILE *f = fopen("Grace_kid.c", "w"); if (f != NULL){ fprintf(f, GRACE, GRACE, 10, 34);fclose(f);}else{ perror("error");}}
/*
    This program will print its own source when run.
*/
MAIN