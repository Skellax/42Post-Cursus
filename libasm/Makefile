# **************************************************************************** #
#                                                                              #
#                                                         :::      ::::::::    #
#    Makefile                                           :+:      :+:    :+:    #
#                                                     +:+ +:+         +:+      #
#    By: mfuhrman <mfuhrman@student.42.fr>          +#+  +:+       +#+         #
#                                                 +#+#+#+#+#+   +#+            #
#    Created: 2024/02/26 14:37:16 by mfuhrman          #+#    #+#              #
#    Updated: 2024/03/13 09:06:50 by mfuhrman         ###   ########.fr        #
#                                                                              #
# **************************************************************************** #

SRCS = ft_strcmp.s \
       ft_strcpy.s \
       ft_strlen.s \
	   ft_read.s \
	   ft_write.s \
	   ft_strdup.s

OBJS = $(SRCS:.s=.o)

LIB_FLAG = nasm -g -f elf64

NAME = libasm.a

FLAGS = -Wall -Wextra -Werror

all: $(NAME)

%.o: %.s
	@$(LIB_FLAG) $< -o $@

$(NAME): $(OBJS)
	@ar -rc $(NAME) $(OBJS)
	@echo "$(NAME) was created !"

clean:
	@rm -rf $(OBJS)
	@rm -rf test.o

fclean: clean
	@rm -rf $(NAME)
	@echo "$(NAME) was deleted !"
	@rm -rf test 
	@echo "test was deleted !"

test: $(NAME) $(OBJS)
	@clang  -o test test.c $(NAME) -lc 
	@sleep 1
	@./test

re: fclean all

.PHONY: all clean fclean re test