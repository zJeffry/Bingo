using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo
{
    class Carton
    {
        private int[,] carton, carton_marcado;
        private int fila, columna, aux_fila, aux_columna;

        public Carton()
        {

        }

        public int[,] GetCarton()
        {
            return carton;
        }

        public int[,] GetCartonMarcado()
        {
            return carton_marcado;
        }

        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }

        public int Columna
        {
            get { return columna; }
            set { columna = value; }
        }

        public void Cargar()
        {
            // Rellena el carton con numeros aleatorios sin repetir
            carton = new int[Fila, Columna];
            carton_marcado = new int[Fila, Columna];
            for (int j = 0; j < Columna; j++)
            {
                RellenarFila(carton, j);
            }
        }

        void RellenarFila(int[,] c ,int fila)
        {
            int[] multiplos = new int[] { 25, 50, 75, 100, 125 };
            int[] inf = new int[] { 1, 25, 50, 75, 100 };
            Numeros rnd = new Numeros();
            int lim_superior = (int)multiplos.GetValue(fila), lim_inferior = (int)inf.GetValue(fila);
            for (int j = 0; j < Columna; j++)
            {
                rnd.NumRandom(lim_inferior, lim_superior);
                while (BuscarNum(rnd.Num, c) == true)
                {
                    rnd.NumRandom(lim_inferior, lim_superior);
                }
                c[fila, j] = rnd.Num;
            }
        }

        public void Imprimir(int jugador, int[,] nCarton)
        {
            // Inprime el carton de bingo
            Console.Write("\n-  Jugador " + jugador + " -");
            Console.Write("\n-   Carton   - \n");
            for (int f = 0; f < Fila; f++)
            {
                for (int c = 0; c < Columna; c++)
                {
                    Console.Write(nCarton[f, c].ToString("D3") + " ");
                }
                Console.WriteLine();
            }
        }

        public void Imprimir(int jugador)
        {
            Console.Write("\n-  Jugador " + jugador + " -");
            Console.Write("\n-   Carton   - \n");
            for (int f = 0; f < Fila; f++)
            {
                for (int c = 0; c < Columna; c++)
                {
                    Console.Write(carton[f, c].ToString("D3") + " ");
                }
                Console.WriteLine();
            }
        }

        public bool BuscarNum(int num, int[,] nCarton)
        {
            // Busca si el numero ya existe en el carton
            for (int f = 0; f < Fila; f++)
            {
                for (int c = 0; c < Columna; c++)
                {
                    if (num == nCarton[f, c])
                    {
                        aux_fila = f;
                        aux_columna = c;
                        return true;
                    }
                }
            }
            return false;
        }

        public void ActualizarCarton(int bola)
        {
            // Valida si la bola que salio esta en el carton 
            if (BuscarNum(bola, carton) == true)
            {
                carton_marcado[aux_fila, aux_columna] = 1;
            }
        }

        public bool Modo_cartonLleno()
        {
            //Console.Write("\n-  CArton LLeno ");
            if (BuscarNum(0, carton_marcado) == false)
            {
                return true;
            }
            return false;

        }

        public bool Modo_4Esquinas()
        {
            if (carton_marcado[0, 0] == 1 && carton_marcado[0, Columna - 1] == 1 &&
                carton_marcado[Fila - 1, 0] == 1 && carton_marcado[Fila - 1, Columna - 1] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Modo_x()
        {
            int x = Columna;
            int y = 0;
            int modoX = 0;
            for (int f = 0; f < Fila; f++)
            {
                for (int c = 0; c < Columna; c++)
                {
                    if (c == x - 1 && carton_marcado[f, c] == 1 || c == y && carton_marcado[f, c] == 1)
                    {
                        modoX += 1;
                    }
                }
                x--;
                y++;
            }
            if ((2 * Fila) - 1 == modoX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
