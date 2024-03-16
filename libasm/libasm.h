/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   libasm.h                                           :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: mfuhrman <mfuhrman@student.42.fr>          +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2024/02/23 12:35:12 by mfuhrman          #+#    #+#             */
/*   Updated: 2024/03/13 09:38:13 by mfuhrman         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */



#ifndef LIBASM_H
# define LIBASM_H

//COLORS

#define BLACK "\033[0;30m"
#define RED "\033[0;31m"
#define BLUE "\033[0;34m"
#define YELLOW "\033[0;33m"
#define GREEN "\033[0;32m"
#define RESET "\033[0m"

//LIBRAIRIES
#include <unistd.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <sys/errno.h>
#include <fcntl.h>

//FUNCTIONS
size_t ft_strlen(char *s);
char * ft_strcpy(char *dest, const char *src);
int ft_strcmp(char *s1, char *s2);
ssize_t ft_write(int fd, void *buf, size_t count);
ssize_t ft_read(int fd, void *buf, size_t count);
char * ft_strdup(char *s);

#endif

