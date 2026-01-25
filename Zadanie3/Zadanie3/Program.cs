using System;

namespace Zadanie3
{
    //3.Napisz program wyświetlający liczby od 20-0, z wyłączeniem liczb{2,6,9,15,19}. Do realizacji
    //zadania wyłączenia użyj instrukcji continue;

    class Program
    {
        static void Main(string[] args)
        {
            WypiszLiczby();
        }

        static void WypiszLiczby()
        {
            for (int i = 20; i >= 0; i--)
            {
                // {2,6,9,15,19}
                if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}