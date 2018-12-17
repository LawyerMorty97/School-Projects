#include "a2.h"

Node initNode(int size, size_t type) {
    struct Node node;

    node.count = 0;
    node.definedSize = size;

    node.children = malloc(size * type);

    return node;
}

Node addItemToNode(Group item, Node node) {
    int newCount = node.count + 1;
    if (newCount > node.definedSize) {
        return node;
    }

    node.children[node.count] = item;
    node.count = newCount;

    return node;
}

void printNode(Node node) {
    for (int i = 0; i < node.count; i++) {
        Group nodeGroup = node.children[i];

        printGroup(nodeGroup);
    }
}

void freeNode(Node node) {
    for (int i = 0; i < node.count; i++) {
        Group part = node.children[i];
        freeGroup(part);
    }

    free(node.children);
}