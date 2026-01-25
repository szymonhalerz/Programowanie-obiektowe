class Zadanie1
{
    /// <summary>
    /// 1. Napisz program obliczający wyróżnik delta i pierwiastki trójmianu kwadratowego.
    /// <summary>

    static void RozwiazRownanie(double a, double b, double c)
    {
        if (a != 0)
        {
            double delta = (b * b) - (4 * a * c);
            Console.WriteLine($"Delta = {delta}");

            double x1, x2, x;

            if (delta > 0)
            {
                x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"Pierwiastki trójmianu kwadratowego to: {x1} oraz {x2}.");
            }
            else if (delta == 0)
            {
                x = -b / (2 * a);
                Console.WriteLine($"Pierwiastek trójmianu kwadratowego to: {x}.");
            }
            else
            {
                Console.WriteLine("Równanie kwadratowe nie ma rozwiązań.");
            }
        }
        else
        {
            Console.WriteLine("a = 0, mamy tutaj sprzeczność!");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Podaj a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Podaj b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Podaj c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        RozwiazRownanie(a, b, c);
    }
}