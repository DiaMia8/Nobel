using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    class Program
    {
        public static List<NobelAdat> nobelAdat;

        static void Main(string[] args)
        {
            //2. feladat
            nobelAdat = new List<NobelAdat>();
            string fajl = "nobel.csv";

            StreamReader sr = new StreamReader(fajl);
            string fejlec = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                NobelAdat n = new NobelAdat(sor);
                nobelAdat.Add(n);
            }
            sr.Close();

            //3. feladat

            Console.Write("3. feladat: ");
            Console.WriteLine($"{nobelAdat.Find(x=>x.VezetekNev == "McDonald" && x.KeresztNev == "Arthur B.").Tipus.ToString()}");

            //4. feladat

            NobelAdat keresett = nobelAdat.Find(x => x.Ev == 2017 && x.Tipus == "irodalmi");
            Console.Write("4. feladat: ");
            Console.WriteLine($"{keresett.KeresztNev} {keresett.VezetekNev}");

            //5. feladat

            Console.WriteLine("5. feladat: ");
            foreach (var item in nobelAdat)
            {
                if (item.VezetekNev == "" && item.Ev > 1990)
                {
                    Console.WriteLine($"\t{item.Ev}: {item.KeresztNev}");
                }
            }

            //6. feladat

            List<NobelAdat> curie = new List<NobelAdat>();
            foreach (var item in nobelAdat)
            {
                if (item.VezetekNev.Contains("Curie"))
                {
                    curie.Add(item);
                }
            }

            Console.WriteLine("6. feladat");
            foreach (var item in curie)
            {
                Console.WriteLine($"\t{item.Ev}: {item.KeresztNev} {item.VezetekNev}({item.Tipus})");
            }


            //7. feladat
            Dictionary<string, int> tipusok = new Dictionary<string, int>();

            foreach (var item in nobelAdat)
            {
                if (!tipusok.ContainsKey(item.Tipus))
                {
                    tipusok.Add(item.Tipus, 1);
                }
                else
                {
                    tipusok[item.Tipus]++;
                }
            }

            Console.WriteLine("7. feladat");

            foreach (var item in tipusok)
            {
                Console.WriteLine($"\t{item.Key.PadRight(16)}\t\t{item.Value.ToString().PadLeft(4)} db");
            }

            //8. feladat

            Console.WriteLine("8. feladat: orvosi.txt");

            List<NobelAdat> orvosi = new List<NobelAdat>();
            foreach (var item in nobelAdat)
            {
                if (item.Tipus == "orvosi")
                {
                    orvosi.Add(item);
                }
            }

            FileStream f = new FileStream("orvosi.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(f, Encoding.UTF8);
            var adat = from item in orvosi orderby item.Ev descending select item;
            foreach (var item in adat)
            {
                sw.WriteLine($"{item.Ev}:{item.KeresztNev} {item.VezetekNev}");
            }
            sw.Close();
            f.Close();

            Console.ReadKey();
        }
    }
}
