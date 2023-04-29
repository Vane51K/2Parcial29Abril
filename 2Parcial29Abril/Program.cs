using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablero
{
    class Program
    {
        static void Main(string[] args)
        {
            //Keylie Vaneesa Sanchez Perez
            //0905-22-12125
            //seccion B "ingenieria en sistemas" "programacion"

            bool jugarDeNuevo = true;
            while (jugarDeNuevo)
            {

                int[,] tablero = new int[5, 5];

                void paso1_crear_tablero()
                {

                    for (int f = 0; f < tablero.GetLength(0); f++)
                    {
                        for (int c = 0; c < tablero.GetLength(1); c++)
                        {
                            tablero[f, c] = 0;
                        }
                    }
                }

                void paso2_colocar_barcos()
                {
                    Random random = new Random();
                    int barcosColocados = 0;
                    while (barcosColocados < 4)
                    {
                        int fila = random.Next(0, 5);
                        int columna = random.Next(0, 5);
                        if (tablero[fila, columna] == 0)
                        {
                            tablero[fila, columna] = 1;
                            barcosColocados++;
                        }
                    }
                }
                void paso3_imprimir_tablero()
                {
                    String caracter_imprimir = "";
                    for (int f = 0; f < tablero.GetLength(0); f++)
                    {
                        for (int c = 0; c < tablero.GetLength(1); c++)
                        {
                            switch (tablero[f, c])
                            {
                                case 0:
                                    caracter_imprimir = " ~ ";
                                    break;

                                case 1:
                                    caracter_imprimir = " ~ ";
                                    break;

                                case -1:
                                    caracter_imprimir = " * ";
                                    break;

                                case -2:
                                    caracter_imprimir = " X ";
                                    break;

                                default:
                                    caracter_imprimir = " ~ ";
                                    break;
                            }
                            Console.Write(caracter_imprimir + " ");
                        }
                        Console.WriteLine();
                    }
                }

                void paso4_ingreso_coordenadas()
                {
                    int fila, columna;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("..............BIENVENIDO A ESTE MINI JUEGO..............");
                    Console.WriteLine("---------------------INSTRUCCIONES---------------------");
                    Console.WriteLine("1. Debe ingresar una fila y columna que este entre 0 a 4");
                    Console.WriteLine("2. Cuando hundas un barco se escuchara un Beep");
                    Console.WriteLine("3. Hazlo hasta hundir todos los barcos");
                    Console.WriteLine("------------------SUERTE Y DIVIERTETE------------------");

                    do
                    {
                        Console.Write("INGRESA EL NUMERO DE FILA: ");
                        fila = Convert.ToInt32(Console.ReadLine());
                        Console.Write("INGRESA EL NUMERO DE COLUMNA: ");
                        columna = Convert.ToInt32(Console.ReadLine());

                        if (fila < 0 || fila > 4 || columna < 0 || columna > 4)
                        {
                            Console.WriteLine("Coordenadas fuera de rango. Debe ingresar una fila y columna entre 0 a 4. Intenta nuevamente.");
                            Console.WriteLine();
                        }
                        else if (tablero[fila, columna] == 1)
                        {
                            Console.Beep();
                            tablero[fila, columna] = -1;
                        }
                        else
                        {
                            tablero[fila, columna] = -2;
                        }
                        Console.Clear();

                        paso3_imprimir_tablero();

                        if (tablero.Cast<int>().All(value => value != 1))
                        {
                            Console.WriteLine("¡FELICIDADES! ¡HAS HUNDIDO TODOS LOS BARCOS!");
                            break;
                        }
                    } while (true);
                }

                paso1_crear_tablero();
                paso2_colocar_barcos();
                paso3_imprimir_tablero();
                paso4_ingreso_coordenadas();

                Console.WriteLine("¿Desea volver a jugar? (si/no)");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "si")
                {
                    jugarDeNuevo = true;
                    Console.Clear();
                }
                else
                {
                    jugarDeNuevo = false;
                }
            }
        }
    }
}