using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso_javitott
{
    class Program
    {

        static void Main(string[] args)
        {
            char[,] pálya = new char[12, 12];
            Feltöltés(pálya);
            Bombasorsoló(pálya);
            Kirajzoló(pálya, true);
            int lépx;
            int lépy;
            do
            {
                Lépés(pálya, out lépx, out lépy);
            } while (pálya[lépx, lépy] != 'B');
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

        static void Lépés(char[,] pálya, out int lépx, out int lépy)
        {

            Console.WriteLine("Kérem a sorszámot.");
            lépx = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem az oszlopszámot.");
            lépy = int.Parse(Console.ReadLine());
            if (pálya[lépx, lépy] == 'B')
            {
                Kirajzoló(pálya, true);
                Console.WriteLine("Felrobbantál.");
            }

            else
            {
                pálya[lépx, lépy] = char.Parse(BombaSzomszédSzám(pálya, lépx, lépy).ToString());
                Kirajzoló(pálya, true);
            }
        }

        static void Bombasorsoló(char[,] pálya)
        {
            Random gép = new Random();
            Console.WriteLine("Add meg a bombaszámot.");
            int bombaszám = int.Parse(Console.ReadLine());
            int sor;
            int oszlop;
            for (int i = 0; i < bombaszám; i++)
            {
                do
                {
                    sor = gép.Next(1, 11);
                    oszlop = gép.Next(1, 11);
                } while (pálya[sor, oszlop] == 'B');
                pálya[sor, oszlop] = 'B';
            }
        }

        static void Kirajzoló(char[,] pálya, bool legyenbomba)
        {
            for (int i = 1; i < pálya.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < pálya.GetLength(1) - 1; j++)
                {
                    if (!legyenbomba)
                    {
                        if (pálya[i, j] == 'B')
                        {
                            Console.Write('_');
                        }
                        else
                        {
                            Console.Write(pálya[i, j]);
                        }
                    }
                    else
                    {
                        Console.Write(pálya[i, j]);

                    }
                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }

        static int BombaSzomszédSzám(char[,] pálya, int lépx, int lépy)
        {
            int bombadb = 0;
            for (int i = lépx - 1; i <= lépx + 1; i++)
            {
                for (int j = lépy - 1; j <= lépy + 1; j++)
                {
                    if (pálya[i, j] == 'B')
                    {
                        bombadb++;
                    }
                }
            }
            return bombadb;
        }
    }
}