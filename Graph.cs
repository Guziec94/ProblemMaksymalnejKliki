using System.Collections.Generic;
using System.Linq;

namespace ProblemMaksymalnejKliki
{
    public class Graph
    {
        public Graph(int vertexCount)
        {
            VertexCount = vertexCount;
            Vertices = new List<Vertex>(vertexCount);
            Vertices = Enumerable.Range(0, vertexCount)
                .Select(v => new Vertex(v))
                .ToList();
        }

        public int VertexCount { get; set; }
        public List<Vertex> Vertices { get; set; }

        public void AddEdge(int vertexA, int vertexB)
        {
            Vertices[vertexB].AdjacentVertices.Add(Vertices[vertexA]);
            Vertices[vertexA].AdjacentVertices.Add(Vertices[vertexB]);
        }
    }
}
