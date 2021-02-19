using System;
using System.Collections.Generic;

namespace Bingo
{
    public class Bombo
    {
        private int bola, maxB=90, aux;
        private List<int> listaB;
        public HashSet<int> bombo;
        private Numeros num;


        public Bombo(int bola)
        {
            this.bola = bola;
        }

        public Bombo() 
        {
            listaB = new List<int>();
            bombo = new HashSet<int>();
            num = new Numeros();
        }

        public int Bola
        {
            get { return bola; }
            set { bola = value; }
        }

        public override string ToString()
        {
            return "Bola " + ": " + bola.ToString();
        }

        public void SacarBola()
        {
            aux = 0;
            while (bombo.Count !=0 && aux == 0)
            {
                num.NumRandom();
                if (BuscarB(num.Num) == false)
                {
                    num.NumRandom();
                }
                else
                {
                    Bola = num.Num;
                    bombo.Remove(num.Num);
                    listaB.Add(Bola);
                    aux = 1;
                }
            }if (bombo.Count < 0)
            {
                Console.WriteLine("\n - Fin del bombo - ");
            }
        }

        public void Cargar()
        {
            //Rellena el bombo con 90 bolas
            while (bombo.Count != maxB)
            {
                num.NumRandom();
                bombo.Add(num.Num);
            }
        }

        public String BomboToString()
        {
            String b = "";
            Console.WriteLine("\n Quedan " + bombo.Count + " bolas");
            foreach (var x in bombo)
            {
                b += x + " ";
            }
            return b;
        }

        public String ListaBToString()
        {
            //Lista con la bolas que salieron
            String b = "";
            Console.WriteLine("\n Salieron " + listaB.Count + " bolas");
            foreach (var x in listaB)
            {
                b += x + " ";
            }
            return b;
        }

        private bool BuscarB(int b)
        {
            foreach (int x in bombo)
            {
                if (bombo.Contains(b))
                {
                    return true;
                }
            }return false;
        }

        public void LimpiarBombo()
        {
            bombo.Clear();
            listaB.Clear();
            Bola = 0;
        }
    }
}
