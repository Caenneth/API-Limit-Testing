using System.IO;
using System.ComponentModel;
using System.Diagnostics;
public class Graph {
    public static void CreateGraph(string timestamp) 
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = @"C:\Python310\python.exe"; // Pfad zur Python-Installation
        start.Arguments = string.Format("{0} {1}", "./source/graph/graphic.py", timestamp); // Pfad zur Python-Datei und Zeitstempel
        start.UseShellExecute = false; // Wenn true, verwendet das Betriebssystem die Shell zum Starten des Prozesses
        start.RedirectStandardOutput = true; // Wenn true, wird die Standardausgabe des Prozesses an Process.StandardOutput weitergeleitet
        using(Process process = Process.Start(start))
            {
            using(StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.Write(result);
            }
        }
    }          
}