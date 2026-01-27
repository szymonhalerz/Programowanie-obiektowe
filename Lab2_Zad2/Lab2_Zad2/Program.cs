//Zadanie 2.
//Napisz klasę BankAccount, która będzie symulowała konto bankowe.
//• Zaimplementuj właściwości Saldo (publiczne, tylko do odczytu) i Wlasciciel.
//• Dodaj metodę Wplata(decimal kwota), która pozwala na zwiększenie salda, oraz metodę
//Wyplata(decimal kwota), która sprawdzi, czy jest wystarczająca ilość środków, a następnie
//odejmie odpowiednią kwotę.
//• Użyj operatorów dostępu, aby zabezpieczyć saldo przed bezpośrednią modyfikacją.
//Przykład użycia:
//BankAccount konto = new BankAccount("Jan Kowalski", 1000);
//konto.Wplata(500);
//konto.Wyplata(200);
//Console.WriteLine($"Saldo: {konto.Saldo}");

using System;
namespace Lab2_Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount konto = new BankAccount("Jan Kowalski", 1000);
            konto.Wplata(500);
            konto.Wyplata(200);
            Console.WriteLine($"Saldo: {konto.Saldo}");
            Console.WriteLine();
        }
    }

    public class BankAccount
    {
        public string Wlasciciel { get; set; }

        public decimal Saldo { get; private set; }

        public BankAccount(string wlasciciel, decimal saldoPoczatkowe)
        {
            Wlasciciel = wlasciciel;
            Saldo = saldoPoczatkowe;
        }

        public void Wplata(decimal kwota)
        {
            Saldo += kwota;
        }

        public void Wyplata(decimal kwota)
        {
            if (Saldo >= kwota)
            {
                Saldo -= kwota;
            }
            else
            {
                Console.WriteLine("Niewystarczające środki na koncie.");
            }
        }
    }
}