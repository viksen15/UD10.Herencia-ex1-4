using System;

namespace Ejercicio1
{
    public class Password
    {
        private static int LONG_DEF = 8;

        //  ATRIBUTOS
        private int longitud;
        private String contraseña;

        // CONSTRUCTORES
        public Password()
        {
            this.longitud = LONG_DEF;
        }

        public Password(int longitud)
        {
            this.longitud = longitud;
            contraseña = generaPassword();
        }


        //  METODOS
        public int Longitud { set { this.longitud = value; } get { return longitud; } }
        public string Contraseña { get { return contraseña; } }

        public String generaPassword()
        {
            String password = "";
            for (int i = 0; i < longitud; i++)
            {
                Random rnd = new Random();
                int eleccion = ((int)Math.Floor(rnd.NextDouble() * 3 + 1));

                if (eleccion == 1)
                {
                    char minusculas = (char)((int)Math.Floor(rnd.NextDouble() * (123 - 97) + 97));
                    password += minusculas;
                }
                else
                {
                    if (eleccion == 2)
                    {
                        char mayusculas = (char)((int)Math.Floor(rnd.NextDouble() * (91 - 65) + 65));
                        password += mayusculas;
                    }
                    else
                    {
                        char numeros = (char)((int)Math.Floor(rnd.NextDouble() * (58 - 48) + 48));
                        password += numeros;
                    }
                }
            }
            return password;
        }

        public bool esFuerte()
        {
            int cuentanumeros = 0;
            int cuentaminusculas = 0;
            int cuentamayusculas = 0;

            for (int i = 0; i < contraseña.Length; i++)
            {
                if (contraseña[i] >= 97 && contraseña[i] <= 122)
                {
                    cuentaminusculas += 1;
                }
                else
                {
                    if (contraseña[i] >= 65 && contraseña[i] <= 90)
                    {
                        cuentamayusculas += 1;
                    }
                    else
                    {
                        cuentanumeros += 1;
                    }
                }
            }
            if (cuentanumeros >= 5 && cuentaminusculas >= 1 && cuentamayusculas >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un tamaño para el array");
            int tamañoArray = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduce la longitud del password");
            int longitud = Convert.ToInt32(Console.ReadLine());

            // CREAMOS LOS ARRAYS
            Password[] listaPassword = new Password[tamañoArray];
            bool[] fortalezaPassword = new bool[tamañoArray];

            for (int i = 0; i < listaPassword.Length; i++)
            {
                listaPassword[i] = new Password(longitud);
                fortalezaPassword[i] = listaPassword[i].esFuerte();
                Console.WriteLine(listaPassword[i].Contraseña + " " + fortalezaPassword[i]);
            }
        }
    }
}
