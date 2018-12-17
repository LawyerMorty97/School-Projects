#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <unistd.h>
#include <sys/types.h>
#include <sys/mman.h>
#include <sys/stat.h>
#include <fcntl.h>

#include "inc/io.h"

int getLines(int size, char* contents) {
    int count = 0;

    for (int i = 0; i < size; i++) {
        if (contents[i] == '\n') {
            count += 1;
        }
    }

    return count;
}

Map loadMap(char* fileName) {
    Map filemap;

    char* raw;
    char** contents;
    struct stat s;
    int size;
    int fd;

    fd = open(fileName, O_RDONLY);
    fstat(fd, &s);
    size = s.st_size;

    raw = (char*) mmap( 0, size, PROT_READ, MAP_PRIVATE, fd, 0);

    int lines = getLines(size, raw);
    contents = (char**) malloc((lines + 1) * sizeof(char*));

    const int maxletters = 60;

    int letters = 0;
    int words = 0;

    char* tempword = (char*) malloc(maxletters * sizeof(char));
    for (int i = 0; i < size; i++) {
        char letter = raw[i];

        if (letter != '\n') {
            letters += 1;

            int word_len = strlen(tempword);
            tempword[word_len] = letter;
            tempword[word_len + 1] = '\0';
        } else {
            contents[words] = (char*) malloc (letters * sizeof(char));

            memcpy(contents[words], tempword, letters);
            memset(tempword, 0, letters);

            letters = 0;
            words += 1;
        }
    }
    free(tempword);

    // Set all data
    filemap.filename = fileName;
    filemap.raw = raw;
    filemap.contents = contents;
    filemap.fileDescriptor = fd;
    filemap.size = size;
    filemap.lines = lines;

    return filemap;
}

void closeMap(Map map) {
    char** contents = map.contents;

    for (int i = 0; i < map.lines; i++) {
        free(contents[i]);
        contents[i] = NULL;
    }
    free(contents);

    munmap(map.raw, map.size);
    close(map.fileDescriptor);
}