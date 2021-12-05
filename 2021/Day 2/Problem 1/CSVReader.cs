using System;
using System.IO;
using System.Collections;

namespace Problem_1
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


