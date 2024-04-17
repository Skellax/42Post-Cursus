#This program will print its own source when run
def main():
    #This program will print its own source when run
    a = 0
    a = '#This program will print its own source when run\ndef main():\n    #This program will print its own source when run\n    a = 0\n    a = %r\n    print(a%%a, end="")\n\nif __name__ == "__main__":\n    main()'
    print(a%a, end="")

if __name__ == "__main__":
    main()