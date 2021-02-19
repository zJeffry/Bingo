using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo
{
    class Numeros
    {
        private int num, numMax = 91;


        public Numeros(int num)
        {
            this.num = num;
        }

        public Numeros() 
        {

        }

        public void NumRandom()
        {
            Random rnd = new Random();
            num = rnd.Next(1, numMax);
        }

        public int Num
        {
            get { return num; }
        }
    }
}
