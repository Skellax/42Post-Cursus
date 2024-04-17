#include <stdio.h>
#include <stdlib.h>
#include <string.h>
/*
    This program will print its own source when run
*/
#define SULLY "#include <stdio.h>%2$c#include <stdlib.h>%2$c#include <string.h>%2$c/*%2$c    This program will print its own source when run%2$c*/%2$c#define SULLY %3$c%1$s%3$c%2$c%2$cint main()%2$c{%2$c    int i = %4$d;%2$c    if (i <= 0)%2$c        return 0;%2$c    char src_filename[100];%2$c    sprintf(src_filename, %3$cSully_%%d.c%3$c, i);%2$c    if (!strcmp(src_filename, __FILE__))%2$c        i--;%2$c    char new_src[100];%2$c    sprintf(new_src, %3$cSully_%%d.c%3$c, i);%2$c    char exec_cmd[100];%2$c    sprintf(exec_cmd, %3$cSully_%%d%3$c, i);%2$c    FILE *f = fopen(new_src, %3$cw%3$c);%2$c    if (f == NULL)%2$c        return(1);%2$c    fprintf(f, SULLY, SULLY, 10, 34, i);%2$c    fclose(f);%2$c    char compile[300];%2$c    sprintf(compile, %3$cgcc -Wall -Wextra -Werror -o %%s %%s%3$c, exec_cmd, new_src);%2$c    system(compile);%2$c    char run[200];%2$c    sprintf(run, %3$c./%%s%3$c, exec_cmd);%2$c    system(run);%2$c}"

int main()
{
    int i = 5;
    if (i <= 0)
        return 0;
    char src_filename[100];
    sprintf(src_filename, "Sully_%d.c", i);
    if (!strcmp(src_filename, __FILE__))
        i--;
    char new_src[100];
    sprintf(new_src, "Sully_%d.c", i);
    char exec_cmd[100];
    sprintf(exec_cmd, "Sully_%d", i);
    FILE *f = fopen(new_src, "w");
    if (f == NULL)
        return(1);
    fprintf(f, SULLY, SULLY, 10, 34, i);
    fclose(f);
    char compile[300];
    sprintf(compile, "gcc -Wall -Wextra -Werror -o %s %s", exec_cmd, new_src);
    system(compile);
    char run[200];
    sprintf(run, "./%s", exec_cmd);
    system(run);
}