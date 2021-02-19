using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo
{
    class Carton
    {
        private int[,] carton, enCarton;
        private int fila, columna, aux_fila, aux_columna;

        public Carton()
        {

        }

        public int[,] GetCarton()
        {
            return carton;
        }

        public int[,] GetEnCarton()
        {
            return enCarton;
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
            enCarton = new int[Fila, Columna];
            Numeros numR = new Numeros();
            for (int f = 0; f < Fila; f++)
            {
                for (int c = 0; c < Columna; c++)
                {
                    numR.NumRandom();
                    while (BuscarNum(numR.Num, carton) == true)
                    {
                        numR.NumRandom();
                    }
                    carton[f, c] = numR.Num;
                }
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
                    Console.Write(nCarton[f, c] + " ");
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
                    Console.Write(carton[f, c] + " ");
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
                enCarton[aux_fila, aux_columna] = 1;
            }
        }

        public bool Modo_cartonLleno()
        {
            if (BuscarNum(0, enCarton) == false)
            {
                return true;
            }
            return false;

        }

        public bool Modo_4Esquinas()
        {
            if (enCarton[0, 0] == 1 && enCarton[0, Columna - 1] == 1 &&
                enCarton[Fila - 1, 0] == 1 && enCarton[Fila - 1, Columna - 1] == 1)
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
                    if (c == x - 1 && enCarton[f, c] == 1 || c == y && enCarton[f, c] == 1)
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
