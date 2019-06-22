#include "a2.h"

Group initGroup(int size, size_t type) {
    struct Group group;
    group.count = 0;
    group.definedSize = size;
    
    group.items = malloc(size * type);

    return group;
}

Group addList2DToGroup(List2D array, Group group) {
    int newCount = group.count + 1;
    if (newCount > group.definedSize) {
        return group;
    }

    group.items[group.count] = array;
    group.count = newCount;

    return group;
}

void printGroup(Group group) {
    for (int i = 0; i < group.count; i++) {
        List2D part = group.items[i];
        printList2D(part);
    }
}

void freeGroup(Group group) {
    for (int i = 0; i < group.count; i++) {
        List2D part = group.items[i];
        freeList2D(part);
    }

    free(group.items);
}

Group mergeGroup(Group group) {
    struct Group mergedGroup = initGroup(1, sizeof(Group));

    int rows = group.count * 10;
    int cols = (group.count * 10) * group.count;
    List2D newList = initList2D(rows, cols);

    for (int i = 0; i < rows; i++) {
        strcpy(newList.array[i], group.items[0].array[i]);
        for (int j = 1; j < group.count; j++) {
            strcat(newList.array[i], group.items[j].array[i]);
        }
    }
    mergedGroup = addList2DToGroup(newList, mergedGroup);

    freeGroup(group);

    return mergedGroup;
}