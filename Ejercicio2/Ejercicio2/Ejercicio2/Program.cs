using System;

namespace Ejercicio2
{
    class Persona
    {
        private static char SexoDef = 'H';
        //  ATRIBUTOS
        private string nombre;
        private int edad;
        private string DNI;
        private char sexo;
        private double peso;
        private double altura;
        //  CONSTRUCTORES
        public Persona()
        {
            this.nombre = "";
            this.edad = 0;
            this.sexo = SexoDef;
            this.peso = 0;
            this.altura = 0;
        }
        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = 0;
            this.altura = 0;
        }
        public Persona(string nombre, int edad, char sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.peso = peso;
            this.altura = altura;
            generarDNI();
            this.sexo = sexo;
            comprobarSexo();
        }
        //  METODOS
        private void comprobarSexo()
        { if (sexo != 'H' && sexo != 'M') { this.sexo = SexoDef; } }
        private void generarDNI()
        {
            int divisor = 23;
            Random rnd = new Random();
            int numDni = (int)Math.Floor(rnd.NextDouble() * (100000000 - 10000000) + 10000000);
            int num = numDni - (numDni / divisor * divisor);

            char letraDni = generarLetraDni(num);

            DNI = Convert.ToString(numDni) + letraDni;
        }

        private char generarLetraDni(int num)
        {
            char[] letraDni = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            return letraDni[num];
        }
        public string Nombre { set { this.nombre = value; } }
        public int Edad { set { this.edad = value; } }
        public char Sexo { set { this.sexo = value; } }
        public double Peso { set { this.peso = value; } }
        public double Altura { set { this.altura = value; } }
        public void calcucarIMC()
        {
            double pesoActual = peso / Math.Pow(altura, 2);
            if (pesoActual >= 20 && pesoActual <= 25) { Console.WriteLine("0, EN SU PESO IDEAL"); }
            else if (pesoActual < 20) { Console.WriteLine(" -1, POR DEBAJO DE SU PESO IDEAL"); }
            else if (pesoActual > 25) {Console.WriteLine("1, EN SOBREPESO"); }
        }


        public bool mayorEdad()
        {
            bool mayor = false;
            if (edad >= 18) { mayor = true; }
            if (mayor) { Console.WriteLine("Es mayor de edad."); }
            else { Console.WriteLine("Es menor de edad."); }
            return mayor;
        }

        public string toString()
        {
            string sexo;
            if (this.sexo == 'H') { sexo = "Hombre"; }
            else { sexo = "Mujer"; }
            return "Info de la persona: \n"
                + "Nombre: " + nombre + "\n"
                + "Sexo: " + sexo + "\n"
                + "Edad: " + edad + " años\n"
                + "DNI: " + DNI + "\n"
                + "Peso: " + peso + "kg\n"
                + "Altura: " + altura + "M\n";
        }
    }
    class Ejecutable
    {
        public void persona1()
        {
            Console.WriteLine("Cual es tu nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Cuantos años tienes?");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cual es tu sexo?");
            char sexo = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cuanto pesas? en KG");
            double peso = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cuanto mides? en M");
            double altura = double.Parse(Console.ReadLine());

            Persona persona1 = new Persona("Viksen", 25, 'H', 60.8, 1.75);
            Console.WriteLine("");
            Console.WriteLine("Persona1");
            persona1.calcucarIMC();
            persona1.mayorEdad();
            persona1.toString();
        }
        public void persona2()
        {
            Console.WriteLine("Cual es tu nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Cuantos años tienes?");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cual es tu sexo?");
            char sexo = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cuanto pesas? en KG");
            double peso = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cuanto mides? en M");
            double altura = double.Parse(Console.ReadLine());

            Persona persona2 = new Persona(nombre, edad, sexo, 78.4, 1.75);
            Console.WriteLine("");
            Console.WriteLine("Persona2");
            persona2.calcucarIMC();
            persona2.mayorEdad();
            persona2.toString();

        }
        public void persona3()
        {
            Console.WriteLine("Cual es tu nombre?");
            string nombre = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Cuantos años tienes?");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cual es tu sexo?");
            char sexo = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cuanto pesas? en KG");
            double peso = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Cuanto mides? en M");
            double altura = double.Parse(Console.ReadLine());

            Persona persona3 = new Persona(nombre, edad, sexo, peso, altura);
            Console.WriteLine("");
            Console.WriteLine("Persona2");
            persona3.calcucarIMC();
            persona3.mayorEdad();
            persona3.toString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutable personas = new Ejecutable();
            personas.persona1();
            Console.WriteLine("");
            personas.persona2();
            Console.WriteLine("");
            personas.persona3();

            Console.ReadKey();
        }

    }
}


