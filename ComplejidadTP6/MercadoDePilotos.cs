using System;
using System.Collections.Generic;

namespace tp7
{
    public class MercadoDePilotos
    {
        public List<string> PilotoQuePasoPorMasEscuderias(Grafo<string> escuderias)
        {
            Vertice<string> origen = null;

            // Buscar el vértice "origen"
            foreach (Vertice<string> v in escuderias.getVertices())
            {
                if (v.getDato().Equals("origen"))
                {
                    origen = v;
                    break;
                }
            }

            if (origen == null)
                return new List<string>(); // No hay origen

            List<string> caminoActual = new List<string>();
            List<string> mejorCamino = new List<string>();

            DFS(origen, caminoActual, mejorCamino);

            return mejorCamino;
        }

        private void DFS(Vertice<string> actual, List<string> caminoActual, List<string> mejorCamino)
        {
            foreach (Arista<string> arista in actual.getAdyacentes())
            {
                Vertice<string> destino = arista.getDestino();
                string nombreEscuderia = destino.getDato();

                if (!caminoActual.Contains(nombreEscuderia))
                {
                    caminoActual.Add(nombreEscuderia);

                    if (caminoActual.Count > mejorCamino.Count)
                        mejorCamino.Clear();
                        mejorCamino.AddRange(caminoActual);

                    DFS(destino, caminoActual, mejorCamino);

                    caminoActual.RemoveAt(caminoActual.Count - 1);
                }
            }
        }
    }
}
