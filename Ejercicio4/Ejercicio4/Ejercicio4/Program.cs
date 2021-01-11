using System;

namespace Ejercicio4
{
    class Electrodomestico
    {
        // ATRIBUTOS
        protected double preciobase = 100;
        protected string color = "blanco";
        protected char consumoenergetico = 'F';
        protected double peso = 5;
        protected string[] colores = { "BLANCO", "blanco", "NEGRO", "negro", "ROJO", "rojo", "AZUL", "azul", "GRIS", "gris" };

        // CONSTRUCTORES
        public Electrodomestico()
        {
        }
        public Electrodomestico(double preciob, double pes)
        {
            preciobase = preciob;
            peso = pes;
        }
        public Electrodomestico(double preciob, string col, char consumo, double pes)
        {
            preciobase = preciob;
            color = col;
            consumoenergetico = consumo;
            peso = pes;
        }

        // METODOS
        public double PrecioBase { get { return this.preciobase; } }
        public string Color { get { return this.color; } }
        public char Consumoenergetico { get { return this.consumoenergetico; } }
        public double Peso { get { return this.peso; } }
        public string[] Colores { get { return this.colores; } }

        private void comprobarConsumoEnergetico(char consumoenergetico)
        {
            if (consumoenergetico == 'A' || consumoenergetico == 'B' || consumoenergetico == 'C' || consumoenergetico == 'D' || consumoenergetico == 'E' || consumoenergetico == 'F')
            { this.consumoenergetico = consumoenergetico; }
        }
        private void comprobarColor(string color)
        {
            if (color.Equals(colores))
            { this.color = color; }
        }
        public double precioFinal()
        {
            double plus = 0;
            switch (consumoenergetico)
            {
                case 'A': plus += 100; break;
                case 'B': plus += 80; break;
                case 'C': plus += 60; break;
                case 'D': plus += 50; break;
                case 'E': plus += 30; break;
                case 'F': plus += 10; break;
            }
            if (peso >= 0 && peso < 19) { plus += 10; }
            else if (peso >= 20 && peso < 49) { plus += 50; }
            else if (peso >= 50 && peso <= 79) { plus += 80; }
            else if (peso >= 80) { plus += 100; }
            return preciobase + plus;
        }
    }

    class Lavadora : Electrodomestico
    {
        // ATRIBUTOS
        private double carga = 5;

        // CONSTRUCTORES
        public Lavadora()
        {
        }
        public Lavadora(double preciob, double pes)
        {
            preciobase = preciob;
            peso = pes;
        }
        public Lavadora(double preciob, string col, char consumo, double pes, double carg)
        {
            preciobase = preciob;
            color = col;
            consumoenergetico = consumo;
            peso = pes;
            carga = carg;
        }

        // METODOS
        public double Carga { get { return this.carga; } }

        public double precioFinalLavadora()
        {
            double plus = precioFinal();
            if (carga > 30) { plus += 50; } return plus;
        }
    }

    class Television : Electrodomestico
    {
        // ATRIBUTOS
        private double resolucion = 20;
        private bool sintonizadorTDT = false;

        // CONSTRUCTORES
        public Television()
        {
        }
        public Television(double preciob, double pes)
        {
            preciobase = preciob;
            peso = pes;
        }
        public Television(double preciob, string col, char consumo, double pes, double resol, bool sinto)
        {
            preciobase = preciob;
            color = col;
            consumoenergetico = consumo;
            peso = pes;
            resolucion = resol;
            sintonizadorTDT = sinto;
        }

        // METODOS
        public double Resolucion { get { return resolucion; } }
        public bool Sintonizador { get { return sintonizadorTDT; } }

        public double precioFinalTelevision()
        { 
            double plus = precioFinal();
            if (resolucion > 40) { plus += preciobase * 0.3; }
            if (sintonizadorTDT) { plus += 50; }
            return plus;
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
                Electrodomestico[] listaElectrodomesticos = new Electrodomestico[10];
                listaElectrodomesticos[0] = new Electrodomestico();
                listaElectrodomesticos[1] = new Lavadora();
                listaElectrodomesticos[2] = new Television();
                listaElectrodomesticos[3] = new Electrodomestico(499.95, 54.2);
                listaElectrodomesticos[5] = new Lavadora(249.90, 20.35);
                listaElectrodomesticos[6] = new Television(650, 12.8);
                listaElectrodomesticos[4] = new Electrodomestico(354.99, "rojo", 'B', 10);
                listaElectrodomesticos[7] = new Lavadora(150,"gris",'D',19.85,32.7);
                listaElectrodomesticos[8] = new Television(820,"negro", 'A',17.4,52,true);
                listaElectrodomesticos[9] = new Electrodomestico(120.50,"azul",'F', 12);

            double sumaElectrodomesticos = 0;
            double sumaLavadoras = 0;
            double sumaTelevisiones = 0;
            for (int i = 0; i < listaElectrodomesticos.Length; i++)
            {
                if (listaElectrodomesticos[i] is Electrodomestico)
                { sumaElectrodomesticos += listaElectrodomesticos[i].precioFinal(); }
                if (listaElectrodomesticos[i] is Lavadora)
                { sumaLavadoras += listaElectrodomesticos[i].precioFinal(); }
                if (listaElectrodomesticos[i] is Television)
                { sumaTelevisiones += listaElectrodomesticos[i].precioFinal(); }
            }

            Console.WriteLine("La suma del precio de los electrodomesticos es de: " + sumaElectrodomesticos);
            Console.WriteLine("");
            Console.WriteLine("La suma del precio de las lavadorase es de: " + sumaLavadoras);
            Console.WriteLine("");
            Console.WriteLine("La suma del precio de las Televisiones es de: " + sumaTelevisiones);

        }
    }
    }

