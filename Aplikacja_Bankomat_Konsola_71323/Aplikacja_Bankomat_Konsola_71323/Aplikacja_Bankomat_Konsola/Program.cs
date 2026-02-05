using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        bank.WczytajDane();

        List<string> typy = KonfigurujAkceptowaneKarty();
        Bankomat bankomat = new Bankomat(typy);

        Console.WriteLine();
        bankomat.WyswietlAkceptowane();
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("WITAMY W BANKOMACIE");
            Console.WriteLine("1 - Użyj bankomatu");
            Console.WriteLine("2 - Panel admin");
            Console.WriteLine("0 - Wyjście");
            int wybor = WczytajInt("Wybierz: ");
            Console.WriteLine();

            if (wybor == 0)
            {
                bank.ZapiszDane();
                break;
            }
            else if (wybor == 1)
            {
                MenuKlienta(bank, bankomat);
            }
            else if (wybor == 2)
            {
                MenuAdmina(bank);
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
            }

            Console.WriteLine();
        }
    }

    static List<string> KonfigurujAkceptowaneKarty()
    {
        List<string> typy = new List<string>();

        Console.WriteLine("Konfiguracja bankomatu - wybierz akceptowane karty (TAK/NIE):");

        if (WczytajTakNie("Akceptować VISA? ")) typy.Add("VISA");
        if (WczytajTakNie("Akceptować MASTERCARD? ")) typy.Add("MASTERCARD");
        if (WczytajTakNie("Akceptować VISA_ELECTRON? ")) typy.Add("VISA_ELECTRON");
        if (WczytajTakNie("Akceptować AMERICAN_EXPRESS? ")) typy.Add("AMERICAN_EXPRESS");

        if (typy.Count == 0)
        {
            Console.WriteLine("Nie wybrano żadnych kart, ustawiam domyslnie VISA.");
            typy.Add("VISA");
        }

        return typy;
    }

    static void MenuKlienta(Bank bank, Bankomat bankomat)
    {
        string numer = WczytajTekst("Włóż kartę - podaj numer karty: ");
        Karta karta = bank.ZnajdzKartePoNumerze(numer);

        if (karta == null)
        {
            Console.WriteLine("Nie ma takiej karty w systemie!");
            return;
        }

        if (!bankomat.CzyAkceptowana(karta))
        {
            Console.WriteLine("Ten bankomat nie akceptuje takiej karty: " + karta.Typ);
            return;
        }

        string pin = WczytajTekst("Podaj PIN: ");
        if (!bank.SprawdzPIN(karta, pin))
        {
            Console.WriteLine("Błędny PIN.");
            return;
        }

        Konto konto = bank.KontoKlienta(karta.IdKlienta);
        if (konto == null)
        {
            Console.WriteLine("Brak konta dla tej karty.");
            return;
        }

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Sprawdź saldo");
            Console.WriteLine("2 - Wypłać gotówkę");
            Console.WriteLine("0 - Zakończ");
            int wybor = WczytajInt("Wybierz: ");
            Console.WriteLine();

            if (wybor == 0)
            {
                bank.ZapiszDane();
                break;
            }
            else if (wybor == 1)
            {
                Console.WriteLine("Saldo: " + konto.Saldo);
            }
            else if (wybor == 2)
            {
                decimal kwota = WczytajDecimal("Kwota wypłaty: ");
                bool ok = bank.Wyplata(konto, kwota);

                if (!ok)
                {
                    Console.WriteLine("Nie udało się wypłacić!");
                }
                else
                {
                    bank.ZapiszDane();
                    Console.WriteLine("Wypłata wykonana.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
        }
    }

    static void MenuAdmina(Bank bank)
    {
        string haslo = WczytajTekst("Hasło admina: ");
        if (haslo != "admin")
        {
            Console.WriteLine("Złe hasło!");
            return;
        }

        while (true)
        {
            Console.WriteLine("PANEL ADMIN-a");
            Console.WriteLine("1 - Dodaj klienta");
            Console.WriteLine("2 - Wyświetl klientów");
            Console.WriteLine("3 - Edytuj klienta");
            Console.WriteLine("4 - Usuń klienta");
            Console.WriteLine("5 - Dodaj kartę klientowi");
            Console.WriteLine("6 - Wyświetl karty");
            Console.WriteLine("7 - Usuń kartę");
            Console.WriteLine("8 - Zmień PIN karty");
            Console.WriteLine("9 - Wyświetl konta");
            Console.WriteLine("10 - Wpłata na konto");
            Console.WriteLine("0 - Powrót");

            int wybor = WczytajInt("Wybierz: ");
            Console.WriteLine();

            if (wybor == 0)
            {
                bank.ZapiszDane();
                break;
            }
            else if (wybor == 1)
            {
                string imie = WczytajTekst("Imię: ");
                string nazwisko = WczytajTekst("Nazwisko: ");
                bank.DodajKlienta(imie, nazwisko);
                bank.ZapiszDane();
                Console.WriteLine("Dodano klienta i jego konta.");
            }
            else if (wybor == 2)
            {
                bank.WyswietlKlientow();
            }
            else if (wybor == 3)
            {
                int id = WczytajInt("Id klienta: ");
                string imie = WczytajTekst("Nowe imię: ");
                string nazwisko = WczytajTekst("Nowe nazwisko: ");
                bank.EdytujKlienta(id, imie, nazwisko);
                bank.ZapiszDane();
            }
            else if (wybor == 4)
            {
                int id = WczytajInt("Id klienta do usunięcia: ");
                bank.UsunKlienta(id);
                bank.ZapiszDane();
            }
            else if (wybor == 5)
            {
                int idKlienta = WczytajInt("Id klienta: ");
                Console.WriteLine("Typy kart: VISA, MASTERCARD, VISA_ELECTRON, AMERICAN_EXPRESS");
                string typ = WczytajTekst("Typ karty: ");
                string numer = WczytajTekst("Numer karty: ");
                string pin = WczytajTekst("PIN: ");
                bank.DodajKarte(idKlienta, typ, numer, pin);
                bank.ZapiszDane();
            }
            else if (wybor == 6)
            {
                bank.WyswietlKarty();
            }
            else if (wybor == 7)
            {
                int idKarty = WczytajInt("Id karty do usunięcia: ");
                bank.UsunKarte(idKarty);
                bank.ZapiszDane();
            }
            else if (wybor == 8)
            {
                string numer = WczytajTekst("Numer karty: ");
                string nowyPin = WczytajTekst("Nowy PIN: ");
                bank.ZmienPIN(numer, nowyPin);
                bank.ZapiszDane();
            }
            else if (wybor == 9)
            {
                bank.WyswietlKonta();
            }
            else if (wybor == 10)
            {
                int idKonta = WczytajInt("Id konta: ");
                decimal kwota = WczytajDecimal("Kwota wpłaty: ");
                bank.Wplata(idKonta, kwota);
                bank.ZapiszDane();
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
            }

            Console.WriteLine();
        }
    }

    static bool WczytajTakNie(string tekst)
    {
        while (true)
        {
            Console.Write(tekst);
            string dane = Console.ReadLine();
            if (dane == null) dane = "";

            dane = dane.Trim().ToUpper();

            if (dane == "TAK" || dane == "T") return true;
            if (dane == "NIE" || dane == "N") return false;

            Console.WriteLine("Wpisz TAK lub NIE.");
        }
    }

    static int WczytajInt(string tekst)
    {
        while (true)
        {
            Console.Write(tekst);
            string dane = Console.ReadLine();

            int liczba;
            if (int.TryParse(dane, out liczba))
            {
                return liczba;
            }
            Console.WriteLine("Błąd: wpisz liczbę całkowitą!");
        }
    }

    static decimal WczytajDecimal(string tekst)
    {
        while (true)
        {
            Console.Write(tekst);
            string dane = Console.ReadLine();

            decimal liczba;
            if (decimal.TryParse(dane, out liczba))
            {
                return liczba;
            }
            Console.WriteLine("Błąd: wpisz liczbę!");
        }
    }

    static string WczytajTekst(string tekst)
    {
        Console.Write(tekst);
        string dane = Console.ReadLine();
        if (dane == null) return "";
        return dane;
    }
}
