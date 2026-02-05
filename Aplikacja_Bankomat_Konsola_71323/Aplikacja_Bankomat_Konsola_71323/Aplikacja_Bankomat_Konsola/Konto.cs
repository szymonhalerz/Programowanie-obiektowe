using System;

public class Konto
{
    public int Id;
    public int IdKlienta;
    public decimal Saldo;

    public Konto()
    {
        Id = 0;
        IdKlienta = 0;
        Saldo = 0;
    }

    public Konto(int id, int idKlienta, decimal saldo)
    {
        Id = id;
        IdKlienta = idKlienta;
        Saldo = saldo;
    }

    public string DoLinii()
    {
        return Id + " " + IdKlienta + " " + Saldo;
    }

    public static Konto ZLinii(string linia)
    {
        string[] c = linia.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (c.Length < 3) return null;

        int id;
        int idKlienta;
        decimal saldo;

        if (!int.TryParse(c[0], out id)) return null;
        if (!int.TryParse(c[1], out idKlienta)) return null;
        if (!decimal.TryParse(c[2], out saldo)) return null;

        return new Konto(id, idKlienta, saldo);
    }
}
