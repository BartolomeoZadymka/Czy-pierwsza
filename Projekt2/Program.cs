using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace Projekt2
{
    class Program
    {

        static bool Przykładowy(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) { return false; }
            else
            {
                for (BigInteger u = 3; u < Num / 2; u += 2)
                {

                    if (Num % u == 0) { return false; }

                }
            }
            return true;
        }
        static bool Przyzwoity(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) { return false; }
            else
            {
                for (BigInteger u = 3; u < Num / u; u += 2)
                {

                    if (Num % u == 0) { return false; }

                }
            }
            return true;
        }
        static bool Optymalny(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) { return false; }
            else
            {
                for (BigInteger u = 3; u < Num / u; u += 2)
                {
                    for (BigInteger i = 2; i < u; i++)
                    {
                        if (u % i == 0)
                            goto koniec;
                    }
                    if (Num % u == 0) { return false; }
                koniec:;
                }
            }
            return true;
        }

        static void Main(string[] args)

        {
            BigInteger[] tab = new BigInteger[8] { 101, 1009, 10091, 100913, 1009139, 10091401, 100914061, 1009140611 };

            Console.ForegroundColor = (ConsoleColor.Red);
            Console.WriteLine("Przykładowy:\n");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Liczba: \t|\tCzyPierwsza? \t|\tCzas(ms) \t|");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Stopwatch czas = Stopwatch.StartNew();
                Przykładowy(tab[i]);
                czas.Stop();
                string x = "|";
                double sekundy = czas.Elapsed.TotalMilliseconds;
                Console.WriteLine(tab[i].ToString().PadRight(16) + x.PadRight(8) + Przykładowy(tab[i]).ToString().PadRight(16) + x.PadRight(8) + sekundy.ToString().PadRight(16) + x);
                Console.WriteLine("-----------------------------------------------------------------");

            }

            Console.WriteLine("");
            Console.ForegroundColor = (ConsoleColor.DarkYellow);
            Console.WriteLine("Przyzwoity");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Liczba: \t|\tCzyPierwsza? \t|\tCzas(ms) \t|");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Stopwatch czas = Stopwatch.StartNew();
                Przyzwoity(tab[i]);
                czas.Stop();
                string x = "|";
                double sekundy = czas.Elapsed.TotalMilliseconds;
                Console.WriteLine(tab[i].ToString().PadRight(16) + x.PadRight(8) + Przyzwoity(tab[i]).ToString().PadRight(16) + x.PadRight(8) + sekundy.ToString().PadRight(16) + x);
                Console.WriteLine("-----------------------------------------------------------------");
            }
            Console.WriteLine("");
            Console.ForegroundColor = (ConsoleColor.Green);
            Console.WriteLine("Optymalny");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Liczba: \t|\tCzyPierwsza? \t|\tCzas(ms) \t|");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Stopwatch czas = Stopwatch.StartNew();
                Optymalny(tab[i]);
                czas.Stop();
                string x = "|";
                double sekundy = czas.Elapsed.TotalMilliseconds;
                Console.WriteLine(tab[i].ToString().PadRight(16) + x.PadRight(8) + Optymalny(tab[i]).ToString().PadRight(16) + x.PadRight(8) + sekundy.ToString().PadRight(16) + x);
                Console.WriteLine("-----------------------------------------------------------------");
            }
            Console.ForegroundColor = (ConsoleColor.Blue);
            Console.WriteLine("\n\n Zakończono działanie programu");
            Console.ReadKey();
        }
    }
}
