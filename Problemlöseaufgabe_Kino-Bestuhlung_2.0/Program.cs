using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problemlöseaufgabe_Kino_Bestuhlung_2._0
{

    internal class Program
    {
        static int chairs = 0;         // Anzahl der Stühle
        static int firstRow = 1;       // Anzahl der Stühle in erster Reihe
        static int row = 0;            // Zwei Funktionen: 1. Soll Anzahl der Stühl in aktueller Reihe zeigen; 2. Wir später zur Reihenanzahl umgerechnet

        static void Main(string[] args)
        {
            anzahlStuehleAbfrage("Für wieviele Stühle sollen die Aufstellungen berechnet werden?");

            Console.Clear();
            Console.WriteLine("Mit " + chairs + " Stühle sind folgende Anordungen möglich, sodass kein Stuhl übrig bleibt: \r\n");
            Console.WriteLine("Reihen\t\tStühle in erster Reihe");

            werteBerechnenAusgeben();

            Console.WriteLine("");
            Console.WriteLine("Schreibe q zum Beenden");

            programmBeenden();
        }


        static void programmBeenden()
        {
            string tmp = null;
            do // input Abfrage
            {
                tmp = Console.ReadLine();
                tmp = tmp.ToLower();

                if (tmp == "q" || tmp == "exit" || tmp == "quit")
                {
                    return;
                }

            } while (true);
        }

        static void anzahlStuehleAbfrage(string txt)
        {
            Console.WriteLine(txt);
            do
            {
                try
                {
                    chairs = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    // Hier steht kein Befehl, weil wenn chairs nicht gesetzt wird (also chairs = 0), dann wird auch die Fehlermeldung ausgegeben
                }

                if (chairs <= 0)
                {
                    Console.WriteLine("Gebe einen integer Wert an, der größer als 0 ist. \r\nDer Wert muss ohne Punkte, Lehrzeichen, oder sonstigen Zeichen angegeben werden!");
                }
                if (chairs > 1000000)
                {
                    Console.WriteLine("Der Wert muss kleiner als 1.000.000 sein!");
                }
            } while (chairs <= 0);

        }

        static void werteBerechnenAusgeben()
        {
            while (firstRow < chairs)      // Läuft so oft durch, wie es Stühle gibt; (An dieser Stelle könnte man wahrscheinlich die Geschwindigkeit des Programmes verbessern, indem man die Anzahl der Durchgänge auf die nötige Anzahl verringert.)
            {
                int usedChairs = 0;
                row = firstRow;
                while (usedChairs < chairs)      // Bis alles Stühle benutzt werden
                {
                    usedChairs += row;      // Zur aktuellen Stuhlanzahl wird jeweils die nächste Reihe (um eins höher) hinzugefügt
                    row++;
                }

                if (usedChairs == chairs)    // Wenn alle Stühle verwendet wurden
                {
                    row -= firstRow;   // rowCounter speichert zuvor den Wert der größten Reihe
                    Console.WriteLine(row + "\t\t" + firstRow);
                }

                firstRow++;
            }
        }
    }

}
