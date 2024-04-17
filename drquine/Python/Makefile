GREEN = \033[0;32m
RED = \033[0;31m
RESET = \033[0m

all: colleen sully grace 

colleen:
	@python3 Colleen.py > tmp_colleen
	@echo "$(GREEN)Colleen was launched!$(RESET)"


grace:
	@python3 Grace.py
	@echo "$(GREEN)Grace was launched!$(RESET)"

sully:
	@python3 Sully.py
	@echo "$(GREEN)Sully was launched!$(RESET)"

clean:
	@rm -rf tmp_colleen
	@rm -rf Grace_kid.py
	@rm -rf Sully_*
	@echo "$(RED)All files was deleted!$(RESET)"

re: clean all

.PHONY: all colleen sully grace clean re