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

def lookAndSay(res):
    result = []
    copy = res[0]
    copies = 1
    for c in res[1:]:
        if copy == c:
            copies+=1
        else:
            result.append(str(copies) + copy)
            copy = c
            copies = 1
    result.append(str(copies) + copy)
    return ''.join(result)

result = input
for i in range(50):
    print(f"Iterating {i+1}")
    result = lookAndSay(result)
    if i == 39:
        partOne = len(result)

partTwo = len(result)

print(f"Part One: {partOne}")
print(f"Part Two: {partTwo}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")
