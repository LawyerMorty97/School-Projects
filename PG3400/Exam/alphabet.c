#ifndef _GNU_SOURCE
    #define _GNU_SOURCE
#endif

#ifndef _XOPEN_SOURCE
    #define _XOPEN_SOURCE
#endif

#include <stdio.h>
#include <stdlib.h>
#include <crypt.h>
#include <pthread.h>
#include <stdbool.h>
#include <string.h>

#include "inc/crypto.h"
#include "inc/alphabet.h"

char CHARS_NUM[10] = "1234567890";
char CHARS_SPECIAL[28] = "1234567890+\"#&/()=?!@$|[]{}";
char CHARS_LOW[36] = "abcdefghikjlmnopqrstuvwxyz1234567890";
char CHARS_BIG[36] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
char CHARS_ALPHABET[52] = "abcdefghikjlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
char CHARS_ALL[80] = "abcdefghikjlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+\"#&/()=?!@$|[]{}";

char* getAlphabet(int alphabetIndex) {
    char* alphabet;

    switch(alphabetIndex) {
		case 0:
			alphabet = CHARS_NUM;
			break;
		case 1:
			alphabet = CHARS_LOW;
			break;
		case 2:
			alphabet = CHARS_BIG;
			break;
		case 3:
			alphabet = CHARS_ALPHABET;
			break;
		case 4:
			alphabet = CHARS_SPECIAL;
			break;
		case 5:
			alphabet = CHARS_ALL;
			break;
		default:
			alphabet = CHARS_ALPHABET;
			break;
	}

    return alphabet;
}

void* processAlphabet(void* arguments) {
    AlphabeticHash *hash = (AlphabeticHash*) arguments;

    int len = hash->length;
    char* salt = hash->salt;
    char* goal = hash->goal;
    int alphabetType = hash->alphabetIndex;

    char* characters = getAlphabet(alphabetType);

    char* curr_pwd = malloc(len * sizeof(char));
	char* last_pwd = NULL;
	char* first_occurence = NULL;
	int num_used_pwd = 0;
	bool encrypt = true;
	int last = strlen(characters);

	curr_pwd[num_used_pwd] = characters[0];
	curr_pwd[num_used_pwd + 1] = '\0';

	struct crypt_data cdata;
	cdata.initialized = 0;

	while (num_used_pwd < len) {
		if (solvedAlphabet == true) {
			break;
		};
		last_pwd = &curr_pwd[num_used_pwd];
		while (last_pwd >= curr_pwd) {
			if (solvedAlphabet == true) {
				break;
			};
			if ((first_occurence = strchr(characters, *last_pwd)) != NULL) {
				if (encrypt == true) {

					char* enc = crypt_r(curr_pwd, salt, &cdata);
					if (strcmp(goal, enc) == 0) {
                        printf("Found password: %s\n", curr_pwd);
						solvedAlphabet = true;
						break;
					}
				}

				if (first_occurence < &characters[last]) {
					++first_occurence;
					*last_pwd = *first_occurence;
					if (last_pwd != &curr_pwd[num_used_pwd]) {
						last_pwd = &curr_pwd[num_used_pwd];
					}
					encrypt = true;
				} else {
					*last_pwd = characters[0];
					last_pwd--;
					encrypt = false;
				}
			}
		}
		num_used_pwd++;
		memset(curr_pwd, characters[0], num_used_pwd);
		curr_pwd[num_used_pwd + 1] = '\0';
	}

	free(curr_pwd);

	pthread_exit(NULL);
}