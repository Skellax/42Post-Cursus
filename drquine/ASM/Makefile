GREEN = \033[0;32m
RED = \033[0;31m
RESET = \033[0m

SRC_C = Colleen.s
OBJ_C = $(SRC_C:.s=.o)
COL = Colleen

SRC_G = Grace.s
OBJ_G = $(SRC_G:.s=.o)
GRA = Grace

SRC_S = Sully.s
OBJ_S = $(SRC_S:.s=.o)
SUL = Sully

ASFLAGS = -f elf64
LDFLAGS = -lc -dynamic-linker /usr/lib64/ld-linux-x86-64.so.2 --entry main

all: colleen grace sully

%.o: %.s
	@nasm $(ASFLAGS) -o $@ $<

colleen: $(OBJ_C)
	@ld $(LDFLAGS) -o $(COL) $(OBJ_C)
	@echo "$(GREEN)$(COL) was created!$(RESET)"

grace: $(OBJ_G)
	@ld  $(LDFLAGS) -o $(GRA) $(OBJ_G)
	@echo "$(GREEN)$(GRA) was created!$(RESET)"
	@./$(GRA)

sully: $(OBJ_S)
	@ld $(LDFLAGS) -o $(SUL) $(OBJ_S)
	@echo "$(GREEN)$(SUL) was created!$(REST)"
	@./$(SUL)

clean:
	@rm -rf *.o
	@echo "$(RED) all objects was deleted!$(RESET)"

fclean: clean 
	@rm -rf $(COL)
	@rm -rf tmp_Colleen
	@rm -rf Grace_kid.s
	@rm -rf $(GRA)
	@rm -rf Sully_* 
	@rm -rf $(SUL)
	@echo "$(RED) Colleen was deleted!$(RESET)"
	@echo "$(RED) Grace was deleted!$(RESET)"
	@echo "$(RED) Sully was deleted!$(RESET)"

re: fclean all

.PHONY: all collen grace sully clean fclean re 

