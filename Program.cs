using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso
{
    class Program
    {

        static void Main(string[] args)
        {
            char[,] pálya = new char[10, 10];
            Feltöltés(pálya);
            Console.WriteLine("adja meg mennyi bombát szeretne");
            int bombaszam = int.Parse(Console.ReadLine());
            bombasorsolo(pálya, bombaszam);
            Kirajzoló(pálya, false);
            lepes(pálya);
            Console.ReadKey();
        }

        static void Feltöltés(char[,] pálya)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
            {
                for (int j = 0; j < pálya.GetLength(1); j++)
                {
                    pálya[i, j] = '_';
                }
            }
        }

        static void lepes(char[,] pálya)
        {
            int sor, oszlop;
            do
            {
                Console.Clear();
                Kirajzoló(pálya, false);
                do
                {
                    Console.WriteLine("adja meg a sort");
                    sor = int.Parse(Console.ReadLine());
                } while (sor > 10 || sor <= 0);
                sor--;
                do
                {
                    Console.WriteLine("adja meg az oszlopot");
                    oszlop = int.Parse(Console.ReadLine());
                } while (oszlop > 10 || oszlop <= 0);
                oszlop--;
                if (pálya[sor, oszlop] == 'B')
                {
                    Console.WriteLine("Felrobbantál");
                    Kirajzoló(pálya, true);
                    break;
                }
                int szomszedok = 0;
                if (sor > 0 && pálya[sor - 1, oszlop] == 'B') szomszedok++;
                if (sor > 0 && oszlop > 0 && pálya[sor - 1, oszlop - 1] == 'B') szomszedok++;
                if (sor > 0 && oszlop < 9 && pálya[sor - 1, oszlop + 1] == 'B') szomszedok++;
                if (oszlop > 0 && pálya[sor, oszlop - 1] == 'B') szomszedok++;
                if (oszlop < 9 && pálya[sor, oszlop + 1] == 'B') szomszedok++;
                if (oszlop > 0 && sor < 9 && pálya[sor + 1, oszlop - 1] == 'B') szomszedok++;
                if (sor < 9 && pálya[sor + 1, oszlop] == 'B') szomszedok++;
                if (sor < 9 && oszlop < 9 && pálya[sor + 1, oszlop + 1] == 'B') szomszedok++;
                pálya[sor, oszlop] = Convert.ToChar(szomszedok);

            } while (pálya[sor, oszlop] != 'B');
        }

        static void bombasorsolo(char[,] pálya, int bombaszam)
        {
            Random gép = new Random();
            int sor, oszlop;
            for (int i = 0; i < bombaszam; i++)
            {
                do
                {
                    sor = gép.Next(10);
                    oszlop = gép.Next(10);
                } while (pálya[sor, oszlop] == 'B');
                pálya[sor, oszlop] = 'B';
            }
        }

        static void Kirajzoló(char[,] pálya, bool showbomb)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
            {
                for (int j = 0; j < pálya.GetLength(1); j++)
                {
                    if (showbomb)
                    {
                        Console.Write(pálya[i, j]);
                    }
                    else if (pálya[i, j] == '0' || pálya[i, j] == '1' || pálya[i, j] == '2' || pálya[i, j] == '3' || pálya[i, j] == '4' || pálya[i, j] == '5' || pálya[i, j] == '6' || pálya[i, j] == '7' || pálya[i, j] == '8')
                    {
                        Console.Write(pálya[i, j]);
                    }
                    else
                    {
                        Console.Write('_');
                    }
                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }
    }
}