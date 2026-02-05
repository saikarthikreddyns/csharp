// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class FindDuplicates
{
    public static void FindDuplicate(string s){
        int[] freq = new int[256];
        for (int i=0;i<s.Length;i++){
            freq[s[i]]++;
        }
        Console.WriteLine("Duplicate Characters ");
        for(int i=0;i<256;i++){
            if(freq[i]>1){
                Console.WriteLine((char)i + "->" + freq[i] + "Times");
            }
        }
        
    }
    public static void Main(string[] args)
    {
        FindDuplicate("programming");
        FindDuplicate("hello world");
    }
}