using System;

public class TablaHash
{
    private int?[] tabla;
    private int tamaño;
    private const double A = 0.6180339887; // Fracción para dispersión

    public TablaHash(int tamañoTabla)
    {
        tamaño = tamañoTabla;
        tabla = new int?[tamaño];
    }

    // Función de dispersión 
    private int FuncionHash(int clave)
    {
        double producto = clave * A;
        double fraccion = producto - Math.Floor(producto);
        return (int)(tamaño * fraccion);
    }

    // Insertar una clave en la tabla 
    public void Insertar(int clave)
    {
        int indice = FuncionHash(clave);
        int indiceInicial = indice;

        while (tabla[indice] != null)
        {
            indice = (indice + 1) % tamaño;
            if (indice == indiceInicial)
            {
                Console.WriteLine("La tabla está llena. No se puede insertar.");
                return;
            }
        }

        tabla[indice] = clave;
        Console.WriteLine("Insertado: " + clave + " en la posición " + indice);
    }

    // Eliminar una clave de la tabla
    public void Eliminar(int clave)
    {
        int indice = FuncionHash(clave);
        int indiceInicial = indice;

        while (tabla[indice] != null)
        {
            if (tabla[indice] == clave)
            {
                tabla[indice] = null;
                Console.WriteLine("Eliminado: " + clave + " de la posición " + indice);
                return;
            }

            indice = (indice + 1) % tamaño;
            if (indice == indiceInicial)
            {
                break;
            }
        }

        Console.WriteLine("Clave " + clave + " no encontrada.");
    }

    // Mostrar la tabla completa
    public void Mostrar()
    {
        Console.WriteLine("\nContenido de la tabla:");
        for (int i = 0; i < tamaño; i++)
        {
            string contenido = (tabla[i] != null) ? tabla[i].ToString() : "vacío";
            Console.WriteLine("[" + i + "] => " + contenido);
        }
    }
}
