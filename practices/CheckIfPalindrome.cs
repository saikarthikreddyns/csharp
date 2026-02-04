using System;

public class CheckPalindromeArray
{
    public static bool IsPalindrome(string[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            if (arr[left] != arr[right])
            {
                return false;   // mismatch = not palindrome
            }
            left++;
            right--;
        }

        return true; // all matched
    }

    public static void Main(string[] args)
    {
        string[] arr1 = { "a", "b", "c", "b", "a" };
        string[] arr2 = { "a", "b", "c", "d" };

        Console.WriteLine(IsPalindrome(arr1)); // True
        Console.WriteLine(IsPalindrome(arr2)); // False
    }
}
