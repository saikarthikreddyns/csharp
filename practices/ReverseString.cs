using System;

public class ReverseString
{
    public static string ReverseStr(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        char[] arr = s.ToCharArray();

        while (left < right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            left++;
            right--;
        }

        return new string(arr);
    }

    public static void Main(string[] args)
    {
        Test("hello", "olleh");
        Test("a", "a");
        Test("", "");
        Test("madam", "madam");
        Test("hello world", "dlrow olleh");
        Test("12345", "54321");
        Test("@bc#", "#cb@");
    }

    static void Test(string input, string expected)
    {
        string result = ReverseStr(input);
        Console.WriteLine(
            $"Input: \"{input}\" | Output: \"{result}\" | Expected: \"{expected}\" | {(result == expected ? "PASS" : "FAIL")}"
        );
    }
}
