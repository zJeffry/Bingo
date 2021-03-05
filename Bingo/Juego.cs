using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo
{
    class Juego
    {
        Carton carton_j1;
        Carton carton_j2;
        Bombo bombo;
        public Juego()
        {
            Menu();
        }

        public void Menu()
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\n          Bingo          ");
                Console.WriteLine("\n Seleccione un modo a simular: ");
                Console.WriteLine(" 1. Carton Lleno"+ "\n 2. 4 Esquinas" + "\n 3. En X" );
                Console.Write("Opcion: ");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine(" Carton Lleno");
                        Juego_cartonLleno();
                        break;
                    case 2:
                        Console.WriteLine(" 4 Esquinas");
                        Juego_4Esquinas();
                        break;
                    case 3:
                        Console.WriteLine(" En X");
                        Juego_enX();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine(" Valor no valido");
                        Console.Write("Opcion: ");
                        break;
                }
                Console.ReadKey();
                Console.WriteLine();

            } while (opc != 4);
        }


        void Cargar_juego(int val)
        {
            int cantidad = 125;
            carton_j1 = new Carton();
            carton_j2 = new Carton();
            bombo = new Bombo();
            bombo.CantBolas = cantidad;
            bombo.Cargar();
            if (val == 1)
            {
                // Iguala las filas y columnas para jugar X
                int x = 5;
                carton_j1.Fila = x;
                carton_j1.Columna = x;
                carton_j2.Fila = x;
                carton_j2.Columna = x;
            }
            else
            {
                int f = 5;
                int c = 5;
                carton_j1.Fila = f;
                carton_j1.Columna = c;
                carton_j2.Fila = f;
                carton_j2.Columna = c;
            }
            carton_j1.Cargar();
            carton_j2.Cargar();
            carton_j1.Imprimir(1, carton_j1.GetCarton());
            carton_j2.Imprimir(2, carton_j2.GetCarton());
        }

        bool Simular(bool j1, bool j2, Carton c_j1, Carton c_j2)
        {  
            if (j1 == true && j2 == false)
            {
                Console.WriteLine("\n !Gano el jugador 1¡");
                c_j1.Imprimir(1, c_j1.GetCarton());
                return true;
            }
            if (j2 == true && j1 == false)
            {
                Console.WriteLine("\n !Gano el jugador 2¡");
                c_j2.Imprimir(2, c_j2.GetCarton());
                return true;
            }
            if (j1 == true && j2 == true)
            {
                Console.WriteLine("\n !Empate¡");
                return true;
            }
            return false;
        }

        void Juego_cartonLleno()
        {
            Cargar_juego(0);
            bool aux = false;
            while (aux != true)
            {
                bombo.SacarBola();
                carton_j1.ActualizarCarton(bombo.Bola);
                carton_j2.ActualizarCarton(bombo.Bola);
                aux = Simular(carton_j1.Modo_cartonLleno(), carton_j2.Modo_cartonLleno(), carton_j1, carton_j2);
            }
            Revisar_carton(carton_j1, carton_j2);
        }

        void Juego_4Esquinas()
        {
            Cargar_juego(0);
            bool aux = false;
            while (aux != true)
            {
                bombo.SacarBola();
                carton_j1.ActualizarCarton(bombo.Bola);
                carton_j2.ActualizarCarton(bombo.Bola);
                aux = Simular(carton_j1.Modo_4Esquinas(), carton_j2.Modo_4Esquinas(), carton_j1, carton_j2);
            }
            Revisar_carton(carton_j1, carton_j2);
        }

        void Juego_enX()
        {
            Cargar_juego(1);
            bool aux = false;
            while (aux != true)
            {
                bombo.SacarBola();
                carton_j1.ActualizarCarton(bombo.Bola);
                carton_j2.ActualizarCarton(bombo.Bola);
                aux = Simular(carton_j1.Modo_x(), carton_j2.Modo_x(), carton_j1, carton_j2);
            }
            Revisar_carton(carton_j1, carton_j2);
        }

        void Revisar_carton(Carton c_j1, Carton c_j2)
        {
            c_j1.Imprimir(1, c_j1.GetCartonMarcado());
            c_j2.Imprimir(2, c_j2.GetCartonMarcado());
            Console.WriteLine(bombo.BomboToString());
            Console.WriteLine(bombo.ListaBToString());
        }
    }
}
