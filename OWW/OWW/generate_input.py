import random
import sys

def generate_coordinates(num_points, x_range, y_range):
    return [(random.randint(*x_range), random.randint(*y_range)) for _ in range(num_points)]

coordinates = generate_coordinates(int(sys.argv[1]), (-100, 100), (0, 100))

with open('input.txt', 'w') as f:
    for x, y in coordinates:
        f.write(f"{x} {y}\n")