using System;
namespace Emergencias
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*             Sistema Gestion Emergencias Medicas              *");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("\n[A] Registrar Empleado"); // LISTO 
            Console.WriteLine("\n[B] Listar Todods los Empleados"); // LISTO
            Console.WriteLine("\n[C] Registrar Vehiculos");
            Console.WriteLine("\n[D] Listar Todos los Vehiculos");
            Console.WriteLine("\n[E] Registrar una Dotación");
            Console.WriteLine("\n[F] Eliminar Empleado");
            Console.WriteLine("\n[G] Informe de un Empleado");
            Console.WriteLine("\n[H] Informe de una Dotación según Patente y Fecha");
            Console.WriteLine("\n[S] Salir de la aplicación");
            Console.WriteLine("\n****************");
            return CInterfaz.PedirDato("opción elegida ");
        }

        public static string PedirDato(string dato)
        {
            Console.WriteLine("[?] Ingrese " + dato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.WriteLine("[!] El ingreso de " + dato + " es OBLIGATORIO --> ");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();
        }

        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("< Pulse Enter >");
            Console.ReadLine();
            Console.Clear();
        }
    }
}