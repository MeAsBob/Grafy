using System;
using System.Collections.Generic;
using QuickGraph;

namespace MyGraphProject
{
    // Klasa reprezentująca ważoną krawędź
    public class WeightedEdge : IEdge<string>
    {
        public string Source { get; }
        public string Target { get; }
        public int Weight { get; }

        public WeightedEdge(string source, string target, int weight)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }
    }

    // Algorytmy grafowe
    public static class GraphAlgorithms
    {
        public static Dictionary<string, int> Dijkstra(AdjacencyGraph<string, WeightedEdge> graph, string source)
        {
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var queue = new HashSet<string>();

            foreach (var vertex in graph.Vertices)
            {
                distances[vertex] = int.MaxValue;
                previous[vertex] = null;
                queue.Add(vertex);
            }

            distances[source] = 0;

            while (queue.Count > 0)
            {
                string u = null;
                int minDist = int.MaxValue;

                // Znajdź wierzchołek z najmniejszą odległością
                foreach (var v in queue)
                {
                    if (distances[v] < minDist)
                    {
                        minDist = distances[v];
                        u = v;
                    }
                }

                if (u == null)
                    break;

                queue.Remove(u);

                foreach (var edge in graph.OutEdges(u))
                {
                    var v = edge.Target;
                    if (!queue.Contains(v)) continue;

                    int alt = distances[u] + edge.Weight;
                    if (alt < distances[v])
                    {
                        distances[v] = alt;
                        previous[v] = u;
                    }
                }
            }

            return distances;
        }
    }
}
