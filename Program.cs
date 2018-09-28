using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime value = new DateTime(2018, 09, 26);
            string BapPrisijungimai = "Config.txt";
            string Rezultatas = @"C:\Users\Artūras\Desktop\Koding\C#\MotoWebServisai\Rezultatas.txt";
            MotoWeb.WSMotoKlientSoap client = new MotoWeb.WSMotoKlientSoapClient();

            File.WriteAllText(Rezultatas, string.Empty);

            var BazineEilute = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\n", "DOK_SERIJA_IR_NUMERIS", "DOK_DATA",
                "DOK_APMOKTERMINAS", "DOK_SUMASUPVM", "DOK_SKYRIUS", "PREK_PAVADINIMAS", "PREK_KIEKIS", "PREK_KAINA");
            File.AppendAllText(Rezultatas, BazineEilute);

            foreach (string line in File.ReadAllLines(BapPrisijungimai))
            {
                string[] BapKlientai = line.Split('|');

                foreach (var val in client.ZwrocNumeryFaktur(BapKlientai[0], BapKlientai[1], value))
                {
                    string[] poViena = val.Split('|');

                    foreach (var pavadinimas in client.ZwrocPozycjeFaktury(BapKlientai[0], BapKlientai[1], poViena[0]))
                    {
                        string[] poViena_1 = pavadinimas.Split('|');

                        var NaujaEilute = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\n", poViena[0], poViena[4], poViena[5],
                            poViena[1], BapKlientai[2], poViena_1[2], poViena_1[3], poViena_1[4]);
                        //Console.WriteLine(NaujaEilute);

                        File.AppendAllText(Rezultatas, NaujaEilute);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
