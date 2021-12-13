using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 11\Problem 1\Problem1\Problem1\Inputs.csv");
            var grid = input
                .Select(line => line.Select(c => c - '0').ToArray())
                .ToArray();

            IEnumerable<(int y, int x)> adjacent(int y, int x)
            {
                if (x > 0) yield return (y, x - 1);
                if (y > 0) yield return (y - 1, x);
                if (x < grid[y].Length - 1) yield return (y, x + 1);
                if (y < grid.Length - 1) yield return (y + 1, x);

                if (x > 0 && y > 0) yield return (y - 1, x - 1);
                if (x > 0 && y < grid.Length - 1) yield return (y + 1, x - 1);
                if (x < grid[y].Length - 1 && y > 0) yield return (y - 1, x + 1);
                if (x < grid[y].Length - 1 && y < grid.Length - 1) yield return (y + 1, x + 1);
            }

            int increment(int y, int x, HashSet<(int y, int x)> flashed)
            {
                if (flashed.Contains((y, x))) return 0;
                grid[y][x]++;
                if (grid[y][x] <= 9) return 0;

                grid[y][x] = 0;
                flashed.Add((y, x));
                return 1 + adjacent(y, x).Sum(a => increment(a.y, a.x, flashed));
            }

            int step()
            {
                var flashed = new HashSet<(int y, int x)>();
                for (int row = 0; row < grid.Length; ++row)
                {
                    for (int col = 0; col < grid[row].Length; ++col)
                    {
                        increment(row, col, flashed);
                    }
                }
                return flashed.Count;
            }

            var part1 = Enumerable.Range(0, 100).Sum(i => step());
            Console.WriteLine($"Part 1: {part1}");

            var part2 = 101;
            while (step() != 100) ++part2;
            Console.WriteLine($"Part 2: {part2}");
            Console.ReadLine();
        }
    }
}
