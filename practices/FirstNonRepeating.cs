using System;

public class FirstNonRepeating
{
    public static char FirstUnique(string s)
    {
        int[] freq = new int[256];

        // Step 1: Count frequency
        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i]]++;
        }

        // Step 2: Find first non-repeating
        for (int i = 0; i < s.Length; i++)
        {
            if (freq[s[i]] == 1)
            {
                return s[i];
            }
        }

        return '\0'; // if none found
    }

    public static void Main()
    {
        Console.WriteLine(FirstUnique("programming"));  // p
        Console.WriteLine(FirstUnique("aabbccde"));     // d
        Console.WriteLine(FirstUnique("aabb"));         // none
    }
}
