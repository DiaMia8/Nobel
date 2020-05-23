using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    class NobelAdat
    {
        public int Ev { get; set; }
        public string Tipus { get; set; }
        public string KeresztNev { get; set; }
        public string VezetekNev { get; set; }

        public NobelAdat(string sor)
        {

                string[] seged = sor.Split(';');
                Ev = int.Parse(seged[0]);
                Tipus = seged[1];
                KeresztNev = seged[2];
                if (seged[3].Length > 0)
                {
                    VezetekNev = seged[3];
                }
                else
                {
                    VezetekNev = "";
                }
          
        }
    }
}
