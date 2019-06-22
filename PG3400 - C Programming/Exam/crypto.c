#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <pthread.h>
#include <unistd.h>
#include <crypt.h>
#include <sys/random.h>

#include "inc/crypto.h"
#include "inc/io.h"
#include "inc/alphabet.h"
#include "inc/dictionary.h"


bool solvedDictionary = false;
bool solvedAlphabet = false;

char* getSalt(char* hash) {
	char* salt = malloc(12 * sizeof(char));
	int index = 0;

	while (index < 12) {
		salt[index] = hash[index];
		index ++;
	}

	return salt;
}

void runDictionaryCode(bool skipDictionary, char* lookingFor, char* lookingSalt) {
	if (skipDictionary != true) {
		Map dictionary = loadMap("dictionary.txt");

		int dict_thread_count = 500;
		int dict_thread_chunks = dictionary.lines / dict_thread_count;
		int dict_thread_bonus = dictionary.lines - dict_thread_chunks * dict_thread_count;

		pthread_t dict_threads[dict_thread_count];
		Dictionary dict_thread_data[dict_thread_count];
		int dict_thread_index = 0;

		for (int start = 0, end = dict_thread_chunks; start < dictionary.lines; start = end, end = start + dict_thread_chunks) {
			if (dict_thread_bonus) {
				end ++;
				dict_thread_bonus --;
			}

			Dictionary node;

			node.start = start;
			node.end = end;

			node.lookFor = lookingFor;
			node.lookSalt = lookingSalt;
			node.hay = dictionary.contents;

			if (dict_thread_index == (dict_thread_count - 1)) {
				node.end = (end - 1);
			}

			dict_thread_data[dict_thread_index] = node;

			pthread_create(&dict_threads[dict_thread_index], NULL, processDictionary, (void*) &dict_thread_data[dict_thread_index]);
			dict_thread_index += 1;
		}

		for (int i = 0; i < dict_thread_count; i++) {
			pthread_join(dict_threads[i], NULL);
		}

		closeMap(dictionary);

		if (solvedDictionary == true) {
			free(lookingSalt);
			exit(0);
		}
	}
}

void runAlphabeticCode(int alphabet_length, char* lookingFor, char* lookingSalt) {
	pthread_t alphabet_threads[alphabet_length];
	AlphabeticHash alphabet_thread_data[alphabet_length];

	int alphabet_thread_type = 0;
	for (int i = 0; i < alphabet_length; i++) {
		AlphabeticHash node;

		//node.length = i + 1;
		node.length = alphabet_length;
		node.goal = lookingFor;
		node.salt = lookingSalt;
		node.alphabetIndex = alphabet_thread_type;

		alphabet_thread_data[i] = node;

		pthread_create(&alphabet_threads[i], NULL, processAlphabet, (void*) &alphabet_thread_data[i]);

		alphabet_thread_type += 1;
		if (alphabet_thread_type > 6) {
			alphabet_thread_type = 0;
		}
	}

	for (int i = 0; i < alphabet_length; i++) {
		pthread_join(alphabet_threads[i], NULL);
	}
}

int main(int argc, char** argv)
{
	if (argc < 2) {
		printf("\nSyntax: ./crypto '[hash]' [dictionary] [password length]\n");
		return 1;
	}

	char* lookingFor = argv[1];
	char* lookingSalt;

	// Crypt gen
	if (strcmp(lookingFor, "gen") == 0) {
		if (argc < 3) {
			printf("ERROR: Generator requires a password to generate a hash of.\n");
			return -1;
		}
		char salt[13] = "$1$abcdefgh$";
		getrandom(salt + 3, 8, 0);
		for (unsigned int i = 3; i < 11; i++) {
			salt[i] = CHARS_ALL[salt[i] & 0x3f];
		}
		char* pwd = crypt(argv[2], salt);

		printf("Hash: %s\n", pwd);
		printf("Salt: %s\n", salt);

		return 0;
	}

	if (strlen(lookingFor) < 34 || strlen(lookingFor) > 34) {
		printf("\nERROR: Hash must be exactly 34 characters long.\n");
		return 2;
	}

	char* salt = getSalt(lookingFor);
	lookingSalt = (char*)malloc(12 * sizeof(char));
	memcpy(lookingSalt, salt,12 * sizeof(char));
	free(salt);

	printf("\nSearching for hash: %s\n", lookingFor);
	//printf("Salt is: %s\n", lookingSalt);

	bool skipDictionary = true;
	char* dictFile;
	if (argc >= 3) {
		if (access(argv[2], F_OK) == -1) {
			//printf("ERROR: Dictionary file does not exist. Skipping.\n");
		} else {
			dictFile = argv[2];
			skipDictionary = false;
			printf("\nSearching dictionary: %s\n", dictFile);
		}
	} else {
		printf("No dictionary was given, alphabetical guessing will start.\n");
	}

	runDictionaryCode(skipDictionary, lookingFor, lookingSalt);

	int givenSize = 0;
	if (argc >= 4) {
		givenSize = strtol(argv[3], NULL, 10);
	}

	int alphabet_length = 6;
	if (givenSize > 0) {
		printf("Maximum length of password set to %d.\n", givenSize);
		alphabet_length = givenSize;
	}

	runAlphabeticCode(alphabet_length, lookingFor, lookingSalt);

	free(lookingSalt);

	return 0;
}