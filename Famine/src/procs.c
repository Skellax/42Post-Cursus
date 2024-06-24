#include "apocalypse.h"

#define PID_MIN 1
#define PID_MAX 4194304

#ifndef _NSIG
# define _NSIG 255
#endif

static int process_is_running(const char **processes, size_t count);
static void signal_silencer(int sig);

void setup_emergency(void)
{
    if (ptrace(PTRACE_TRACEME, 0, NULL, 0) == -1)
        exit(0);

    for (unsigned char sig = 0; sig < _NSIG; sig++)
        signal(sig, signal_silencer);

    if (process_is_running(PROCESS_AVOID, PROCESS_COUNT) == TRUE)
        exit(0);
}

static
int process_is_running(const char **processes, size_t count)
{
    if (!count || !processes)
        return FALSE;
    DIR* dir = opendir("/proc");
    if (!dir)
        return FALSE;

    char dump_char;
    char name[100];
    struct dirent* entry;
    FILE* file;
    while ((entry = readdir(dir)))
    {
        long pid = atol(entry->d_name);
        if (pid < PID_MIN || pid > PID_MAX)
            continue;
        sprintf(name, "/proc/%lu/stat", pid);

        if (!(file = fopen(name, "r")))
            continue;
        if ((fscanf(file, "%ld (%[^)]) %c", &pid, name, &dump_char)) == 3)
        {
            for (size_t i = 0; i < count; ++i)
                if (!strcmp(name, processes[i]))
                {
                    fclose(file);
                    closedir(dir);
                    return TRUE;
                }
        }
        fclose(file);
    }
    closedir(dir);
    return FALSE;
}

void signal_silencer(int sig)
{
    (void) sig;
    exit(0);
}
