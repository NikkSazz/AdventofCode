import time
import re

print("\nAdvent of Code 2015, Day SEVEN")

start_time = time.time()

with open('2015/Inputs/7.txt', 'r') as file:
    lines = file.readlines()

# Test
lines = [
"123 -> x",
"456 -> y",
"x AND y -> d",
"x OR y -> e",
"x LSHIFT 2 -> f",
"y RSHIFT 2 -> g",
"NOT x -> h",
"NOT y -> i"
]

wires = { }

def emulate(input, out):
    print(input)
    print(out)
    if input.isdigit():
        print(f"{input} is digit")
    elif input.startswith("NOT "):
        print(f"{input} starts with NOT ")
    else:
        ...

for line in lines:
    match = re.match(r"(.*) -> (\w+)", line)
    emulate(match.group(1), match.group(2))


print(f"Part One: {0}")
print(f"Part Two: {0}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")