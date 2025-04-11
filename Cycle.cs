using System;
using System.Collections.Generic;
using QuickGraph;

namespace MyGraphProject
{
    public static class CycleFinder
    {
        /// <summary>
        /// Znajduje wszystkie cykle w grafie zaczynające się i kończące w zadanym wierzchołku.
        /// </summary>
        /// <param name="graph">Graf skierowany</param>
        /// <param name="start">Wierzchołek początkowy i końcowy cykli</param>
        /// <returns>Lista cykli – każdy cykl to lista nazw wierzchołków</returns>
        public static List<List<string>> FindCyclesFrom(
            AdjacencyGraph<string, WeightedEdge> graph,
            string start)
        {
            var cycles = new List<List<string>>();
            var visited = new HashSet<string>();
            var path = new List<string>();

            void DFS(string current)
            {
                visited.Add(current);
                path.Add(current);

                foreach (var edge in graph.OutEdges(current))
                {
                    if (edge.Target == start && path.Count > 1)
                    {
                        var cycle = new List<string>(path) { start };
                        cycles.Add(cycle);
                    }
                    else if (!visited.Contains(edge.Target))
                    {
                        DFS(edge.Target);
                    }
                }

                visited.Remove(current);
                path.RemoveAt(path.Count - 1);
            }

            DFS(start);
            return cycles;
        }
    }
}
