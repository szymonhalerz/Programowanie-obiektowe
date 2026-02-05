using System;

public class KartaAmericanExpress : Karta
{
    public KartaAmericanExpress(int id, string numerKarty, int idKlienta, string pin)
        : base(id, "AMERICAN_EXPRESS", numerKarty, idKlienta, pin)
    {
    }
}
