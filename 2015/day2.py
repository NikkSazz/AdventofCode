import time

print("\nAdvent of Code 2015, Day TWO")

start_time = time.time()

with open('2.txt', 'r') as file:
    lines = file.readlines()

wrappingPaper = 0
ribbon = 0

for line in lines:
    dimensions = [int(i) for i in line.split('x')]
    l = dimensions[0]
    w = dimensions[1]
    h = dimensions[2]
    sides = [l*w, w*h, h*l]
    surfaceArea = sum(sides) * 2
    # slack = area of the smallest side
    slack = min(sides)
    wrappingPaper += surfaceArea + slack
    # part two- ribbons
    sortedDimensions = sorted(dimensions)
    wrapRibbon = sortedDimensions[0]*2 + sortedDimensions[1]*2
    bow = dimensions[0] * dimensions[1] * dimensions[2]
    ribbon += wrapRibbon + bow

print(f"Part One: {wrappingPaper}")
print(f"Part Two: {ribbon}")

elapsed_time = time.time() - start_time
print(f"Elapsed time: {elapsed_time:.2f} seconds\n")