using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    internal class Program
    {
        //Creación del tablero
        static int[,] tablero = new int[3, 3]; //3 filas y 3 columnas

        //Creación de simbolos del tablero: espacio en blanco, jug.1, jug.2
        static char[] simbolos = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            bool terminado = false;

            // Dibujar el tablero inicial
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do
            {
                // Turno Jugador 1
                PreguntarPosicion(1);//Envia el valor de "1" a la función PreguntarPosición

                //Dibujar la casilla del Jugador 1
                DibujarTablero();

                // Comprueba si ha ganado el Jugador 1
                terminado = ComprobarGanador();

                if (terminado == true)
                {
                    Console.WriteLine("¡El jugador 1 ha ganado!");
                }
                else // Comprueba si es empate
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("¡Esto es un empate!");
                    }

                    // Si jugador 1 no ganó, ni hubo empate, entonces es turno del Jugador 2 
                    else
                    {
                        // Turno del Jugador 2
                        PreguntarPosicion(2);
                        // Dibujar la casilla del Jugador 2
                        DibujarTablero();
                        // Comprobar si ha ganado la partida el Jugador 2
                        terminado = ComprobarGanador();

                        if (terminado == true)
                        {
                            Console.WriteLine("¡El jugador 2 ha ganado!");
                        }
                    }
                }

                // Repetir hasta 3 en línea o empate (tablero lleno)
            } while (terminado == false); /* Mientras el juego no haya terminado, es
                                             decir, mientras la variable sea igual a
                                             false, se seguira repitiendo el ciclo*/

        }

        static void DibujarTablero()
        {
            //Varibles de conteo
            int fila = 0;
            int columna = 0;

            Console.WriteLine();//Espacio antes de dibuajar el tablero
            Console.WriteLine("-------------");//Primera línea horizonal del tablero

            for(fila = 0; fila<3; fila++)
            {
                Console.Write("|");//Dibuja la primera línea vertical
                for(columna = 0; columna<3; columna++)
                {
                    //Asigna un: espacio, O, X, según corresponda
                    Console.Write(" {0} |", simbolos[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------");//Dibuja el resto de líneas horizontales
            }
        }

        //Pregunta dónde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador) //Jugador1: 1 ; Jugador2: 2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Pedimos el número de fila
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila < 1) || (fila > 3)); //Ejecutar mientras fila sea menor que 1 o mayor que 3

                // Pedimos el número de columna
                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3));

                if (tablero[fila - 1, columna - 1] != 0)
                    Console.WriteLine("Casilla ocupada!");

            } while (tablero[fila - 1, columna - 1] != 0);

            // Si todo es correcto, se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;
        }

        // Devuelve un "true" si hay tres en línea
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool tresEnRaya = false;

            // Si en alguna fila todas las casillas son iguales y no están vacías
            for (fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1])
                    && (tablero[fila, 0] == tablero[fila, 2])
                    && (tablero[fila, 0] != 0))
                {
                    tresEnRaya = true;
                }
            }

            // Si en alguna columna todas las casillas son iguales y no están vacías
            for (columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] == tablero[2, columna])
                    && (tablero[0, columna] != 0))
                {
                    tresEnRaya = true;
                }
            }

            // Si en alguna diagonal todas las casillas son iguales y no están vacías
            if ((tablero[0, 0] == tablero[1, 1])
                && (tablero[0, 0] == tablero[2, 2])
                && (tablero[0, 0] != 0))
            {
                tresEnRaya = true;
            }

            if ((tablero[0, 2] == tablero[1, 1])
                && (tablero[0, 2] == tablero[2, 0])
                && (tablero[0, 2] != 0))
            {

                tresEnRaya = true;
            }
            return tresEnRaya;
        }

        // Devuelve "true" si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for (fila = 0; fila < 3; fila++)
            {
                for (columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila, columna] == 0)/* Si encuentra una sola casilla vacia, 
                                                     * quiere decir que aun se puede seguir jugando */
                    {
                        hayEspacio = true;
                    }
                }
            }
            return !hayEspacio; 
        }
    }
}