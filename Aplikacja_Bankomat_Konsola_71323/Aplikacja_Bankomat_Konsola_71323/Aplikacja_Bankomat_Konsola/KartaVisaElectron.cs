using System;

public class KartaVisaElectron : Karta
{
    public KartaVisaElectron(int id, string numerKarty, int idKlienta, string pin)
        : base(id, "VISA_ELECTRON", numerKarty, idKlienta, pin)
    {
    }
}
