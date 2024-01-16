import matplotlib.pyplot as plt
import numpy as np


with open("output_time_thread.txt", "r") as f:
    lines = f.readlines()


data = [[float(num.replace(",", ".")) for num in line.split()] for line in lines]


x = np.arange(2, 2 + len(data[0]))

fig, ax = plt.subplots()

colors = ["b", "g", "r", "c", "m", "y", "k"]

for i, city_data in enumerate(data, start=8):
    coefficients = np.polyfit(x, np.log(city_data), 1)
    poly = np.poly1d(coefficients)
    yfit = lambda x: np.exp(poly(x))

    points = ax.plot(
        x, city_data, "o", label=f"Liczba miast: {i}", color=colors[i % len(colors)]
    )

    ax.plot(x, yfit(x), "--", color=points[0].get_color(), alpha=0.5)

ax.set_ylabel("Czas [s]")
ax.set_xlabel("Liczba wątków")
ax.legend()

fig.tight_layout()

plt.show()
