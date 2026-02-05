using System;

public class KartaMastercard : Karta
{
    public KartaMastercard(int id, string numerKarty, int idKlienta, string pin)
        : base(id, "MASTERCARD", numerKarty, idKlienta, pin)
    {
    }
}
