using System.Collections.Generic;
using System.Linq;

namespace ProblemMaksymalnejKliki
{
    class Clique
    {
        public List<Vertex> vertexList { get; set; }

        public Clique(List<Vertex> vl)
        {
            vertexList = new List<Vertex>(vl);
        }

        public int Count()
        {
            return vertexList.Count;
        }

        public Vertex this[int index]
        {
            get { return vertexList[index]; }
            set { vertexList.Insert(index, value); }
        }

        public void OrderByID()
        {
            vertexList = vertexList.OrderBy(x => x.Id).ToList();
        }

        public override string ToString()
        {
            return $"Klika (długość {vertexList.Count}) { string.Join(", ", vertexList.Select(v => v.Id))}";
        }
    }

    class CliqueEqualityComparer : IEqualityComparer<Clique>
    {
        public bool Equals(Clique x, Clique y)
        {
            if (y == null)
            {
                return false;
            }
            else
            {
                if (x.Count() != y.Count())
                {
                    return false;
                }
                else
                {
                    for (var i = 0; i < x.Count(); i++)
                    {
                        if (x[i].Id != y[i].Id)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int GetHashCode(Clique obj)
        {
            var test = obj.ToString().GetHashCode();
            return test;
        }
    }
}