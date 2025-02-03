// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using Kapittel4Elefant;

Elephant lucinda = new Elephant() { name = "Lucinda", earsize = 33 };
Elephant lloyd = new Elephant() { name = "Lloyd", earsize = 40 };

Console.WriteLine("Enter 1 for Lloyd, 2 for Lucinda, 3 to swap references, or 'exit' to quit: ");

while (true)
{
    string? input = Console.ReadLine();
    Console.WriteLine("You entered " + input);
    if (input == "1")
    {
        lloyd.WhoAmI();
    }
    else if (input == "2")
    {
        lucinda.WhoAmI();
    }
    else if (input == "3")
    {
        Elephant holder;
        holder = lloyd;
        lloyd = lucinda;
        lucinda = holder;
        Console.WriteLine("References swapped");
    }
    else if (input == "4")
    {
        Console.WriteLine("Are you sure you want to set Lloyd's ear size to 4321? (yes/no)");
        string? confirmation = Console.ReadLine();
        if (confirmation?.ToLower() == "yes")
        {
            lloyd = lucinda;
            lloyd.earsize = 4321;
            lloyd.WhoAmI();
        }
        else
        {
            Console.WriteLine("Operation cancelled.");
        }
    }
    else if (input?.ToLower() == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input. Enter 1, 2, 3, or 'exit': ");
    }
    Console.WriteLine();
}
