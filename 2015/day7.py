import time

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

for line in lines:
    split = line.split(" ")
    for s in split:
        print(s)

print(f"Part One: {0}")
print(f"Part Two: {0}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")