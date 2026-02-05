using System;

public class EliminateSpaces
{
    public static void NoSpaces(string s)
    {
        string[] parts = s.Split(' ');

        for (int i = 0; i < parts.Length; i++)
        {
            Console.Write(parts[i]);
        }

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        NoSpaces("I love CSharp");
        NoSpaces("Hello   World  Again");
        NoSpaces(" Remove all spaces ");
    }
}
