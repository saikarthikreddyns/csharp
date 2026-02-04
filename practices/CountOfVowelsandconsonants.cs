using System;

public class CountVowelsAndCons
{
    public static void Counts(string s)
    {
        string vowels = "aeiouAEIOU";
        int vowelsCount = 0;
        int consonants = 0;

        foreach (char c in s)
        {
            if (char.IsLetter(c))
            {
                if (vowels.Contains(c))
                    vowelsCount++;
                else
                    consonants++;
            }
        }

        Console.WriteLine($"Vowels: {vowelsCount}, Consonants: {consonants}");
    }

    public static void Main()
    {
        int t = int.Parse(Console.ReadLine()); // number of test cases

        for (int i = 0; i < t; i++)
        {
            string input = Console.ReadLine();
            Counts(input);
        }
    }
}
