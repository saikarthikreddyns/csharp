using System;

public class MergeArray
{
    public static int[] MergeArr(int[] arr1,int[] arr2)
    {
        int length = arr1.Length + arr2.Length;
        int[] result = new int[length];
        int index = 0;
        
        foreach(int ele in arr1){
            result[index++]=ele;
        }
        foreach(int ele in arr2){
            result[index++]=ele;
        }
        return result;
    }

static void Print(int[] arr)
{
    foreach (var x in arr)
        Console.Write(x + " ");
    Console.WriteLine();
}

public static void Main()
{
    Print(MergeArr(new int[]{1,2,3}, new int[]{4,5,6}));
    Print(MergeArr(new int[]{10,20}, new int[]{30,40,50,60}));
    Print(MergeArr(new int[]{}, new int[]{1,2,3}));
    Print(MergeArr(new int[]{}, new int[]{}));
    Print(MergeArr(new int[]{-3,-1}, new int[]{2,4}));
    Print(MergeArr(new int[]{1,2,2}, new int[]{2,3}));
}

}
