using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class SyntaxChecker
    {
        public int ScoreCorruptCharacters(string[] input)
        {
            Dictionary<char, int> scoringMatrix = new Dictionary<char, int>();
            scoringMatrix.Add(')', 3);
            scoringMatrix.Add(']', 57);
            scoringMatrix.Add('}', 1197);
            scoringMatrix.Add('>', 25137);

            List<char> corruptCharacters = new List<char>();
            Stack<char> openings = new Stack<char>();

            foreach (var line in input)
            {
                foreach (var character in line)
                {
                    if (new[] { '(', '[', '{', '<' }.Any(ch => character.ToString().Contains(ch)))
                    {
                        openings.Push(character);
                    }
                    else
                    {
                        if (openings.Peek() == '(' && character == ')') { openings.Pop(); }
                        else if (openings.Peek() == '[' && character == ']') { openings.Pop(); }
                        else if (openings.Peek() == '{' && character == '}') { openings.Pop(); }
                        else if (openings.Peek() == '<' && character == '>') { openings.Pop(); }
                        else { corruptCharacters.Add(character); break; }
                    }
                }
            }

            int score = 0;
            foreach (var symbol in corruptCharacters) 
            { 
                score += scoringMatrix[symbol]; 
            }
            return score;

        }
    }
}
