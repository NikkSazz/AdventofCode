import time

print("Advent of Code 2015, Day ONE")

start_time = time.time()

with open('day1Input.txt', 'r') as file:

    lines = file.readlines()
input_data = lines[0].strip()

level = 0
positionToBasement = -1

for index, char in enumerate(input_data):
    if char ==  '(':
        level += 1
    if char == ')':
        level -= 1
    # print(f"Level: {level}, index {index}")
    # basement
    if positionToBasement == -1 and level < 0:
        positionToBasement = index + 1

print(f"Part One: {level}")
print(f"Part Two: {positionToBasement}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds")