GREEN = \033[0;32m
RED = \033[0;31m
RESET = \033[0m


SRC_C = Colleen.c
SRC_G = Grace.c
SRC_S = Sully.c

OBJ_C = $(SRC_C:.s=.o)
OBJ_G = $(SRC_G:.s=.o)
OBJ_S = $(SRC_S:.s=.o)
FLAGS = -Wall -Wextra -Werror
COL = Colleen
GRA = Grace
SUL = Sully

all: colleen grace sully

colleen: $(OBJ_C)
	@gcc $(FLAGS) $(OBJ_C) -o $(COL)
	@echo "$(GREEN)$(COL) was created!$(RESET)"

grace: $(OBJ_G)
	@gcc $(FLAGS) $(OBJ_G) -o $(GRA) 
	@echo "$(GREEN)$(GRA) was created!$(RESET)"
	@./$(GRA)

sully: $(OBJ_S)
	@gcc $(FLAGS) $(OBJ_S) -o $(SUL)
	@echo "$(GREEN)$(SUL) was created!$(RESET)"
	@./$(SUL)

clean:
	@rm -rf *.o 
	@echo "$(RED) all objects was deleted!$(RESET)"

fclean: clean 
	@rm -rf $(COL)
	@rm -rf tmp_Colleen
	@echo "$(RED) $(COL) was deleted!$(RESET)"
	@rm -rf $(GRA)
	@rm -rf Grace_kid.c
	@echo "$(RED) $(GRA) was deleted!$(REST)"
	@rm -rf $(SUL)
	@rm -rf Sully_*
	@echo "$(RED) $(GRA) was deleted!$(RESET)"

re: fclean all

.PHONY: all collen grace sully clean fclean re 
