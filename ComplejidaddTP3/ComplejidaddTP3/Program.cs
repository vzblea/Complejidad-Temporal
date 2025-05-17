using System;

namespace ComplejidaddTP3
{
	class Program
	{
		public static void Main(string[] args)
		{
			TablaHash tabla = new TablaHash(17); // Tamaño primo para mejor dispersión

        int[] claves = { 23, 45, 12, 87, 34, 56, 78, 90, 11, 66 };

        Console.WriteLine("Insertando elementos en la tabla:");
        foreach (int clave in claves)
        {
            tabla.Insertar(clave);
        }

        tabla.Mostrar();

        Console.WriteLine("\nEliminando elementos de la tabla:");
        foreach (int clave in claves)
        {
            tabla.Eliminar(clave);
        }

        tabla.Mostrar();
        Console.ReadKey();
		}
	}
}