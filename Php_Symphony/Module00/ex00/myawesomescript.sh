#!/bin/bash

curl -s "$1" | grep -o '<a href="[^"]*"' | cut -d '"' -f2 | cut -d '/' -f1-3