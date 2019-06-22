#ifndef _GNU_SOURCE
    #define _GNU_SOURCE
#endif

#ifndef _XOPEN_SOURCE
    #define _XOPEN_SOURCE
#endif

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <crypt.h>
#include <string.h>
#include <pthread.h>

#include "inc/crypto.h"
#include "inc/io.h"
#include "inc/dictionary.h"

void* processDictionary(void* arguments) {
    Dictionary* node = (Dictionary*) arguments;

    int start = node->start;
    int end = node->end;
    
    char* hash = node->lookFor;
    char* salt = node->lookSalt;
    char** passwords = node->hay;

    struct crypt_data cdata;
    cdata.initialized = 0;

    for (int i = start; i < end; i++) {
        if (solvedDictionary == true) {
            break;
        }
        char* pwd = passwords[i];
        char* enc = crypt_r(pwd, salt, &cdata);

        if (strcmp(hash, enc) == 0) {
            printf("Found password: %s\n", pwd);
            solvedDictionary = true;
            //free(pwd);
            break;
        }
        //free(pwd);
    }

    for (int i = start; i < (end - 1); i++) {
        free(passwords[i]);
        passwords[i] = NULL;
    }

    pthread_exit(NULL);
}