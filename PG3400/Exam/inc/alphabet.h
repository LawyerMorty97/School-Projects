#ifndef _ALPHABET_H_
#define _ALPHABET_H_
	extern char CHARS_NUM[];
	extern char CHARS_SPECIAL[];
	extern char CHARS_LOW[];
	extern char CHARS_BIG[];
	extern char CHARS_ALPHABET[];
	extern char CHARS_ALL[];

	typedef struct AlphabeticHash {
		int length;
		char* salt;
		char* goal;
		int alphabetIndex;
	} AlphabeticHash;

	char* getAlphabet(int alphabetIndex);

	void *processAlphabet(void* arguments);
#endif