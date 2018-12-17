#include "a2.h"

List2D readFile(char* fileName, int size) {
    FILE *fp = fopen(fileName, "rb");
    
    List2D arr = initList2D(30, size);

    if (fp != NULL) {
        char currL[30];
        for (int i = 0; i < 30; i++) {
            fgets(currL, 31, fp);
            strcpy(arr.array[i], currL);
        }
        fclose(fp);
    }

    return arr;
}