using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day12
{   
    public class GraphTraverse
    {
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        private HashSet<List<Node>> part1Paths = new HashSet<List<Node>>();
        private HashSet<List<Node>> part2Paths = new HashSet<List<Node>>();
        private List<Node> currentPath = new List<Node>();
        private HashSet<string> visited = new HashSet<string>();
        private bool smolHasBeenVisitedTwice = false;
        private string smolCurrentlyVistedTwice = string.Empty;
        public string SolvePartOne()
        {
            var input = File.ReadAllLines(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 12\Problem 1\Day12\Day12\Input.csv");
            //UseDebugInput = true;
            foreach (var l in input)
            {
                var halves = l.Split('-');
                if (!nodes.ContainsKey(halves[0]))
                {
                    var tmp = new Node()
                    {
                        Name = halves[0],
                        IsSmolCave = char.IsLower(halves[0][0])
                    };
                    nodes[halves[0]] = tmp;
                }

                if (!nodes.ContainsKey(halves[1]))
                {
                    var tmp = new Node()
                    {
                        Name = halves[1],
                        IsSmolCave = char.IsLower(halves[1][0])
                    };
                    nodes[halves[1]] = tmp;
                }

                nodes[halves[0]].Neighbors.Add(halves[1]);
                nodes[halves[1]].Neighbors.Add(halves[0]);
            }
            FindAllPaths(nodes["start"]);
            currentPath.Clear();
            visited.Clear();
            return part1Paths.Count.ToString();
        }

        public string SolvePartTwo()
        {
            var input = File.ReadAllLines(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 12\Problem 1\Day12\Day12\Input.csv");
            //UseDebugInput = true;
            foreach (var l in input)
            {
                var halves = l.Split('-');
                if (!nodes.ContainsKey(halves[0]))
                {
                    var tmp = new Node()
                    {
                        Name = halves[0],
                        IsSmolCave = char.IsLower(halves[0][0])
                    };
                    nodes[halves[0]] = tmp;
                }

                if (!nodes.ContainsKey(halves[1]))
                {
                    var tmp = new Node()
                    {
                        Name = halves[1],
                        IsSmolCave = char.IsLower(halves[1][0])
                    };
                    nodes[halves[1]] = tmp;
                }

                nodes[halves[0]].Neighbors.Add(halves[1]);
                nodes[halves[1]].Neighbors.Add(halves[0]);
            }
            FindAllPaths(nodes["start"], true, true);
            currentPath.Clear();
            visited.Clear();
            return part2Paths.Count.ToString();
        }

        public class Node
        {
            public string Name { get; set; }
            public HashSet<string> Neighbors { get; set; } = new HashSet<string>();
            public bool IsSmolCave { get; set; } = false;

            public override string ToString()
            {
                return Name;
            }
        }

        private void FindAllPaths(Node curNode, bool isFirstPass = true, bool part2 = false)
        {
            if (curNode.Name == "start" && !isFirstPass) return;
            if (!part2)
            {
                if (visited.Contains(curNode.Name)) return;
                if (curNode.IsSmolCave) visited.Add(curNode.Name);
            }
            else
            {
                if (visited.Contains(curNode.Name) && smolHasBeenVisitedTwice) return;
                if (visited.Contains(curNode.Name))
                {
                    smolHasBeenVisitedTwice = true;
                    smolCurrentlyVistedTwice = curNode.Name;
                }
                else if (curNode.IsSmolCave) visited.Add(curNode.Name);
            }

            currentPath.Add(curNode);
            if (curNode.Name == "end")
            {
                if (!part2)
                {
                    part1Paths.Add(currentPath.ToList());
                }
                else
                {
                    part2Paths.Add(currentPath.ToList());
                }

                visited.Remove(curNode.Name);
                currentPath.RemoveAt(currentPath.Count - 1);
                return;
            }
            foreach (var n in curNode.Neighbors)
            {
                FindAllPaths(nodes[n], false, part2);
            }


            currentPath.RemoveAt(currentPath.Count - 1);

            if (!part2) visited.Remove(curNode.Name);
            else
            {
                if (curNode.Name == smolCurrentlyVistedTwice)
                {
                    smolCurrentlyVistedTwice = string.Empty;
                    smolHasBeenVisitedTwice = false;
                }
                else visited.Remove(curNode.Name);
            }
        }
    }
}
