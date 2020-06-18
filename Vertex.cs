using System.Collections.Generic;

namespace ProblemMaksymalnejKliki
{
    public class Vertex
    {
        public Vertex(int id)
        {
            Id = id;
            AdjacentVertices = new List<Vertex>();
        }

        public int Id { get; set; }
        public int EdgeCount { get; set; }
        public List<Vertex> AdjacentVertices { get; set; }
        public int Degree => AdjacentVertices.Count;

        public override string ToString()
        {
            return $"Wierzchołek {Id} stopnia {Degree}.";
        }
    }
}
