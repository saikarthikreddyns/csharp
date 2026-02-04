// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class RotateArray
{
    public static void RotateArr(int[] arr){
        int length = arr.Length-1;
        for (int i = 0 ; i < length ; i++){
            int temp = arr[i];
            arr[i] = arr[length];
            arr[length]=temp;
            length--;
        }
        Console.WriteLine("------------------------------------");
        foreach (int ele in arr){
             Console.Write(ele + " ");
        }
    }
public static void Main(string[] args)
{
    int[][] testCases = {
        new int[]{1,2,3,4,5},
        new int[]{10,20,30,40},
        new int[]{5},
        new int[]{},
        new int[]{1,1,1,1},
        new int[]{9,8,7,6,5,4},
        new int[]{100,200}
    };

    foreach (var test in testCases)
    {
        RotateArr(test);
        Console.WriteLine();
    }
}
}