using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo
{
    class Numeros
    {
        private int num;


        public Numeros(int num)
        {
            this.num = num;
        }

        public Numeros() 
        {

        }

        public void NumRandom(int lim_inferior, int lim_superior)
        {
            Random rnd = new Random();
            num = rnd.Next(lim_inferior, lim_superior);
        }

        public int Num
        {
            get { return num; }
        }
    }
}
