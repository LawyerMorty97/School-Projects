#ifndef _IO_H_
    #define _IO_H_
    #include <stdio.h>

    typedef struct Map {
        char* filename;
        char* raw;
        char** contents;
        int fileDescriptor;
        int size;
        int lines;
    } Map;

    Map loadMap(char* fileName);
    void closeMap(Map map);

    int getLines(int size, char* contents);
#endif