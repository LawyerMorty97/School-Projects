#include "a2.h"

List2D initList2D(int arrS, int colS) {
	struct List2D array;
	
	char** arr = (char**) malloc(arrS * sizeof(char*));
	for (int i = 0; i < arrS; i++)
		arr[i] = (char*) malloc(colS * sizeof(char));
		
	array.size = arrS;
	array.array = arr;
	
	return array;
}


void freeList2D(List2D arr) {
	for (int i = 0; i < arr.size; i++) {
		free(arr.array[i]);
	}
	free(arr.array);
}

void printList2D(List2D arr) {
	for (int i = 0; i < arr.size; i++) {
		printf("%s\n", arr.array[i]);
	}
}

int mergeList2D(List2D arrA, List2D arrB) {
	if (arrA.size >= arrB.size) {
		//char* line = malloc(90 * sizeof(char));
		for (int i = 0; i < arrA.size; i++) {
			strcat(arrA.array[i], arrB.array[i]);
		}
		arrA.mergeDepth++;
		
		return 1;
	}
	
	return 0;
}