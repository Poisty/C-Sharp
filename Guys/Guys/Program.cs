using Guys;

Guy Joe = new Guy() { Cash = 50, Name = "Joe" };
Guy Bob = new Guy() { Cash = 100, Name = "Bob" };

while(true)
{
    Joe.WriteMyInfo();
    Bob.WriteMyInfo();

    Console.Write("Enter an amount: ");
    string? howMuch = Console.ReadLine();
    if (howMuch == " ") return;

    if(int.TryParse (howMuch, out int amount))
    {
        Console.Write("Who should give the cash: ");
        string? whichGuy = Console.ReadLine();
        if (whichGuy == "Joe")
        {
            int cashGiven = Joe.GiveCash(amount);
            Bob.RecieveCash(cashGiven);
        }
        else if (whichGuy == "Bob")
        {
            int cashGiven= Bob.GiveCash(amount);
            Joe.RecieveCash(cashGiven);
         
        }
        else{
            Console.WriteLine("Please enter 'Joe' or 'Bob' ");
        }
    }
    else{
        Console.WriteLine("Please enter an amount (or a blank line to exit)");
    }

}

