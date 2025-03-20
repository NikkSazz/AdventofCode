import time

# Testcases:
puzzleInput = "abcdef"
# puzzleInput = "pqrstuv"

# puzzleInput = "bgvyzdsv"

start_time = time.time()
print("\nAdvent of Code 2015, Day FOUR")

def find_lowest_number(key):
    number = 1
    while(True):

        hash_result = md5()

        # Check if the hash starts with five zeroes
        if hash_result.startswith("00000"):
            return number

        number+=1

partOne = find_lowest_number(puzzleInput)
print(f"Part One: {partOne}")
print(f"Part Two: ")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")


def md5():
    return ("0000000000000")
