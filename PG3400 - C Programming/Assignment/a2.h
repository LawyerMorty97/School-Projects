#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct List2D {
	int size;
	int mergeDepth;
	char **array;
} List2D;

typedef struct Group {
	int count;
	int definedSize;
	List2D* items;
} Group;

typedef struct Node {
	int count;
	int definedSize;
	Group* children;
} Node;

// io.c
List2D readFile(char* fileName, int size);

// part.c
Group initGroup(int size, size_t type);
Group addList2DToGroup(List2D part, Group list);
void printGroup(Group group);
void freeGroup(Group group);
Group mergeGroup(Group group);

// arr.c
List2D initList2D(int arrS, int colS);
void fetchList2D(List2D arr);
void freeList2D(List2D arr);
void printList2D(List2D arr);
int mergeList2D(List2D arrA, List2D arrB);

// node.c
void printNode(Node node);
void freeNode(Node node);
Node initNode(int size, size_t type);
Node addItemToNode(Group item, Node node);