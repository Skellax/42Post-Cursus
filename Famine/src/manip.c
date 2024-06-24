#include "apocalypse.h"

int convert_from(int val)
{
    return
          ((val >> 24 & 0xFF) << 0)
        | ((val >> 0  & 0xFF) << 8)
        | ((val >> 16 & 0xFF) << 16)
        | ((val >> 8  & 0xFF) << 24);
}

void transform(char* data, const int* table, size_t length)
{
    for (size_t i = 0; i < length / 4; ++i)
    {
        int val = convert_from(table[i]);
        ((int*) data)[i] = val;
    }
}
