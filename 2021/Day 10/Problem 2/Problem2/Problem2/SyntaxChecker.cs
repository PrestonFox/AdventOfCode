using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    public class SyntaxChecker
    {

        public long CalculateScore(string[] input)
        {
            List<Stack<char>> openings = new List<Stack<char>>();
            Stack<char> opening = new Stack<char>();
            Dictionary<char, int> scoringMatrix = new Dictionary<char, int>();
            scoringMatrix.Add(')', 1);
            scoringMatrix.Add(']', 2);
            scoringMatrix.Add('}', 3);
            scoringMatrix.Add('>', 4);

            bool illegal = false;
            foreach (var line in input)
            {
                illegal = false;
                opening.Clear();
                foreach (var symbol in line)
                {
                    if (new[] { '(', '[', '{', '<' }.Any(ch => symbol.ToString().Contains(ch)))
                    {
                        opening.Push(symbol);
                    }
                    else
                    {
                        if (opening.Peek() == '(' && symbol == ')') { opening.Pop(); }
                        else if (opening.Peek() == '[' && symbol == ']') { opening.Pop(); }
                        else if (opening.Peek() == '{' && symbol == '}') { opening.Pop(); }
                        else if (opening.Peek() == '<' && symbol == '>') { opening.Pop(); }
                        else 
                        { 
                            illegal = true; 
                            break; 
                        }
                    }
                }
                if (!illegal) 
                { 
                    openings.Add(new Stack<char>(opening)); 
                }
            }

            string[] addedSymbols = new string[openings.Count];
            for (int i = 0; i < openings.Count; i++)
            {
                while (openings[i].Count > 0)
                {
                    if (openings[i].Peek() == '(') { addedSymbols[i] += ")"; openings[i].Pop(); }
                    else if (openings[i].Peek() == '[') { addedSymbols[i] += "]"; openings[i].Pop(); }
                    else if (openings[i].Peek() == '{') { addedSymbols[i] += "}"; openings[i].Pop(); }
                    else if (openings[i].Peek() == '<') { addedSymbols[i] += ">"; openings[i].Pop(); }
                }
            }

            List<long> scores = new List<long>();
            for (int i = 0; i < addedSymbols.Length; i++)
            {
                long score = 0;
                foreach (var symbol in addedSymbols[i].Reverse())
                {
                    score = 5 * score + scoringMatrix[symbol];
                }
                scores.Add(score);
            }
            scores.Sort();
            return scores[scores.Count / 2];
        }
    }
}
