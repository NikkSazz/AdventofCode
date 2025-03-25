import time

print("\nAdvent of Code 2015, Day EIGHT\n")

start_time = time.time()

with open('2015/Inputs/8.txt', 'r') as file:
    strings = [l.strip() for l in file]

def convertToASCII(s, i):
    #print(s[i+1:i+4])
    hexVal = s[i+2:i+4].upper()
    #print(hexVal)
    ascii = bytes.fromhex(hexVal).decode('latin-1')
    #print(f"converted {s[i+1:i+4]} to ascii {ascii}")
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
            elif len(s) > i + 1 and s[i+1] == '\\': # \"
                mem += "\\"
                i+=2
                continue
        mem += s[i]
        i+=1
        # print(s[i])
    #print(f"mem -> {mem}")
    return mem

def encodeLen(s):
    count = 2 # outer ""
    for c in s:
        if c=='"' or c=='\\':
            count+=1
        count+=1
    #print(f"{len(s)} <- Literal\n{count} <- Extended\n")
    return count

totalLiteral = 0
totalMemory = 0
partTwo = 0
for string in strings:
    totalLiteral+=len(string)
    print(string)
    thisMem = len(memory(string))
    #print(f"{len(string)} <- Literal\n{thisMem} <- Memory\n")
    totalMemory+=thisMem
    # pt2
    partTwo+=encodeLen(string)
    partTwo-=len(string)

partOne = totalLiteral - totalMemory

print(f"\nPart One: {partOne}")
print(f"Part Two: {partTwo}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
