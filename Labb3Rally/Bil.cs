using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
namespace Labb3Rally
{
    public class Bil : IEquatable<Bil>, IEnumerator
    {

        public string BilNamn { get; set; }
        public double Hastighet { get; set; }
        public double Sträcka { get; set; }
        public Bil(string bilNamn, int hastighet, int sträcka)
        {
            BilNamn = bilNamn;
            Hastighet = hastighet;
            Sträcka = sträcka;

        }
        public Bil[] bilista;
        int position = -1;

        public object Current
        {
            get { return bilista[position]; }
        }



        public bool Equals([AllowNull] Bil other)
        {
            if (other == null) return false;
            return (this.BilNamn.Equals(other.BilNamn));
        }

        public bool MoveNext()
        {
            position++;
            return (position < bilista.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }


    }
}
