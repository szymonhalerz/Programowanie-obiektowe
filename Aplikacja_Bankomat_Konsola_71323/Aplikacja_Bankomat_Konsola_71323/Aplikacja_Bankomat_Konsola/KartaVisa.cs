using System;

public class KartaVisa : Karta
{
    public KartaVisa(int id, string numerKarty, int idKlienta, string pin)
        : base(id, "VISA", numerKarty, idKlienta, pin)
    {
    }
}
