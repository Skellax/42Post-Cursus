import os

def main():
    i = 5
    if (i <= 0):
        return 0
    sul = 'Sully_' + str(i) + '.py'
    a = 0
    a = """import os{b}{b}def main():{b}    i = {i}{b}    if (i <= 0):{b}        return 0{b}    sul = 'Sully_' + str(i) + '.py'{b}    a = 0{b}    a = {c}{c}{c}{a}{c}{c}{c}{b}    i-=1{b}    with open(sul, "w") as f:{b}        print(a.format(a = a,c = chr(34),b = chr(10), i = i), file=f, end=""){b}    os.system("python3 " + sul){b}{b}if __name__ == "__main__":{b}    main()"""
    i-=1
    with open(sul, "w") as f:
        print(a.format(a = a,c = chr(34),b = chr(10), i = i), file=f, end="")
    os.system("python3 " + sul)

if __name__ == "__main__":
    main()