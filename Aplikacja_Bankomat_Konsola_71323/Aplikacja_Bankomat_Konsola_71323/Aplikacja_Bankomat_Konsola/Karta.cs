using System;

public class Karta
{
    public int Id;
    public string Typ;
    public string NumerKarty;
    public int IdKlienta;
    public string PIN;

    public Karta()
    {
        Id = 0;
        Typ = "";
        NumerKarty = "";
        IdKlienta = 0;
        PIN = "";
    }

    public Karta(int id, string typ, string numerKarty, int idKlienta, string pin)
    {
        Id = id;
        Typ = typ;
        NumerKarty = numerKarty;
        IdKlienta = idKlienta;
        PIN = pin;
    }

    public virtual string DoLinii()
    {
        return Id + " " + Typ + " " + NumerKarty + " " + IdKlienta + " " + PIN;
    }

    public static Karta ZLinii(string linia)
    {
        string[] c = linia.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (c.Length < 5) return null;

        int id;
        int idKlienta;

        if (!int.TryParse(c[0], out id)) return null;
        string typ = c[1];
        string numer = c[2];
        if (!int.TryParse(c[3], out idKlienta)) return null;
        string pin = c[4];

        if (typ == "VISA") return new KartaVisa(id, numer, idKlienta, pin);
        if (typ == "MASTERCARD") return new KartaMastercard(id, numer, idKlienta, pin);
        if (typ == "VISA_ELECTRON") return new KartaVisaElectron(id, numer, idKlienta, pin);
        if (typ == "AMERICAN_EXPRESS") return new KartaAmericanExpress(id, numer, idKlienta, pin);

        return new Karta(id, typ, numer, idKlienta, pin);
    }
}
