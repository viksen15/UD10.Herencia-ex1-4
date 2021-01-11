using System;

namespace Ejercicio1
{
    class Cuenta
    {
        // ATRIBUTOS
        private string titular;
        private double cantidad;
        //CONSTRUCTORES
        public Cuenta(string titular)
        { this.titular = titular; }
        public Cuenta(string titular, double cantidad)
        { this.titular = titular;
        if (cantidad < 0) { this.cantidad = 0; } else { this.cantidad = cantidad; }
        }
        // METODOS
        public string Titular { set { this.titular = value; } get { return titular; } }
        public double Cantidad { set { this.cantidad = value; } get { return cantidad; } }

        public void ingreso(double cantidad)
        {
            if (cantidad > 0) { this.cantidad += cantidad; }
        }
        public void retiro(double cantidad)
        {
            if (this.cantidad - cantidad < 0) { this.cantidad = 0; }
            else { this.cantidad -= cantidad; }
        }
        public string toString()
        {
            return titular + " tiene " + cantidad + "eur.";
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuentaViksen = new Cuenta("Viksen");
            Cuenta otracuenta = new Cuenta("Otro", 150);
            Console.WriteLine("Viksen tiene " + cuentaViksen.Cantidad + "eur");
            Console.WriteLine("Otro tiene " + otracuenta.Cantidad + "eur");
            Console.WriteLine("");
            // INGRESO
            cuentaViksen.ingreso(500);
            Console.WriteLine("Viksen ha ingresado " + cuentaViksen.Cantidad + "eur");
            otracuenta.ingreso(50);
            Console.WriteLine("Otro ha ingresado " + otracuenta.Cantidad + "eur");
            Console.WriteLine("");

            // RETIRO
            cuentaViksen.retiro(200);
            Console.WriteLine("Viksen ha retirado");
            otracuenta.retiro(300);
            Console.WriteLine("Otro ha retirado");
            Console.WriteLine("");

            //  MUESTRA CUENTAS
            Console.WriteLine("A Viksen le quedan: " + cuentaViksen.Cantidad + "eur");
            Console.WriteLine("A otro le quedan: " + otracuenta.Cantidad + "eur");
        }
    }
}
