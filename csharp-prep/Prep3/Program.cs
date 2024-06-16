using System;

class Program
{
    static void Main(string[] args)
    {
       
        Random randomGenerator= new Random();
        int magic_number= randomGenerator.Next(1,100);
        int guesses=0;
            
        Console.Write("Enter your guess... ");
        int guessing= int.Parse(Console.ReadLine());
        while (magic_number != guessing)
        {
            if(magic_number < guessing){
                 Console.WriteLine("greater");
            }else{
                Console.WriteLine("lower");
            }
            guesses ++;
           
            Console.Write("Enter your guess... ");
            guessing= int.Parse(Console.ReadLine());
        }
         Console.WriteLine($"Congratulation the number is {guessing} and your guesses is {guesses}");
         string response; 
        
         Console.Write("Do you want to continue? ");
         response= Console.ReadLine();
         while(response=="yes"){
            magic_number= randomGenerator.Next(1,100);
            guesses=0;
            Console.Write("Enter your guess... ");
            guessing= int.Parse(Console.ReadLine());
            while (magic_number != guessing)
                {
                    if(magic_number < guessing){
                        Console.WriteLine("greater");
                    }else{
                        Console.WriteLine("lower");
                    }
                    guesses ++;
                   
                    Console.Write("Enter your guess... ");
                    guessing= int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Congratulation the number is {guessing} and your guesses is {guesses}");
                Console.WriteLine("Do you want to continue? ");
                response= Console.ReadLine();
         }
        
    }
}