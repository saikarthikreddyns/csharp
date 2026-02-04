using System;

class FrequencyTest
{
    static void PrintFrequency(string s)
    {
        int[] freq = new int[256];   // ASCII characters

        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i]]++;
        }

        Console.WriteLine("Input: " + s);
        Console.WriteLine("Character : Frequency");

        for (int i = 0; i < 256; i++)
        {
            if (freq[i] > 0)
            {
                Console.WriteLine((char)i + " : " + freq[i]);
            }
        }

        Console.WriteLine("---------------------");
    }

    static void Main()
    {
        // ✅ Test case 1
        PrintFrequency("programming");

        // ✅ Test case 2
        PrintFrequency("hello");

        // ✅ Test case 3
        PrintFrequency("aaabbbcc");

        // ✅ Test case 4
        PrintFrequency("CSharp");

        // ✅ Test case 5
        PrintFrequency("112233");
    }
}
