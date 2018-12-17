CC= gcc
CFLAGS= -Wall -lcrypt -lpthread
DEPS= crypto.h io.h alphabet.h dictionary.h
OBJ= crypto.o io.o alphabet.o dictionary.o

%.o: %.c $(DEPS)
		$(CC) -c -o $@ $< $(CFLAGS)

crypto: $(OBJ)
	$(CC) -o $@ $^ $(CFLAGS)