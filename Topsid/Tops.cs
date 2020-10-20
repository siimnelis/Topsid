using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Topsid
{
    public class Tops : IComparable<Tops>
    {
        public Tops(double number, double diameeter, double korgus)
        {
            Number = number;
            Diameeter = diameeter;
            Korgus = korgus;
        }
        public double Number { get; }
        public double Diameeter { get; }
        public double Korgus { get;}
        private double? _raadius;
        public double Raadius => (double) (_raadius ?? (_raadius = Diameeter / 2));
        private double? _ruumala;
        public double Ruumala => (double) (_ruumala ?? (_ruumala = Math.Round(Math.PI * (Raadius * Raadius) * Korgus)));

        public static bool operator >(Tops tops1, Tops tops2)
        {
            return 
                tops1.Diameeter > tops2.Diameeter && tops1.Korgus > tops2.Korgus || 
                tops1.Diameeter > tops2.Korgus && tops1.Korgus > tops2.Diameeter;
        }

        public static bool operator <(Tops tops1, Tops tops2)
        {
            return tops1.Diameeter < tops2.Diameeter && tops1.Korgus < tops2.Korgus ||
                   tops1.Diameeter < tops2.Korgus && tops1.Korgus < tops2.Diameeter;
        }

        public int CompareTo(Tops other)
        {
            if (other.Ruumala == Ruumala)
            {
                return 0;
            }

            if (other.Ruumala > Ruumala)
            {
                return -1;
            }

            return 1;
        }

        protected bool Equals(Tops other)
        {
            return Diameeter.Equals(other.Diameeter) && Korgus.Equals(other.Korgus);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tops)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Diameeter.GetHashCode() * 397) ^ Korgus.GetHashCode();
            }
        }
    }
}
