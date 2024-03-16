/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   test.c                                             :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: mfuhrman <mfuhrman@student.42.fr>          +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2024/02/26 12:26:32 by mfuhrman          #+#    #+#             */
/*   Updated: 2024/03/13 10:01:57 by mfuhrman         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

#include "libasm.h"

int main(void)
{
    //First Test ft_strlen

    printf(YELLOW);
    printf("----------------------\n");
    printf("|     ft_strlen      |\n");
    printf("----------------------\n");
    printf(RESET);

    printf("\n");

    printf(BLUE);
    printf("Test 1 : Hello World\n");
    printf(RESET);
    printf("test with strlen size: %ld\n", strlen("Hello World"));
    printf("test with ft_strlen size: %ld\n", ft_strlen("Hello World"));
    printf("-------------------------\n");
    printf("\n");
    printf(BLUE);
    printf("Test 2 : L'homme choisit l'esclave obeit !\n");
    printf(RESET);
    printf("test with strlen size: %ld\n", strlen("L'homme choisit l'esclave obeit !"));
    printf("test with ft_strlen size: %ld\n", ft_strlen("L'homme choisit l'esclave obeit !"));
    printf("-------------------------\n");
    printf("\n");
    printf(BLUE);
    printf("Test3 : ''\n");
    printf(RESET);
    printf("test with strlen size: %ld\n", strlen(""));
    printf("test with ft_strlen size: %ld\n", ft_strlen(""));
    printf("-------------------------\n");
    printf("\n");

    int input = 0; 

    //Pass the next test 

    while (input == 0)
    {
        char c;
        printf(GREEN);
        printf("print 'y' or 'Y' to pass the next test :");
        printf(RESET);
        scanf(" %c", &c);
        printf("\n"); 
        if (c == 'y' || c == 'Y')
            input = 1;
        else 
        {
            printf(RED);
            printf("wrong reponse, try again !\n");
            printf(RESET);
        }
    }
    input = 0;
    printf("\n");

    //2nd Test ft_strcpy 

    printf(YELLOW);
    printf("----------------------\n");
    printf("|     ft_strcpy      |\n");
    printf("----------------------\n");
    printf(RESET);

    char p1[] = "bonjour";
    char p2[] = "hello";
    char p3[]= "It is dangerous to go alone";
    char p4[] = "sorry the princess is a another castle !";
    char p5[] = "";
    char p6[] = "random string";

    printf(BLUE);
    printf("Test 1: dest = bonjour , src = hello \n");
    printf(RESET);
    printf("test with strcpy: %s \n", strcpy(p1, p2));
    printf("test with ft_strcpy: %s \n", ft_strcpy(p1, p2)); 
    printf("-------------\n");

    printf(BLUE);
    printf("Test 2: dest = It is dangerous to go alone, src = sorry the princess is a another castle ! \n");
    printf(RESET);
    printf("test with strcpy: %s \n", strcpy(p3, p4));
    printf("test with ft_strcpy: %s \n", ft_strcpy(p3, p4)); 
    printf("-------------\n");

    printf(BLUE);
    printf("Test 3: dest = '', src =  random string \n");
    printf(RESET);
    printf("test with strcpy: %s \n", strcpy(p5, p6));
    printf("test with ft_strcpy: %s \n", ft_strcpy(p5, p6)); 
    printf("-------------\n");

    //pass the next test 

    while (input == 0)
    {
        char c;
        printf(GREEN);
        printf("print 'y' or 'Y' to pass the next test :");
        printf(RESET);
        scanf(" %c", &c);
        printf("\n"); 
        if (c == 'y' || c == 'Y')
            input = 1;
        else
        {
            printf(RED);
            printf("wrong reponse, try again !\n");
            printf(RESET);
        }
    }
    printf("\n");
    input = 0;

    //3rd Test ft_strcmp

    printf(YELLOW);
    printf("----------------------\n");
    printf("|     ft_strcmp       |\n");
    printf("----------------------\n");
    printf(RESET);

    printf("\n");

    printf(BLUE);
    printf("Test 1 : s1 = The cake is a lie , s2 = The cake is a Lie \n");
    printf(RESET);
    char s1[18] = "The cake is a lie";
    char s2[18] = "The cake is a Lie";
    printf("test with strcmp: \n");
    if (strcmp(s1, s2) > 0) 
        printf("s1 is greater to s2 !\n"); 
    else if (strcmp(s1, s2) < 0)
        printf("s1 is lower to s2 !\n");
    else
        printf("s1 is equal to s2 !\n");

     printf("test with ft_strcmp: \n");
    if (ft_strcmp(s1, s2) > 0) 
        printf("s1 is greater to s2 !\n"); 
    else if (ft_strcmp(s1, s2) < 0)
        printf("s1 is lower to s2 !\n");
    else
        printf("s1 is equal to s2 !\n");

    printf("-----------------\n");



    printf(BLUE);
    printf("Test 2 : s3 = I am error , s4 = I am error \n");
    printf(RESET);
    char s3[11] = "I am error";
    char s4[11] = "I am error";
    printf("test with strcmp: \n");
    if (strcmp(s3, s4) > 0) 
        printf("s3 is greater to s4 !\n"); 
    else if (strcmp(s3, s4) < 0)
        printf("s3 is lower to s4 !\n");
    else
        printf("s3 is equal to s4 !\n");

     printf("test with ft_strcmp: \n");
    if (ft_strcmp(s3, s4) > 0) 
        printf("s3 is greater to s4 !\n"); 
    else if (ft_strcmp(s3, s4) < 0)
        printf("s3 is lower to s4 !\n");
    else
        printf("s3 is equal to s4 !\n");

    printf("-----------------\n");
    

    printf(BLUE);
    printf("Test 3 : s5 = abcdefghijKlmnoprstuvzxz, s6 = abcdefghijklmnopqrstuvwxyz \n");
    printf(RESET);
    char s5[27] = "abcdefghijKlmopqrstuvwxyz";
    char s6[27] = "abcdefghijklmnopqrstuvwxyz";

    printf("test with strcmp: \n");
    if (strcmp(s5, s6) > 0) 
        printf("s5 is greater to s6 !\n"); 
    else if (strcmp(s5, s6) < 0)
        printf("s5 is lower to s6 !\n");
    else
        printf("s5 is equal to s6 !\n");

     printf("test with ft_strcmp: \n");
    if (ft_strcmp(s5, s6) > 0) 
        printf("s5 is greater to s6 !\n"); 
    else if (ft_strcmp(s5, s6) < 0)
        printf("s5 is lower to s6 !\n");
    else
        printf("s5 is equal to s6 !\n");

    printf("-----------------\n");
    

    printf(BLUE);
    printf("Test 4 :  'Te', 'T' \n");
    printf(RESET);
     printf("test with strcmp: \n");
    if (strcmp("Te", "T") > 0) 
        printf(" the first string is the greatest !\n"); 
    else if (strcmp(s5, s6) < 0)
        printf("the second string is the greatest !\n");
    else
        printf("this two strings is equals !\n");

     printf("test with ft_strcmp: \n");
    if (ft_strcmp("Te", "T") > 0) 
        printf("the first string is the greatest!\n"); 
    else if (ft_strcmp("Te", "T") < 0)
        printf("the second string is the greatest !\n");
    else
        printf("this two strings is equals !\n");

    printf("-----------------\n");

    //Pass the next test 

    while (input == 0)
    {
        char c;
        printf(GREEN);
        printf("print 'y' or 'Y' to pass the next test :");
        printf(RESET);
        scanf(" %c", &c);
        printf("\n"); 
        if (c == 'y' || c == 'Y')
            input = 1;
        else
        {
            printf(RED);
            printf("wrong reponse, try again !\n");
            printf(RESET);
        }
    }
    printf("\n");
    input = 0;

    //4th Test ft_strdup

    printf(YELLOW);
    printf("----------------------\n");
    printf("|     ft_strdup      |\n");
    printf("----------------------\n");
    printf(RESET);

    printf("\n");

    printf(BLUE);
    printf("Test 1 : str: Objection !\n");
    printf(RESET); 
    printf("Test with strdup: %s \n", strdup("Objection !"));
    printf("Test with ft_strdup: %s \n", ft_strdup("Objection !"));
    printf("-------------------------\n");
    printf("\n");

    printf(BLUE);
    printf("Test 2 : str: Ceci est une phrase un peu plus longue que celle precedente m'en conviendrais vous !\n");
    printf(RESET);
    printf("Test with strdup: %s \n", strdup("Ceci est une phrase un peu plus longue que celle precedente m'en conviendrais vous !"));
    printf("Test with ft_strdup: %s \n", ft_strdup("Ceci est une phrase un peu plus longue que celle precedente m'en conviendrais vous !"));
    printf("-------------------------\n");
    printf("\n");

    printf(BLUE);
    printf("Test 3: str: &$#@@@!!!!!***** \n");
    printf(RESET);
    printf("Test with strdup: %s \n", strdup("&$#@@@!!!!!*****"));
    printf("Test with ft_strdup: %s \n", ft_strdup("&$#@@@!!!!!*****"));
    printf("-------------------------\n");
    printf("\n");

    //Pass the next quest 

    while (input == 0)
    {
        char c;
        printf(GREEN);
        printf("print 'y' or 'Y' to pass the next test :");
        printf(RESET);
        scanf(" %c", &c);
        printf("\n"); 
        if (c == 'y' || c == 'Y')
            input = 1;
        else 
        {
            printf(RED);
            printf("wrong reponse, try again !\n");
            printf(RESET);
        }
    }
    printf("\n");
    input = 0; 

    //5th Test ft_write

    printf(YELLOW);
    printf("----------------------\n");
    printf("|     ft_write       |\n");
    printf("----------------------\n");
    printf(RESET);

    printf("\n"); 

    printf(BLUE);
    printf("Test with write : \n");
    printf(RESET); 
    write(1, "This is a test !\n", strlen("This is a test !\n"));
    printf("*************\n");
    write(1, "Do a barrel roll!\n", strlen("Do a barrel roll!\n"));
    printf("*************\n");
    write(1, "dsfldsfhlfdkdfsljksdfljsdfkldsjfdsjfklsdfjskdfk;ksldfksdfkds;fkds;fks;fksfsjfkljiejowqeowuoqweui3333\n", 
    strlen("dsfldsfhlfdkdfsljksdfljsdfkldsjfdsjfklsdfjskdfk;ksldfksdfkds;fkds;fks;fksfsjfkljiejowqeowuoqweui3333\n"));
    printf("***************\n");

    char buf[12]; 
    size_t size = 0;
    ssize_t err  = write(-1, buf, size);
    if (err < 0)   
        perror("$Error !\n");
    printf("\n");


    printf(BLUE);
    printf("Test with ft_write: \n");
    printf(RESET);
    ft_write(1, "This is a test !\n", ft_strlen("This is a test !\n"));
    printf("*************\n");
    ft_write(1, "Do a barrel roll!\n", ft_strlen("Do a barrel roll!\n"));
    printf("*************\n");
    ft_write(1, "dsfldsfhlfdkdfsljksdfljsdfkldsjfdsjfklsdfjskdfk;ksldfksdfkds;fkds;fks;fksfsjfkljiejowqeowuoqweui3333\n", 
    ft_strlen("dsfldsfhlfdkdfsljksdfljsdfkldsjfdsjfklsdfjskdfk;ksldfksdfkds;fkds;fks;fksfsjfkljiejowqeowuoqweui3333\n"));
    printf("*************\n");

    ssize_t err2 = ft_write(-1, buf, size);
    if (err2 < 0)
        perror("Error !\n");
    printf("\n");

    //Pass the next quest 

    while (input == 0)
    {
        char c;
        printf(GREEN);
        printf("print 'y' or 'Y' to pass the next test :");
        printf(RESET);
        scanf(" %c", &c);
        printf("\n"); 
        if (c == 'y' || c == 'Y')
            input = 1;
        else
        {
            printf(RED);
            printf("wrong reponse, try again !\n");
            printf(RESET);
        }
    }
    printf("\n");
    input = 0;

    //6th test ft_read

    printf(YELLOW);
    printf("----------------------\n");
    printf("|     ft_read         |\n");
    printf("----------------------\n");
    printf(RESET);

    char* file = "test.txt";

    int fd = open(file, O_RDWR);

    printf(BLUE);
    printf("test with read: \n");
    printf(RESET);

    if (fd == -1)
    {
        perror("\nError Opening File !!\n");
        exit(1);
    }
    else
        printf("\nFile %s opened sucessfully!\n", file);

    char buffer[1024];
    char buffer2[1024];

    int bytesRead = read(fd, buffer, sizeof(buffer));

    if (bytesRead == -1)
    {
        perror("\nERROR READING FILE\n");
        exit(1);
    }

    printf(" read: %d bytes read!\n", bytesRead);
    printf("Files Contents: %s\n", buffer);
    printf("***********\n");
    printf("\n");

    close(fd);

    printf(BLUE);
    printf("test with ft_read \n");
    printf(RESET);

    int fd2 = open(file, O_RDWR);
    if (fd2 == -1)
    {
        perror("\nError Opening File !!\n");
        exit(1);
    }
    else
        printf("\nFile %s opened sucessfully!\n", file);


    int bytesRead2 = ft_read(fd2, buffer2, sizeof(buffer2));

    if(bytesRead2 == -1)
    {
        perror("\nERROR READING FILE\n");
        exit(1);
    }

    printf("ft_read: %d bytes read!\n", bytesRead2);
    printf("Files Contents: %s\n", buffer2);
    printf("***********\n");
    printf("\n");

    close(fd2);

    exit (0);
}