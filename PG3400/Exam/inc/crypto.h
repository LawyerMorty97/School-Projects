#ifndef _GNU_SOURCE
    #define _GNU_SOURCE
#endif

#ifndef _XOPEN_SOURCE
    #define _XOPEN_SOURCE
#endif

#ifndef _MAIN_H_
    #define _MAIN_H_
    extern bool solvedDictionary;
    extern bool solvedAlphabet;

    char* getSalt(char* hash);

    void runDictionaryCode(bool skipDictionary, char* theHash, char* theSalt);
    void runAlphabeticCode(int size, char* theHash, char* theSalt);
#endif