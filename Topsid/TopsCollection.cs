using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topsid
{
    public class TopsCollection
    {
        private readonly List<Tops> Topsid;
        public TopsCollection(List<Tops> topsid)
        {
            Topsid = topsid;
        }

        public List<Komplekt> Komplekteeri()
        {
            var komplektid = new List<Komplekt>();

            Topsid.Sort();
            Topsid.Reverse();

            foreach (var tops in Topsid)
            {
                if (!komplektid.Any())
                {
                    var komplekt = new Komplekt(tops);
                    komplektid.Add(komplekt);
                }
                else
                {
                    var esimeneKomplektKuhuMahub = komplektid.FirstOrDefault(x => x.Viimane > tops);

                    if (esimeneKomplektKuhuMahub != null)
                    {
                        esimeneKomplektKuhuMahub.Lisa(tops);
                    }
                    else
                    {
                        var komplekt = new Komplekt(tops);
                        komplektid.Add(komplekt);
                    }
                }
            }

            return komplektid;
        }

        public class Komplekt
        {
            public Komplekt(Tops esimeneTops)
            {
                Topsid.Add(esimeneTops);
            }
            public Tops Viimane => Topsid.Last();
            public List<Tops> Topsid { get; } = new List<Tops>();

            public void Lisa(Tops tops)
            {
                Topsid.Add(tops);
            }

        }
    }
}
