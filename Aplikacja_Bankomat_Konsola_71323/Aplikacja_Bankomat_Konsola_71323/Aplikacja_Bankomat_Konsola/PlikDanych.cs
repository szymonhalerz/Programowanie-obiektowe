using System;
using System.IO;
using System.Collections.Generic;

public class PlikDanych
{
    public static List<string> WczytajLinie(string sciezka)
    {
        List<string> linie = new List<string>();

        if (!File.Exists(sciezka))
        {
            return linie;
        }

        string[] dane = File.ReadAllLines(sciezka);
        for (int i = 0; i < dane.Length; i++)
        {
            if (dane[i] != null && dane[i].Trim() != "")
            {
                linie.Add(dane[i]);
            }
        }

        return linie;
    }

    public static void ZapiszLinie(string sciezka, List<string> linie)
    {
        File.WriteAllLines(sciezka, linie.ToArray());
    }
}
