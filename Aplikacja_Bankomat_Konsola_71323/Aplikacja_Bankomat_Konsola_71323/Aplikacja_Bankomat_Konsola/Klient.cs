using System;

public class Klient
{
    public int Id;
    public string Imie;
    public string Nazwisko;

    public Klient()
    {
        Id = 0;
        Imie = "";
        Nazwisko = "";
    }

    public Klient(int id, string imie, string nazwisko)
    {
        Id = id;
        Imie = imie;
        Nazwisko = nazwisko;
    }

    public string DoLinii()
    {
        return Id + " " + Imie + " " + Nazwisko;
    }

    public static Klient ZLinii(string linia)
    {
        string[] c = linia.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (c.Length < 3) return null;

        int id;
        if (!int.TryParse(c[0], out id)) return null;

        return new Klient(id, c[1], c[2]);
    }
}
