//4.Napisz program, który w nieskończoność pyta użytkownika o liczby całkowite. Pętla
//nieskończona powinna się zakończyć gdy użytkownik wprowadzi liczbę mniejszą od zera. Do
//opuszczenia pętli nieskończonej użyj instrukcji break. Pętle nieskończoną realizuje się
//następującymi konstrukcjami:
//while (true)
//{ ciało pętli }
//lub
//for(; ;)
// { ciało pętli }

using System;
namespace Zadanie4
{
    public class Program
    {
        static void Main(string[] arr)
        {
            WczytujLiczby();
        }

        public static void WczytujLiczby()
        {
            double liczba = 0;
            for (; ; )
            {
                Console.WriteLine("Podaj liczbę całkowitą (liczba mniejsza od zera kończy program): ");
                liczba = Convert.ToDouble(Console.ReadLine());

                if (liczba < 0)
                {
                    Console.WriteLine("Koniec Imprezy!");
                    break;
                }
            }
        }
    }
}