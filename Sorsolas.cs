using System;
using System.Collections.Generic;
using System.Text;

namespace lotto
{
    class Sorsolas
    {
        public int het;
        public int szam1;
        public int szam2;
        public int szam3;
        public int szam4;
        public int szam5;
        public int szam6;

        public Sorsolas(string het, string szam1, string szam2, string szam3, string szam4, string szam5, string szam6)
        {
            this.het = int.Parse(het);
            this.szam1 = int.Parse(szam1);
            this.szam2 = int.Parse(szam2);
            this.szam3 = int.Parse(szam3);
            this.szam4 = int.Parse(szam4);
            this.szam5 = int.Parse(szam5);
            this.szam6 = int.Parse(szam6);
        }
    }
}