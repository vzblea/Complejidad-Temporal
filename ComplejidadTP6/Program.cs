using System;
using System.Collections.Generic;

namespace tp7
{
    class Program
    {
        public static void Main(string[] args)
        {
            Grafo<string> grafo = new Grafo<string>();

            // Crear vértices
            Vertice<string> origen = new Vertice<string>("origen");
            Vertice<string> alfaRomeo = new Vertice<string>("Alfa Romeo");
            Vertice<string> mercedes = new Vertice<string>("Mercedes");
            Vertice<string> ferrari = new Vertice<string>("Ferrari");
            Vertice<string> mclaren = new Vertice<string>("McLaren");
            Vertice<string> williams = new Vertice<string>("Williams");
            Vertice<string> lotus = new Vertice<string>("Lotus");
            Vertice<string> toleman = new Vertice<string>("Toleman");

            // Agregar vértices al grafo
            grafo.agregarVertice(origen);
            grafo.agregarVertice(alfaRomeo);
            grafo.agregarVertice(mercedes);
            grafo.agregarVertice(ferrari);
            grafo.agregarVertice(mclaren);
            grafo.agregarVertice(williams);
            grafo.agregarVertice(lotus);
            grafo.agregarVertice(toleman);

            // Fangio: Alfa Romeo → Mercedes → Ferrari
            grafo.conectar(origen, alfaRomeo, 1);     // Fangio
            grafo.conectar(alfaRomeo, mercedes, 1);   // Fangio
            grafo.conectar(mercedes, ferrari, 1);     // Fangio

            // Prost: Ferrari → McLaren → Williams
            grafo.conectar(origen, ferrari, 1);       // Prost
            grafo.conectar(ferrari, mclaren, 1);      // Prost
            grafo.conectar(mclaren, williams, 1);     // Prost

            // Senna: Toleman → Lotus → McLaren → Williams
            grafo.conectar(origen, toleman, 1);       // Senna
            grafo.conectar(toleman, lotus, 1);        // Senna
            grafo.conectar(lotus, mclaren, 1);        // Senna
            grafo.conectar(mclaren, williams, 1);     // Senna

            // Clark: Lotus
            grafo.conectar(origen, lotus, 1);         // Clark

            // Ejecutar búsqueda del piloto con más escuderías
            MercadoDePilotos mercado = new MercadoDePilotos();
            List<string> camino = mercado.PilotoQuePasoPorMasEscuderias(grafo);

            // Mostrar resultado
            Console.WriteLine("El camino más largo es:");
            foreach (string escuderia in camino)
            {
                Console.WriteLine(escuderia);
                Console.ReadKey();
               
            }
        }
    }
}
