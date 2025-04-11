using System;
using System.Collections.Generic;
using QuickGraph;
using MyGraphProject;

class Program
{
    static void Main()
    {
        var graph = new AdjacencyGraph<string, WeightedEdge>();
        List<string> litery = new List<string> { "A", "B", "C", "D", "E", "F","G","H","I","J","K"}; // Lista maksymalnej ilości wierzchołków i ich indentyfikatory
        Random los = new Random();
        int ilosc = los.Next(3, litery.Count);

        for (int i = 0; i < ilosc; i++) // Generacja wierzchołków na podstawie losowej wartości ilość(Min 3)
        {
            graph.AddVertex(litery[i]);
        }

        for (int i = 0; i < ilosc; i++) // Losowe krawędzie do każdego z wierzchołków
        {
            int targetIndex = los.Next(0, ilosc); // Sprawdzanie czy dana wartość nie jest taka samo tzn czy nie idzie do samej siebie
            if (targetIndex != i)
            {
                var edge = new WeightedEdge(litery[i], litery[targetIndex], los.Next(1, 10));
                graph.AddEdge(edge);
            }
        }

        for (int i = 0; i < 0; i++) // Zmienić tutaj w przypadku większej ilości krawiędzi
        {
            int targetIndex = los.Next(0, ilosc);
            int targetIndex2 = los.Next(0, ilosc);
            if (targetIndex != targetIndex2) // Sprawdzanie czy dana wartość nie jest taka samo tzn czy nie idzie do samej siebie
            {
                var edge = new WeightedEdge(litery[targetIndex], litery[targetIndex2], los.Next(1, 10));
                graph.AddEdge(edge);
            }
        }



        Console.WriteLine("Krawędzie w grafie:");
        foreach (var edge in graph.Edges) // Pokazuje Krawędzie
        {
            Console.WriteLine($"{edge.Source} -> {edge.Target} [waga: {edge.Weight}]");
        }


        string start = litery[0];
        //var distances = GraphAlgorithms.Dijkstra(graph, start); // Uruchamia Algorytm Dikstry. Start to litera początkowa do której idzie reszta

        //// Wyniki
        //Console.WriteLine($"\nNajkrótsze odległości od wierzchołka {start}:");
        //foreach (var kvp in distances)
        //{
        //    string value = kvp.Value == int.MaxValue ? "∞" : kvp.Value.ToString();
        //    Console.WriteLine($"{kvp.Key}: {value}");
        //}


        var cycles = CycleFinder.FindCyclesFrom(graph, start);

        // Wypisanie cykli
        foreach (var cycle in cycles)
        {
            Console.WriteLine(string.Join(" -> ", cycle));
        }
    }
}
