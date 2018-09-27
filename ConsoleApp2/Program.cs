using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime value = new DateTime(2018,09,26);
            MotoWeb.WSMotoKlientSoap client = new MotoWeb.WSMotoKlientSoapClient();
            
            foreach (var val in client.ZwrocNumeryFaktur("11263", "01IH", value))
            {
                Console.WriteLine(val);
                foreach (var pavadinimas in client.ZwrocPozycjeFaktury("11263", "01IH", "FA 119417/09/2018/U"))
                {
                    Console.WriteLine(pavadinimas);
                }
            }

            foreach (var val in client.ZwrocNumeryFaktur("11263", "01IE", value))
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();
        }
    }
}
