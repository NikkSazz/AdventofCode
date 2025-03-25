import time

print("\nAdvent of Code 2015, Day TEN\n")

start_time = time.time()

input = "1113122113"

# Tests
# input = "1"
# input = "11"
# input = "21"
# input = "1211"
# input = "111221"

partOne = 0
partTwo = 0

result = ""
copy = input[0]
copies = 1
for c in input[1:]:
    if copy == c:
        copies+=1
    else:
        result += str(copies) + copy
        copy = c
        copies = 1
result += str(copies) + copy

partOne = int(result)

print(f"\nPart One: {partOne}")
print(f"Part Two: {partTwo}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
