import matplotlib.pyplot as plt
import numpy as np

with open("output_time.txt", "r") as f:
    lines = f.readlines()


data1 = [float(line.split()[0].replace(",", ".")) for line in lines]
data2 = [float(line.split()[1].replace(",", ".")) for line in lines]


x = np.arange(len(data1)) + 5


width = 0.35

fig, ax = plt.subplots()


rects1 = ax.bar(x - width / 2, data1, width, label="seq_time")
rects2 = ax.bar(x + width / 2, data2, width, label="par_time")


ax.set_ylabel("Times [s]")
ax.set_xlabel("Number of cities")
ax.set_xticks(x)
ax.legend()

fig.tight_layout()

plt.show()
