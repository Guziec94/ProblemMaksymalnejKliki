using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProblemMaksymalnejKliki
{
    /// <summary>
    /// Algorytm Brona-Kerboscha
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph;
            Console.Write("Czy chcesz załadować jeden z przygotowanych przykładów? (T/N) ");
            ConsoleKey clickedKey = Console.ReadKey().Key;
            if (clickedKey == ConsoleKey.T)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
                var files = directoryInfo.GetFiles("*.txt", SearchOption.AllDirectories);
                Console.Write($"\nWybierz numer przykładu (0-{files.Length - 1}): ");
                int exampleNumber = int.Parse(Console.ReadLine());
                var streamReader = new StreamReader(files[exampleNumber].FullName);

                int vertexCount = int.Parse(streamReader.ReadLine());

                graph = new Graph(vertexCount);

                int edgeCount = int.Parse(streamReader.ReadLine());

                for (int i = 0; i < edgeCount; i++)
                {
                    string edge = streamReader.ReadLine();
                    var temp = edge.Split(' ');

                    int vertexA = int.Parse(temp[0]);
                    int vertexB = int.Parse(temp[1]);

                    graph.AddEdge(vertexA, vertexB);
                }
            }
            else
            {
                Console.Write("\nPodaj liczbę wierzchołków grafu: ");
                int vertexCount = int.Parse(Console.ReadLine());

                graph = new Graph(vertexCount);

                Console.WriteLine("Podaj liczbę ścieżek, które chcesz dodać: ");
                int edgeCount = int.Parse(Console.ReadLine());

                Console.WriteLine($"Podaj {edgeCount} ścieżek (każda w osobnej linii, wierzchołki oddzielone spacją): ");
                for (int i = 0; i < edgeCount; i++)
                {
                    string edge = Console.ReadLine();
                    var temp = edge.Split(' ');

                    int vertexA = int.Parse(temp[0]);
                    int vertexB = int.Parse(temp[1]);

                    graph.AddEdge(vertexA, vertexB);
                }
            }

            Console.Write("\n\n");

            BronKerbosch bronKerbosch = new BronKerbosch();
            bronKerbosch.FindCliques(graph);
            List<Clique> cliques = bronKerbosch.RemoveDuplicatedLists();

            if (cliques.Any())
            {
                Console.WriteLine($"Maksymalna klika jest długości: {cliques.FirstOrDefault().Count()}");
                Console.WriteLine("Znalezione maksymalne kliki:");
                foreach (var clique in cliques)
                {
                    Console.WriteLine(clique);
                }
            }
            else
            {
                Console.WriteLine("Graf nie zawiera żadnej klliki");
            }

            Console.WriteLine("\nKONIEC");
            Console.ReadKey();
        }
    }
}
