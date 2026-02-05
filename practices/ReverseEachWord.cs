using System;

public class ReverseEachWord
{
    public static void ReverseWords(string s)
    {
        string[] words = s.Split(' ');

        foreach (string word in words)
        {
            char[] arr = word.ToCharArray();
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                char temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                left++;
                right--;
            }

            Console.Write(new string(arr) + " ");
        }
        Console.WriteLine(); // new line after each test case
    }

    public static void Main()
    {
        string[] testCases = {
            "I love CSharp",
            "Hello World",
            "Programming is fun",
            "Reverse each word"
        };

        foreach (string test in testCases)
        {
            Console.WriteLine("Input : " + test);
            Console.Write("Output: ");
            ReverseWords(test);
            Console.WriteLine();
        }
    }
}
