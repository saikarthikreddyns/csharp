using System;
using System.Collections.Generic;

class HelloWorld
{
    static int[] RemoveDuplicates(int[] arr)
    {
        HashSet<int> unique = new HashSet<int>(arr);
        int[] result = new int[unique.Count];
        unique.CopyTo(result);
        return result;
    }

    static void Main()
    {
        int[] array = {1,2,3,5,3,3,2,4,5,25,5,24,12,31,34,1,4,14,124,124,5,432,1};

        int[] noDuplicates = RemoveDuplicates(array);

        Console.WriteLine("Array after removing duplicates:");
        foreach (int num in noDuplicates)
        {
            Console.Write(num + " ");
        }
    }
}
