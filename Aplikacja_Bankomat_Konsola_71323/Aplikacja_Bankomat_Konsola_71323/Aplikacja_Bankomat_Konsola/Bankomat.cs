using System;
using System.Collections.Generic;

public class Bankomat
{
    private List<string> akceptowaneTypy;

    public Bankomat(List<string> typyKart)
    {
        akceptowaneTypy = new List<string>();
        for (int i = 0; i < typyKart.Count; i++)
        {
            akceptowaneTypy.Add(typyKart[i]);
        }
    }

    public bool CzyAkceptowana(Karta karta)
    {
        if (karta == null) return false;

        for (int i = 0; i < akceptowaneTypy.Count; i++)
        {
            if (akceptowaneTypy[i] == karta.Typ)
            {
                return true;
            }
        }

        return false;
    }

    public void WyswietlAkceptowane()
    {
        Console.WriteLine("Bankomat akceptuje karty takiej jak:");
        for (int i = 0; i < akceptowaneTypy.Count; i++)
        {
            Console.WriteLine(" " + akceptowaneTypy[i]);
        }
    }
}
