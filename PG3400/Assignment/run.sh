#!/bin/bash

clear
gcc -Wall -std=c11 arr.c io.c part.c node.c main.c -o a2
./a2 wolf
./a2 mickey