using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage ");
        int grade= int.Parse(Console.ReadLine());
        string letter ="";
        string sign="";
        if(grade >=90){
            letter="A";
            if (grade % 10 >=7){
                sign="";
            }else{
                sign="-";
            }
        }
        else if(grade >=80){
            letter= "B";
             if (grade % 10 >=7){
                sign="+";
            }else if (grade % 10 <3){
                sign="-";
            }else{
                 sign="";
            }
        }
        else if (grade >= 70)
        {
            letter="C";
            if (grade % 10 >=7){
                sign="+";
            }else if (grade % 10 <3){
                sign="-";
            }else{
                 sign="";
            }
        }
        else if(grade >= 60)
        {
            letter= "D";
            if (grade % 10 >=7){
                sign="+";
            }else if (grade % 10 <3){
                sign="-";
            }else{
                 sign="";
            }
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is {sign}{letter}");
        if( grade >= 70){
            Console.WriteLine("Congratulations, You pass the class");
        }else{
             Console.WriteLine("Take courage, you will do best next times");
        }
    }
}