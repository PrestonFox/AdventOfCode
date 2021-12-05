using System;
using System.IO;
using System.Collections;

namespace Problem_2
{
    public class CSVReader
    {
        public ArrayList ReadCSVFile(string filePath){
            ArrayList results = new ArrayList();
            using(var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    results.Add(reader.ReadLine());
                }
            }
            return results;
        }
    }
}


