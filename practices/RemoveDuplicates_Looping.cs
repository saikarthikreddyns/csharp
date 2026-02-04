using System;

class HelloWorld
{
    static int[] RemoveDuplicates(int[] arr)
    {
        if (arr.Length == 0) return arr;

        Array.Sort(arr);   // REQUIRED for this algorithm

        int j = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[j])
            {
                j++;
                arr[j] = arr[i];
            }
        }

        int[] result = new int[j + 1];
        Array.Copy(arr, result, j + 1);
        return result;
    }

    static void Print(int[] arr)
    {
        Console.Write("[ ");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine("]");
    }

    static void Main()
    {
        int[] t1 = {1,2,3,3,2,1};
        Print(RemoveDuplicates(t1));

        int[] t2 = {5,5,5,5,5};
        Print(RemoveDuplicates(t2));

        int[] t3 = {1,2,3,4,5};
        Print(RemoveDuplicates(t3));

        int[] t4 = {};
        Print(RemoveDuplicates(t4));

        int[] t5 = {10,20,10,30,20,40};
        Print(RemoveDuplicates(t5));
    }
}
