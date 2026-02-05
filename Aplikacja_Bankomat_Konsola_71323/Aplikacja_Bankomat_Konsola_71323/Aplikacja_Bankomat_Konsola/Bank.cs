using System;
using System.Collections.Generic;
using System.IO;

public class Bank
{
    private List<Klient> klienci;
    private List<Konto> konta;
    private List<Karta> karty;

    private string plikKlienci = "klienci.txt";
    private string plikKonta = "konta.txt";
    private string plikKarty = "karty.txt";

    public Bank()
    {
        klienci = new List<Klient>();
        konta = new List<Konto>();
        karty = new List<Karta>();
    }

    public void WczytajDane()
    {
        klienci.Clear();
        konta.Clear();
        karty.Clear();

        List<string> lk = PlikDanych.WczytajLinie(plikKlienci);
        for (int i = 0; i < lk.Count; i++)
        {
            Klient k = Klient.ZLinii(lk[i]);
            if (k != null) klienci.Add(k);
        }

        List<string> lko = PlikDanych.WczytajLinie(plikKonta);
        for (int i = 0; i < lko.Count; i++)
        {
            Konto k = Konto.ZLinii(lko[i]);
            if (k != null) konta.Add(k);
        }

        List<string> lka = PlikDanych.WczytajLinie(plikKarty);
        for (int i = 0; i < lka.Count; i++)
        {
            Karta k = Karta.ZLinii(lka[i]);
            if (k != null) karty.Add(k);
        }
    }

    public void ZapiszDane()
    {
        List<string> lk = new List<string>();
        for (int i = 0; i < klienci.Count; i++)
        {
            lk.Add(klienci[i].DoLinii());
        }
        PlikDanych.ZapiszLinie(plikKlienci, lk);

        List<string> lko = new List<string>();
        for (int i = 0; i < konta.Count; i++)
        {
            lko.Add(konta[i].DoLinii());
        }
        PlikDanych.ZapiszLinie(plikKonta, lko);

        List<string> lka = new List<string>();
        for (int i = 0; i < karty.Count; i++)
        {
            lka.Add(karty[i].DoLinii());
        }
        PlikDanych.ZapiszLinie(plikKarty, lka);
    }

    public void DodajKlienta(string imie, string nazwisko)
    {
        int id = NoweIdKlienta();
        klienci.Add(new Klient(id, imie, nazwisko));

        int idKonta = NoweIdKonta();
        konta.Add(new Konto(idKonta, id, 0));
    }

    public void WyswietlKlientow()
    {
        if (klienci.Count == 0)
        {
            Console.WriteLine("Brak klientów.");
            return;
        }

        for (int i = 0; i < klienci.Count; i++)
        {
            Console.WriteLine(klienci[i].Id + " | " + klienci[i].Imie + " " + klienci[i].Nazwisko);
        }
    }

    public void EdytujKlienta(int id, string imie, string nazwisko)
    {
        Klient k = ZnajdzKlientaPoId(id);
        if (k == null)
        {
            Console.WriteLine("Nie znaleziono klienta!");
            return;
        }

        k.Imie = imie;
        k.Nazwisko = nazwisko;
    }

    public void UsunKlienta(int id)
    {
        for (int i = karty.Count - 1; i >= 0; i--)
        {
            if (karty[i].IdKlienta == id)
            {
                karty.RemoveAt(i);
            }
        }

        for (int i = konta.Count - 1; i >= 0; i--)
        {
            if (konta[i].IdKlienta == id)
            {
                konta.RemoveAt(i);
            }
        }

        for (int i = 0; i < klienci.Count; i++)
        {
            if (klienci[i].Id == id)
            {
                klienci.RemoveAt(i);
                Console.WriteLine("Usunięto klienta.");
                return;
            }
        }

        Console.WriteLine("Nie znaleziono klienta.");
    }

    public void DodajKarte(int idKlienta, string typ, string numerKarty, string pin)
    {
        Klient k = ZnajdzKlientaPoId(idKlienta);
        if (k == null)
        {
            Console.WriteLine("Nie ma takiego klienta.");
            return;
        }

        if (CzyNumerKartyIstnieje(numerKarty))
        {
            Console.WriteLine("Taki numer karty już istnieje.");
            return;
        }

        int id = NoweIdKarty();
        Karta karta = null;

        if (typ == "VISA") karta = new KartaVisa(id, numerKarty, idKlienta, pin);
        else if (typ == "MASTERCARD") karta = new KartaMastercard(id, numerKarty, idKlienta, pin);
        else if (typ == "VISA_ELECTRON") karta = new KartaVisaElectron(id, numerKarty, idKlienta, pin);
        else if (typ == "AMERICAN_EXPRESS") karta = new KartaAmericanExpress(id, numerKarty, idKlienta, pin);
        else
        {
            Console.WriteLine("Nieznany typ karty!");
            return;
        }

        karty.Add(karta);
        Console.WriteLine("Dodano kartę.");
    }

    public void WyswietlKarty()
    {
        if (karty.Count == 0)
        {
            Console.WriteLine("Brak kart!");
            return;
        }

        for (int i = 0; i < karty.Count; i++)
        {
            Console.WriteLine(karty[i].Id + " | " + karty[i].Typ + " | " + karty[i].NumerKarty + " | klient: " + karty[i].IdKlienta);
        }
    }

    public void UsunKarte(int idKarty)
    {
        for (int i = 0; i < karty.Count; i++)
        {
            if (karty[i].Id == idKarty)
            {
                karty.RemoveAt(i);
                Console.WriteLine("Usunięto kartę.");
                return;
            }
        }

        Console.WriteLine("Nie znaleziono karty!");
    }

    public void ZmienPIN(string numerKarty, string nowyPin)
    {
        Karta k = ZnajdzKartePoNumerze(numerKarty);
        if (k == null)
        {
            Console.WriteLine("Nie znaleziono karty!");
            return;
        }

        k.PIN = nowyPin;
        Console.WriteLine("Zmieniono PIN.");
    }

    public void WyswietlKonta()
    {
        if (konta.Count == 0)
        {
            Console.WriteLine("Brak kont!");
            return;
        }

        for (int i = 0; i < konta.Count; i++)
        {
            Console.WriteLine(konta[i].Id + " | klient: " + konta[i].IdKlienta + " | saldo: " + konta[i].Saldo);
        }
    }

    public void Wplata(int idKonta, decimal kwota)
    {
        Konto k = ZnajdzKontoPoId(idKonta);
        if (k == null)
        {
            Console.WriteLine("Nie znaleziono konta!");
            return;
        }

        if (kwota <= 0)
        {
            Console.WriteLine("Kwota musi być większa od 0!");
            return;
        }

        k.Saldo = k.Saldo + kwota;
        Console.WriteLine("Wpłata wykonana.");
    }


    public Karta ZnajdzKartePoNumerze(string numerKarty)
    {
        for (int i = 0; i < karty.Count; i++)
        {
            if (karty[i].NumerKarty == numerKarty)
            {
                return karty[i];
            }
        }
        return null;
    }

    public bool SprawdzPIN(Karta karta, string pin)
    {
        if (karta == null) return false;
        return karta.PIN == pin;
    }

    public Konto KontoKlienta(int idKlienta)
    {
        for (int i = 0; i < konta.Count; i++)
        {
            if (konta[i].IdKlienta == idKlienta)
            {
                return konta[i];
            }
        }
        return null;
    }

    public bool Wyplata(Konto konto, decimal kwota)
    {
        if (konto == null) return false;
        if (kwota <= 0) return false;
        if (konto.Saldo < kwota) return false;

        konto.Saldo = konto.Saldo - kwota;
        return true;
    }

    private bool CzyNumerKartyIstnieje(string numer)
    {
        for (int i = 0; i < karty.Count; i++)
        {
            if (karty[i].NumerKarty == numer) return true;
        }
        return false;
    }

    private Klient ZnajdzKlientaPoId(int id)
    {
        for (int i = 0; i < klienci.Count; i++)
        {
            if (klienci[i].Id == id) return klienci[i];
        }
        return null;
    }

    private Konto ZnajdzKontoPoId(int id)
    {
        for (int i = 0; i < konta.Count; i++)
        {
            if (konta[i].Id == id) return konta[i];
        }
        return null;
    }

    private int NoweIdKlienta()
    {
        int max = 0;
        for (int i = 0; i < klienci.Count; i++)
        {
            if (klienci[i].Id > max) max = klienci[i].Id;
        }
        return max + 1;
    }

    private int NoweIdKonta()
    {
        int max = 0;
        for (int i = 0; i < konta.Count; i++)
        {
            if (konta[i].Id > max) max = konta[i].Id;
        }
        return max + 1;
    }

    private int NoweIdKarty()
    {
        int max = 0;
        for (int i = 0; i < karty.Count; i++)
        {
            if (karty[i].Id > max) max = karty[i].Id;
        }
        return max + 1;
    }
}
