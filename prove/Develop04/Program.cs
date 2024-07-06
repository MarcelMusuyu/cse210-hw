using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;
       
        do{
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"\t1. Start breathing activity");
            Console.WriteLine($"\t2. Start reflecting activity");
            Console.WriteLine($"\t3. Start listing activity");
            Console.WriteLine($"\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice=int.Parse(Console.ReadLine());
        
             switch (choice)
                {
                  
                    case 1:
                        
                        BreathingActivity breathing=new BreathingActivity();
                        breathing.Run();
                       
                        break;
                    case 2:
                        ReflectingActivity reflecting = new ReflectingActivity();
                        reflecting.Run();
                       
                        break;
                    case 3:
                        ListingActivity listing =new ListingActivity();
                        listing.Run();
                        
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
        
        } while(choice < 4);
    }


}