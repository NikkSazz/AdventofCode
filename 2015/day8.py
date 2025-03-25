import time

print("\nAdvent of Code 2015, Day EIGHT\n")

start_time = time.time()

with open('2015/Inputs/8.txt', 'r') as file:
    strings = [l.strip() for l in file]

# Test
strings = {
    #"\"\"",
    #"\"abc\"",
    #"\"aaa\\\"aaa\"",
    "\"\\x27\""
}

def convertToASCII(s, i):
    print(f"converted {s[i+1:i+4]} to ascii")
    return 'J'

def memory(s):
    mem = ""
    i = 0
    while i < len(s):
        print(i)
        if s[i] == '"':
            i+=1
            continue
        elif s[i] == '\\':
            if len(s) > i + 3 and s[i+1] == 'x':
                char = convertToASCII(s,i)
                i+=4 # [\xAB]
                mem+=char
                print(f"{s[i]}, {i}, {i-4}")
                continue
        else:
            print(f"Adding {s[i]}")
            mem += s[i]
        i+=1
        # print(s[i])
    print(f"mem -> {mem}")
    return mem

totalLiteral = 0
totalMemory = 0
for string in strings:
    totalLiteral += len(string)
    print(string)
    thisLen = len(memory(string))
    print(f"{len(string)} <- Literal\n{thisLen} <- Memory\n")

partOne = totalLiteral - totalMemory

print(f"\nPart One: {partOne}")
print(f"Part Two: {-1}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
