def MY_MACRO():
    #This program will print its own source code
    a = 0
    a = 'def MY_MACRO():\n    #This program will print its own source code\n    a = 0\n    a = %r\n    with open("Grace_kid.py", "w") as f:\n        print(a%%a, file= f, end="")\n\nif __name__ == "__main__":\n    MY_MACRO()'
    with open("Grace_kid.py", "w") as f:
        print(a%a, file= f, end="")

if __name__ == "__main__":
    MY_MACRO()