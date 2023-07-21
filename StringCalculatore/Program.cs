using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = "9*10+5";

        // Digits and Operators
        Regex regexDigOp = new Regex(@"[\d+\+\*\-/]");

        // Function

        string CleanString (string s)
        {
            if( string.IsNullOrEmpty(s))
                return s;
            StringBuilder sb = new StringBuilder();
            for (Match m = regexDigOp.Match(s); m.Success; m = m.NextMatch())
            {
                sb.Append(m.Value);
            }

            string cleaned = sb.ToString();
            return cleaned;
        }

        input= CleanString(input);

        // Creating a List to store the numbers
        List<int> nums = new List<int>();

        string[] substrings = input.Split('+', '*', '-', '/');
        foreach(string substring in substrings)
        {
            int number;
            if(int.TryParse(substring, out number))
            {
                nums.Add(number);
            }
        }

        Console.WriteLine(input);

    }
}