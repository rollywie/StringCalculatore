using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = "10*10+2";

        // Digits and Operators
        Regex regexDigOp = new Regex(@"\d+|[+\-*/]");

        // List to store values and operators
        List<string> substrings = new List<string>();

        // Get Matches and store in List
        MatchCollection matches = regexDigOp.Matches(input);
        foreach (Match match in matches)
        {
            substrings.Add(match.Value);
        }

        // Multiplicate first all values
        for (int i = 0; i <= substrings.Count-1; i++)
        {
            if (substrings[i].Equals("*"))
            {
                int index = substrings.IndexOf(substrings[i]);
                int product = int.Parse(substrings[index - 1]) * int.Parse(substrings[index+1]);
                if((index + 2) >= substrings.Count())
                {
                    substrings.Add(product.ToString());
                    substrings.RemoveRange((index-1), 3);
                }
                else
                {
                    substrings.Insert((index + 2), product.ToString());
                    substrings[index + 1] = null;
                    substrings[index] = null;
                    substrings.RemoveAt(index - 1);
                }
            }
            else if (substrings[i].Equals("/"))
            {
                int index = substrings.IndexOf(substrings[i]);
                if (int.Parse(substrings[index - 1]) == 0 || int.Parse(substrings[index + 1]) == 0)
                {
                    Console.WriteLine("We can not devide by 0");
                    return;
                }
                int quotient = int.Parse(substrings[index - 1]) / int.Parse(substrings[index + 1]);
                if ((index + 2) >= substrings.Count())
                {
                    substrings.Add(quotient.ToString());
                    substrings.RemoveRange((index -1), 3);
                }
                else
                {
                    substrings.Insert((index + 2), quotient.ToString());
                    substrings[index + 1] = null;
                    substrings[index] = null;
                    substrings.RemoveAt(index - 1);
                }
            }
        }

        // clean null vlues
        substrings.RemoveAll(item => item is null);

        // New List to operat on
        List<string> substrings2 = new List<string>();
        substrings2 = substrings;

        for (int i = 0 ; i <= substrings2.Count-1; i++)
        {
            if (substrings2[i].Equals("+"))
            {
                int sum = int.Parse(substrings2[i - 1]) + int.Parse(substrings2[i + 1]);
                if (i +2 >= substrings2.Count())
                {
                    substrings2.Add(sum.ToString());
                    substrings2.RemoveRange((i - 1), 3);
                }
                else
                {
                    substrings2.Insert((i + 2), sum.ToString());
                    substrings2[i + 1] = null;
                    substrings2[i] = null;
                    substrings2.RemoveAt(i - 1);
                }
            }
            else if (substrings2[i].Equals("-"))
            {
                int sum = int.Parse(substrings2[i - 1]) - int.Parse(substrings2[i + 1]);
                if (i + 2 >= substrings2.Count())
                {
                    substrings2.Add(sum.ToString());
                    substrings2.RemoveRange((i - 1), 3);
                }
                else
                {
                    substrings2.Insert((i + 2), sum.ToString());
                    substrings2[i + 1] = null;
                    substrings2[i] = null;
                    substrings2.RemoveAt(i - 1);
                }
            }
        }

        // clean null vlues
        substrings2.RemoveAll(item => item is null);

        foreach (string s in substrings2)
        {
             Console.WriteLine(s);
        }
    }
}