using System;
using System.IO;
using System.Collections;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int depthIncreased = 0;
            ArrayList depths = new ArrayList();

            using(var reader = new StreamReader(@"/Users/pfox/Desktop/Dev/Credera/AdventOfCode/2021/Day 1/Problem 1/Problem1Inputs.csv"))
            {
                while (!reader.EndOfStream)
                {
                    depths.Add(reader.ReadLine());
                   //Console.WriteLine(reader.ReadLine());
                }
            }

            
            for(int i = 0; i < depths.Count-1; i++)
            {
                if (int.Parse((string)depths[i]) < int.Parse((string)depths[i+1])){
                    depthIncreased++;
                }

                if (i == depths.Count-2){
                    Console.WriteLine(int.Parse((string)depths[i+1]));
                    Console.WriteLine("At the end?");
                }
            }
            Console.WriteLine(depthIncreased);
            Console.ReadLine();
        }
    }
}
