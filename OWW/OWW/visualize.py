import matplotlib.pyplot as plt

def read_coordinates(file_name):
    with open(file_name, 'r') as f:
        coordinates = [tuple(map(int, line.split())) for line in f]
    return coordinates

def read_tsp_sequence(file_name):
    with open(file_name, 'r') as f:
        sequence = list(map(int, f.readline().split()))
    return sequence

coordinates = read_coordinates('input.txt')
sequence = read_tsp_sequence('output.txt')

plt.scatter(*zip(*coordinates), color='blue')

for i in range(len(sequence) - 1):
    start = coordinates[sequence[i]]
    end = coordinates[sequence[i+1]]
    plt.annotate("", xy=end, xytext=start, arrowprops=dict(arrowstyle="->", color='red'))

for i, (x, y) in enumerate(coordinates):
    plt.text(x+1, y+1, str(i), color="black", fontsize=12)

plt.show()