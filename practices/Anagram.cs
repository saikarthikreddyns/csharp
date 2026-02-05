using System;
using System.Linq;

public class Anagram
{
    public static bool IsAnagram(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        char[] c1 = s1.ToLower().ToArray();
        char[] c2 = s2.ToLower().ToArray();

        Array.Sort(c1);
        Array.Sort(c2);

        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i] != c2[i])
                return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        string[,] testCases = {
            {"listen", "silent"},
            {"race", "care"},
            {"hello", "world"},
            {"Dormitory", "Dirtyroom"},
            {"abc", "ab"}
        };

        for (int i = 0; i < testCases.GetLength(0); i++)
        {
            string s1 = testCases[i, 0];
            string s2 = testCases[i, 1];

            Console.WriteLine($"{s1} & {s2} → {IsAnagram(s1, s2)}");
        }
    }
}
