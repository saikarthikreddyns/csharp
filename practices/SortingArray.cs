using System;

public class SortingArray
{
    public static void SortArr(int[] arr)
    {
        for(int i = 0; i < arr.Length - 1; i++)
        {
            for(int j = 0; j < arr.Length - i - 1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        int[][] tests = {
            new int[]{5,2,9,1,3},
            new int[]{10,7,8,3,2},
            new int[]{1,2,3,4,5},
            new int[]{9,7,5,3,1},
            new int[]{4,2,2,8,4,1},
            new int[]{7},
            new int[]{5,5,5,5},
            new int[]{-3,4,-1,0,2},
            new int[]{100,-50,20,0,-10},
            new int[]{12,3,45,7,1,99,23}
        };

        foreach (var arr in tests)
        {
            SortArr(arr);

            foreach (var num in arr)
                Console.Write(num + " ");

            Console.WriteLine();
        }
    }
}
