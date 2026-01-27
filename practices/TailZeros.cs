using System;

public class HelloWorld
{
    public static int[] TailZeros(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            if (arr[left] == 0)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                right--; // move tail backward
            }
            else
            {
                left++; // move forward if non-zero
            }
        }
        return arr;
    }

    public static void Main(string[] args)
    {
        int[][] testCases = new int[][]
        {
            new int[] {1, 0, 2, 0, 3, 0, 4},
            new int[] {0, 0, 0, 1, 2, 3},
            new int[] {1, 2, 3, 0, 0},
            new int[] {0, 0, 0, 0},
            new int[] {1, 2, 3, 4},
            new int[] {0},
            new int[] {5},
            new int[] {}
        };

        foreach (var test in testCases)
        {
            Console.WriteLine("Input : " + string.Join(", ", test));
            TailZeros(test);
            Console.WriteLine("Output: " + string.Join(", ", test));
            Console.WriteLine("--------");
        }
    }
}
