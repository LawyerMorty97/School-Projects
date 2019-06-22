Decisions Made:

From the start of this exam project my goal was to pursue making a multi-threaded solution from the start. I wanted to see how fast it was to parse through a list of over a million different
passwords. I had decided to start with the multithreading part at once because I felt like it would be a challenge that would help me learn more and gain some experience with it.

Each part of the program is split into it's own respective file (dictionary reading inside dictionary.c and alphabet reading inside alphabet.c) and i've tried to make it as neat and clean as possible.

I also included a password generator for the sake of making it easier to test the cracker.

How to run generator:
./crypto gen [password]
Example: ./crypto gen 2013

How to run:
./crypto '[hash]' [dictionary file or random text] [length of random string]
Example 1: ./crypto '$1$9779ofJE$jciF3K3Ai6ToQEPayXPTE/' dictionaryH.txt 5 (This will start with a dictionary search)
./crypto '$1$9779ofJE$jciF3K3Ai6ToQEPayXPTE/' - 5 (This will skip the dictionary search)


How to compile:

I have provided a makefile with my project which can be run by just typing in 'make' in the Terminal window. Alternatively compilation can be done manually through GCC.

"gcc alphabet.c crypto.c dictionary.c io.c -o crypto -Wall -lcrypt -lpthread"
