using System.Collections.Generic;
using System.Linq;

namespace ProblemMaksymalnejKliki
{
    class BronKerbosch
    {
        public List<Clique> Cliques { get; set; }

        public List<Clique> FindCliques(Graph graph)
        {
            Cliques = new List<Clique>();

            if (graph.VertexCount > 1)
            {
                FindCliques(new List<Vertex>(), graph.Vertices, new List<Vertex>());
            }

            return Cliques;
        }

        public void FindCliques(List<Vertex> clique, List<Vertex> candidates, List<Vertex> excludedCandidates)
        {
            if (!candidates.Any() && !excludedCandidates.Any())
            {
                Cliques.Add(new Clique(clique));
            }

            var pivotNeighbors = new List<Vertex>();
            foreach (var candidate in CreateUnion(candidates, excludedCandidates))
            {
                var t = CreateIntersection(candidate.AdjacentVertices, candidates);
                if (t.Count > pivotNeighbors.Count)
                {
                    pivotNeighbors = t;
                }
            }

            foreach (var candidate in CreateDifference(candidates, pivotNeighbors))
            {
                var candidateNeighbors = candidate.AdjacentVertices;

                var tempList = new List<Vertex>(clique);
                tempList.Add(candidate);

                FindCliques(
                    tempList,
                    CreateIntersection(candidates, candidateNeighbors),
                    CreateIntersection(excludedCandidates, candidateNeighbors));

                candidates.Remove(candidate);
                excludedCandidates.Add(candidate);
            }
        }

        #region Helper functions
        public List<Vertex> CreateUnion(List<Vertex> set, List<Vertex> otherSet)
        {
            var result = new List<Vertex>(set);
            foreach (var value in otherSet)
            {
                result.Add(value);
            }
            return result;
        }

        public List<Vertex> CreateIntersection(List<Vertex> set, List<Vertex> otherSet)
        {
            var result = new List<Vertex>();
            foreach (var value in otherSet)
            {
                if (set.Contains(value))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        public List<Vertex> CreateDifference(List<Vertex> set, List<Vertex> otherSet)
        {
            var result = new List<Vertex>(set);
            foreach (var value in otherSet)
            {
                result.Remove(value);
            }
            return result;
        }

        public List<Clique> RemoveDuplicatedLists()
        {
            var sourceList = new List<Clique>(Cliques);

            var maxCliqueVertexCount = sourceList.Max(c => c.Count());
            sourceList.RemoveAll(c => c.Count() != maxCliqueVertexCount);
            sourceList.ForEach(c => c.OrderByID());

            CliqueEqualityComparer cliqueEqualityComparer = new CliqueEqualityComparer();
            sourceList = sourceList.Distinct(cliqueEqualityComparer).ToList();

            return sourceList;
        }
        #endregion Helper functions
    }
}
