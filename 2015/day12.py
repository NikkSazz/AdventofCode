import time
import re # regex

print("\nAdvent of Code 2015, Day TWELVE\n")

start_time = time.time()

with open('2015/Inputs/12.txt', 'r') as file:
    lines = file.readlines()

regex = r"-?\d+" # any digit, could be multiple or negative
numbers = [int(match) for match in re.findall(regex, lines[0])]

def WithinRed():
    return 50

partOne = sum(numbers)
partTwo = partOne - WithinRed()

print(f"\nPart One: {partOne}")
print(f"Part Two: {partTwo}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
