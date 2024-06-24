NAME    = Pestilence

TARGETS = manip procs folders files main
SRC_DIR = src
OBJ_DIR = obj
INCLUDE = include

CFLAGS  = -Wall -Werror -Wextra -Wunreachable-code -Wpedantic -I$(INCLUDE)
LNFLAGS = -O3 #-fsanitize=address
TESTDIR = /tmp/test /tmp/test2

ALL_OBJ = $(foreach i,$(TARGETS),$(OBJ_DIR)/$(i).o)
all a: $(NAME)

$(NAME): $(ALL_OBJ)
	$(CC) $(LNFLAGS) $^ -o $@
	strip $@

$(OBJ_DIR):
	mkdir $@

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.c | $(OBJ_DIR)
	$(CC) $(CFLAGS) -c $< -o $@

clean c:
	$(RM) -r $(OBJ_DIR)

fclean fc: clean
	$(RM) $(NAME)

remake re: fclean all

prepare p:
	$(RM) -r /tmp/test /tmp/test2
	mkdir -p /tmp/test /tmp/test2
	cp sample/sample.c /tmp/test
	gcc -m64 /tmp/test/sample.c -o /tmp/test/sample
	cp /tmp/test/sample /tmp/test2
	cp /bin/ls /tmp/test2

.PHONY: all clean fclean
