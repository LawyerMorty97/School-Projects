#include "a2.h"

void printFigure(char* figureName, int sectionCount, int partCount) {
	Node figure = initNode(sectionCount, sizeof(Group));
	for (int section = 0; section < sectionCount; section++) {
		Group group = initGroup(partCount, sizeof(List2D));
		for (int part = 0; part < partCount; part++) {
			
			char file[30];
			sprintf(file, "%s/part_%d_%d_%s.txt", figureName, part, section, figureName);

			List2D list = readFile(file, 30);
			group = addList2DToGroup(list, group);
		}
		group = mergeGroup(group);
		figure = addItemToNode(group, figure);
	}

	printNode(figure);
	freeNode(figure);
}

int main(int argc, char *argv[]) {
	if (argc < 2) {
		printf("Please enter a figure you wish to draw ('mickey' or 'wolf').\n");
		exit(0);
	}
	char* figure = argv[1];

	int sections = 0;
	int parts = 0;
	int found = 0;
	if (strcmp(figure, "mickey") == 0) {
		sections = 2;
		parts = 3;
		found = 1;
	}
	else if (strcmp(figure, "wolf") == 0) {
		sections = 5;
		parts = 3;
		found = 1;
	}
	
	if (found == 1) {
		printFigure(figure, sections, parts);
	}
	
	return 1;
}