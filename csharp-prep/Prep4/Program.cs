using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.!");
        Console.Write("Enter number: ");
        int number= int.Parse(Console.ReadLine());
        List<int> numbers= new List<int>();
        while(number !=0){
            numbers.Add(number);
            Console.Write("Enter number: ");
            number= int.Parse(Console.ReadLine());
        }
        float average;
        float sum=0;
        foreach (int item in numbers)
        {
            sum +=item;
        }
        average=sum/numbers.Count;
        int max=-1;
        foreach (int item in numbers)
        {
            if(max <= item){
                max=item;
            }
        }
        int smallestPositive=9999;
        foreach (int item in numbers)
        {
            if (item > 0 && item <= smallestPositive ){
                smallestPositive=item;
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}