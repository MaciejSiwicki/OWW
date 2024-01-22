import matplotlib.pyplot as plt
import numpy as np

with open("output_time.txt", "r") as f:
    lines = f.readlines()


data1 = [float(line.split()[0].replace(",", ".")) for line in lines]
data2 = [float(line.split()[1].replace(",", ".")) for line in lines]

ratio = [d1 / d2 for d1, d2 in zip(data1, data2)]

x = np.arange(len(ratio)) + 10

fig, ax = plt.subplots()

points = ax.plot(x, ratio, "o", label="par_time/seq_time")

coefficients = np.polyfit(x, ratio, 2)
poly = np.poly1d(coefficients)

x_fit = np.linspace(x.min(), x.max(), 500)

yfit = poly(x_fit)

ax.plot(x_fit, yfit, "--", color=points[0].get_color())

ax.set_ylabel("Przyspieszenie")
ax.set_xlabel("Liczba miast")
ax.set_xticks(x)

fig.tight_layout()

plt.show()
