using System;
using System.IO;
using System.Collections;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int depthIncreased = 0;
            ArrayList depths = new ArrayList();

            using(var reader = new StreamReader(@"/Users/pfox/Desktop/Dev/Credera/AdventOfCode/2021/Day 1/Problem 2/Problem2Inputs.csv"))
            {
                while (!reader.EndOfStream)
                {
                    depths.Add(reader.ReadLine());
                   //Console.WriteLine(reader.ReadLine());
                }
            }

            for(int i = 0; i < depths.Count-3; i++)
            {
                int value1 = int.Parse((string)depths[i]);
                int value2 = int.Parse((string)depths[i+1]);
                int value3 = int.Parse((string)depths[i+2]);
                int value4 = int.Parse((string)depths[i+3]);

                if ((value1+value2+value3) < (value2+value3+value4)){
                    depthIncreased++;
                }

                if (i == depths.Count-4){
                    Console.WriteLine(int.Parse((string)depths[i+3]));
                    Console.WriteLine("At the end?");
                }
            }
            Console.WriteLine(depthIncreased);
            Console.ReadLine();
        }
    }
}