import time
import hashlib

# Testcases:
# puzzleInput = "abcdef"
# puzzleInput = "pqrstuv"
puzzleInput = "bgvyzdsv" # place your input here

start_time = time.time()
print("\nAdvent of Code 2015, Day FOUR\n")

def find_lowest_number(key):
    number = 1
    partOne = -1
    while(True):  # Loop from 0 to 100
        test = puzzleInput + str(number)
        md5_hash_hex = hashlib.md5(test.encode()).hexdigest()
        print(f"\rChecking: {number}\t\t{md5_hash_hex}", end="")  # Use '\r' to overwrite the same line
        if(md5_hash_hex.startswith("00000")):
            if(md5_hash_hex.startswith("000000")):
                print(f"\nHash part Two: {md5_hash_hex}\n")
                return [partOne, number]
            elif(partOne == -1):
                partOne = number
                print(f"\nHash part One: {md5_hash_hex}\n")
        number+=1

solution = find_lowest_number(puzzleInput)
print(f"Part One: {solution[0]}")
print(f"Part Two: {solution[1]}")

elapsed_time = time.time() - start_time
print(f"\nElapsed time: {elapsed_time:.2f} seconds\n")
