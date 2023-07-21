using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = "9*10+5*10+10/10";

        // Digits and Operators
        Regex regexDigOp = new Regex(@"\d+|[+\-*/]");

        // List to store values and operators
        List<string> substrings = new List<string>();
        List<string> substringsOut = new List<string>();

        // Get Matches and store in List
        MatchCollection matches = regexDigOp.Matches(input);
        foreach (Match match in matches)
        {
            substrings.Add(match.Value);
        }

        // Multiplicate first all values
        for (int i = 0; i <= substrings.Count; i++)
        {
            if (substrings[i].Equals("*"))
            {
                int index = substrings.IndexOf(substrings[i]);
                int product = int.Parse(substrings[index - 1]) * int.Parse(substrings[index+1]);
                substrings.Insert((index + 2), product.ToString());
                substrings.RemoveRange((index-1), 3);
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
                substrings.Insert((index +2), quotient.ToString());
                substrings.RemoveRange((index - 1), 3);
            }
        }


        foreach(string s in substrings)
        {
            Console.WriteLine(s);
        }
    }
}