import time

print("\nAdvent of Code 2015, Day EIGHT\n")

start_time = time.time()

with open('2015/Inputs/8.txt', 'r') as file:
    strings = [l.strip() for l in file]

# Test
strings = {
    "\"\"",
    "\"abc\"",
    "\"aaa\\\"aaa\"",
    "\"\\x27\""
}

def convertToASCII(s, i):
    ascii = bytes.fromhex(s[i+2:i+4]).decode('ascii')
    print(f"converted {s[i+1:i+4]} to ascii {ascii}")
    return ascii


def memory(s):
    mem = ""
    i = 0
    while i < len(s):
        if s[i] == '"': # start or end of string, not \"
            i+=1
            continue
        elif s[i] == '\\':
            if len(s) > i + 3 and s[i+1] == 'x': # hex \xAB
                char = convertToASCII(s,i)
                i+=4 # [\xAB]
                mem+=char
                continue
            elif len(s) > i + 1 and s[i+1] == '"': # \"
                mem += '"'
                i+=2
                continue
        else: # Regular character 
            # print(f"Adding {s[i]}")
            mem += s[i]
        i+=1
        # print(s[i])
    print(f"mem -> {mem}")
    return mem

totalLiteral = 0
totalMemory = 0
for string in strings:
    totalLiteral+=len(string)
    print(string)
    thisMem = len(memory(string))
    print(f"{len(string)} <- Literal\n{thisMem} <- Memory\n")
    totalMemory+=thisMem

partOne = totalLiteral - totalMemory

print(f"\nPart One: {partOne}")
print(f"Part Two: {-1}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
