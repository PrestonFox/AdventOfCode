using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    public class CSVReader
    {
        public List<string> ReadCSVFile(string filePath)
        {
            List<string> results = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                string line = string.Empty;
                while (!reader.EndOfStream)
                {
                    results.AddRange(reader.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries));
                }
            }
            return results;
        }
    }
}