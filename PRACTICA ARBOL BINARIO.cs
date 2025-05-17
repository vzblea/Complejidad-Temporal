using System;
using System.Collections.Generic;

namespace EntregaVirtual
{
    // Excepción personalizada para manejar errores específicos del árbol binario
    public class MiExcepcionPersonalizada : Exception
    {
        public MiExcepcionPersonalizada(string mensaje) : base(mensaje) { }
    }

    public class ArbolBinario<T>
    {
        private T dato; // Valor del nodo
        private ArbolBinario<T> hijoIzquierdo;
        private ArbolBinario<T> hijoDerecho;

        public ArbolBinario(T dato)
        {
            this.dato = dato;
        }

        // Getters y setters
        public T getDatoRaiz() => this.dato;
        public void setDatoRaiz(T datoRaiz) => this.dato = datoRaiz;
        public ArbolBinario<T> getHijoIzquierdo() => this.hijoIzquierdo;
        public ArbolBinario<T> getHijoDerecho() => this.hijoDerecho;

        // Métodos
        public void agregarHijoIzquierdo(ArbolBinario<T> hijo) => this.hijoIzquierdo = hijo;
        public void agregarHijoDerecho(ArbolBinario<T> hijo) => this.hijoDerecho = hijo;
        public void eliminarHijoIzquierdo() => this.hijoIzquierdo = null;
        public void eliminarHijoDerecho() => this.hijoDerecho = null;
        public bool esHoja() => this.hijoIzquierdo == null && this.hijoDerecho == null;

        public bool incluye(T elemento)
        {
            if (this.dato.Equals(elemento)) return true;
            bool valorIzq = this.hijoIzquierdo?.incluye(elemento) ?? false;
            return valorIzq || (this.hijoDerecho?.incluye(elemento) ?? false);
        }

        public void inorden()
        {
            this.hijoIzquierdo?.inorden();
            Console.Write(dato + " ");
            this.hijoDerecho?.inorden();
        }

        public void preorden()
        {
            Console.Write(dato + " ");
            this.hijoIzquierdo?.preorden();
            this.hijoDerecho?.preorden();
        }

        public void postorden()
        {
            this.hijoIzquierdo?.postorden();
            this.hijoDerecho?.postorden();
            Console.Write(dato + " ");
        }

        public int contarHojas()
        {
            if (esHoja()) return 1;
            int hojasIzq = this.hijoIzquierdo?.contarHojas() ?? 0;
            int hojasDer = this.hijoDerecho?.contarHojas() ?? 0;
            return hojasIzq + hojasDer;
        }

        public void recorridoEntreNiveles(int n, int m)
        {
            List<Tuple<ArbolBinario<T>, int>> lista = new List<Tuple<ArbolBinario<T>, int>>
            {
                new Tuple<ArbolBinario<T>, int>(this, 0)
            };

            while (lista.Count > 0)
            {
                var current = lista[0];
                var nodo = current.Item1;
                int nivel = current.Item2;
                lista.RemoveAt(0);

                if (nivel >= n && nivel <= m)
                    Console.Write(nodo.dato + " ");

                if (nodo.hijoIzquierdo != null)
                    lista.Add(new Tuple<ArbolBinario<T>, int>(nodo.hijoIzquierdo, nivel + 1));

                if (nodo.hijoDerecho != null)
                    lista.Add(new Tuple<ArbolBinario<T>, int>(nodo.hijoDerecho, nivel + 1));
            }
        }

        public ArbolBinario<int> enunciadoNuevoArbol(ArbolBinario<int> arbol)
        {
            if (arbol == null)
                throw new MiExcepcionPersonalizada("El parámetro ingresado está vacío");

            var nuevoArbol = new ArbolBinario<int>(arbol.getDatoRaiz());

            if (arbol.getHijoIzquierdo() != null)
            {
                nuevoArbol.agregarHijoIzquierdo(enunciadoNuevoArbol(arbol.getHijoIzquierdo()));
                nuevoArbol.getHijoIzquierdo().setDatoRaiz(arbol.getDatoRaiz() + arbol.getHijoIzquierdo().getDatoRaiz());
            }

            if (arbol.getHijoDerecho() != null)
                nuevoArbol.agregarHijoDerecho(enunciadoNuevoArbol(arbol.getHijoDerecho()));

            return nuevoArbol;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var raiz = new EntregaVirtual.ArbolBinario<int>(1);
        var nodo2 = new EntregaVirtual.ArbolBinario<int>(2);
        var nodo3 = new EntregaVirtual.ArbolBinario<int>(3);
        var nodo4 = new EntregaVirtual.ArbolBinario<int>(4);
        var nodo5 = new EntregaVirtual.ArbolBinario<int>(5);
        var nodo6 = new EntregaVirtual.ArbolBinario<int>(6);
        var nodo7 = new EntregaVirtual.ArbolBinario<int>(7);

        raiz.agregarHijoIzquierdo(nodo2);
        raiz.agregarHijoDerecho(nodo3);
        nodo2.agregarHijoIzquierdo(nodo4);
        nodo3.agregarHijoIzquierdo(nodo5);
        nodo3.agregarHijoDerecho(nodo6);
        nodo5.agregarHijoIzquierdo(nodo7);

        Console.Write("\nArbol normal, recorrido entre niveles: ");
        raiz.recorridoEntreNiveles(0, 3);
        Console.Write("\nArbol normal, recorrido preorden: ");
        raiz.preorden();

        try
        {
            var nuevoArbol = raiz.enunciadoNuevoArbol(raiz);
            Console.Write("\nArbol nuevo, recorrido entre niveles: ");
            nuevoArbol.recorridoEntreNiveles(0, 3);
            Console.Write("\nArbol nuevo, recorrido preorden: ");
            nuevoArbol.preorden();
        }
        catch (EntregaVirtual.MiExcepcionPersonalizada ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadKey();
    }
}
