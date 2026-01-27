//Zadanie 3.
//Napisz klasę Student, która będzie przechowywała imię, nazwisko i tablicę ocen.
//• Zaimplementuj właściwość SredniaOcen, która obliczy i zwróci średnią ocen.
//• Dodaj metodę DodajOcene(int ocena), która doda nową ocenę do tablicy.
//• Zaimplementuj konstruktor inicjujący imię i nazwisko studenta.

using System;

namespace Lab2_Zad3
{
    class Student
    {
        private string imie;
        private string nazwisko;
        private int[] oceny;
        private int liczbaOcen = 0;

        public Student(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.oceny = new int[20];
        }

        public void DodajOcene(int ocena)
        {
            if (liczbaOcen < oceny.Length)
            {
                oceny[liczbaOcen] = ocena;
                liczbaOcen++;
                Console.Write($"Pomyślnie dodano ocenę: {ocena} \n");
            }
            else
            {
                Console.WriteLine("Nie można dodać więcej ocen, osiągnięto limit 20 sztuk!");
            }
        }

        public double SredniaOcen
        {
            get
            {
                if (liczbaOcen == 0)
                {
                    return 0;
                }

                double suma = 0;
                for (int i = 0; i < liczbaOcen; i++)
                {
                    suma += oceny[i];
                }

                return suma / liczbaOcen;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student test = new Student("Szymon", "Halerz");
            test.DodajOcene(6);
            test.DodajOcene(5);
            test.DodajOcene(1);

            Console.Write($"Średnia ocen to: {test.SredniaOcen:F2}");
            Console.ReadKey();
        }
    }
}

