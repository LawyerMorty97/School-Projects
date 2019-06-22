#ifndef _DICTIONARY_H_
    #define _DICTIONARY_H_
    typedef struct Dictionary {
        char* lookFor;
        char* lookSalt;
        int start;
        int end;
        char** hay;
    } Dictionary;

    void* processDictionary(void* arguments);
#endif