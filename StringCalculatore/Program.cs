internal class Program
{
    private static void Main(string[] args)
    {
        string input = "9 + 10 + 1";

        // Creating List to store the clean numbers
        List<int> numbers= new List<int>();

        // I need to split the string into different parts, where the operators are.
        // However I need to take the operator into account.

        string[] values = input.Split('+');

        // check length of array and iterate as often through the array
        foreach (string value in values)
        {
            int number = int.Parse(value.Trim());
            numbers.Add(number);
        }

        // Adding all values together
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Printing the result
        Console.WriteLine(sum);

    }
}