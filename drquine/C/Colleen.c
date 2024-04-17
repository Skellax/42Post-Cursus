#include <stdio.h>
/*
    This program will print its own source when run
*/
void colleen()
{
    char *a = "#include <stdio.h>%2$c/*%2$c    This program will print its own source when run%2$c*/%2$cvoid colleen()%2$c{%2$c    char *a = %3$c%1$s%3$c;%2$c    printf(a, a, 10, 34);%2$c    /*%2$c        This program will print its own source when run%2$c    */%2$c}%2$c%2$cint main()%2$c{%2$c    colleen();%2$c}";
    printf(a, a, 10, 34);
    /*
        This program will print its own source when run
    */
}

int main()
{
    colleen();
}