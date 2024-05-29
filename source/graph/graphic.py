import matplotlib.pyplot as plt
import datetime
import os
import sys

timestamp = sys.argv[1]

# Lese die Datei
with open(f'outputs/output_{timestamp}.txt', 'r', encoding='utf-8') as f:
    lines = f.readlines()

# Extrahiere die Millisekunden
milliseconds = [int(line.split()[-2]) for line in lines if "Dauer der API-Anfrage" in line]

# Erstelle die x-Achse (Gesamtzahl der Aufrufe)
x = list(range(1, len(milliseconds) + 1))

# Erstelle das Diagramm
plt.plot(x, milliseconds)
plt.xlabel('Gesamtzahl der Aufrufe')
plt.ylabel('Millisekunden')
plt.title('Dauer der API-Anfragen')

# Berechne die Gesamtdauer und die durchschnittliche Dauer pro Anfrage
total_duration = sum(milliseconds)
average_duration = total_duration / len(milliseconds)

# Füge die Gesamtdauer und die durchschnittliche Dauer pro Anfrage zum Diagramm hinzu
plt.text(0.01, 0.95, f'Gesamtdauer: {total_duration} ms', transform=plt.gca().transAxes)
plt.text(0.01, 0.90, f'Durchschnittliche Dauer pro Anfrage: {average_duration:.2f} ms', transform=plt.gca().transAxes)

# Erstelle den Unterordner "diagramme", wenn er nicht existiert
if not os.path.exists('diagramme'):
    os.makedirs('diagramme')

# Speichere das Diagramm mit dem aktuellen Zeitstempel
plt.savefig(f'diagramme/graph_{timestamp}.png')

# Initialisieren Sie die maximale Dauer und die entsprechende Zeile
max_duration = 0
max_line = ""

# Initialisieren Sie ein Dictionary, um die Dauer und die entsprechende Zeile zu speichern
durations = {}
top = 5

# Durchlaufen Sie jede Zeile
for i in range(len(lines)):
    # Überprüfen Sie, ob die Zeile die Dauer der API-Anfrage enthält
    if "Dauer der API-Anfrage" in lines[i]:
        # Extrahieren Sie die Dauer in Millisekunden
        duration_ms = int(lines[i].split()[-2])
        test = lines[i-3]
        json = lines[i-2]
        reply = lines[i-1]
        duration = lines[i] 
        # Speichern Sie die Testnummer, die Dauer und die Dauer in Millisekunden als Tuple im Dictionary
        durations[(test, json, reply, duration, duration_ms)] = lines[i]

# Sortieren Sie das Dictionary nach Dauer in Millisekunden in absteigender Reihenfolge
sorted_durations = sorted(durations.items(), key=lambda item: item[0][4], reverse=True)

# Drucken Sie die Top 50 Einträge
for i in range(top):
    test, json, reply, duration, _ = sorted_durations[i][0]
    print(f"{test}{json}{reply}{duration}")

plt.show()

