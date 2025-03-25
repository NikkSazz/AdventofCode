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


def memoryLen(s):
    return 1

totalLiteral = 0
totalMemory = 0
for string in strings:
    totalLiteral += len(string)
    print(string)
    thisLen = memoryLen(string)
    print(f"{len(string)} <- Literal\n{thisLen} <- Memory\n")

partOne = totalLiteral - totalMemory

print(f"\nPart One: {partOne}")
print(f"Part Two: {-1}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
