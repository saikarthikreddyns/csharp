// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
public static int FloydCycle(int[] arr)
{
    int slow = arr[0];
    int fast = arr[0];

    do
    {
        slow = arr[slow];
        fast = arr[arr[fast]];
    } while (slow != fast);
    
    slow = arr[0];
    while(slow!=fast){
        slow=arr[slow];
        fast=arr[fast];
    }
    return slow;
}

    public static void Main(string[] args)
    {
       int[][] testCases =
{
    new int[]{1,3,4,2,2},
    new int[]{3,1,3,4,2},
    new int[]{1,1,2,3,4},
    new int[]{1,2,3,4,4},
    new int[]{1,1},
    new int[]{5,4,3,2,1,3},
    new int[]{2,5,9,6,9,3,8,9,7,1}
};

foreach (var test in testCases)
{
    Console.WriteLine(FloydCycle(test));
}

    }
}

