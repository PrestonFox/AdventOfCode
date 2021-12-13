using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace Day12
{
    class Program
    {
       
        static void Main(string[] args)
        {
            GraphTraverse graphTraverse = new GraphTraverse();
            Console.WriteLine(graphTraverse.SolvePartOne());
            Console.WriteLine(graphTraverse.SolvePartTwo());

            Console.ReadLine();           
        }

        
    }
}



