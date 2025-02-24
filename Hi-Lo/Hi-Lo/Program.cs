// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome To Hi-Lo!");
Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}");
HiLoGame.Hint();
while (HiLoGame.GetPot() > 0)
{
    Console.WriteLine("Press h for higher, 1 for lower, ? to buy a hint");
    Console.WriteLine($"or any other key to quit with {HiLoGame.GetPot()}.");
    char key = Console.ReadKey(true).KeyChar;
    if (key == 'h') HiLoGame.Guess(true);
    else if (key == '1') HiLoGame.Guess(false);
    else if (key == '?') HiLoGame.Hint();
    else return;
}
Console.WriteLine("The pot is empty. Bye!");

static class HiLoGame
{
    public const int MAXIMUM = 10;
    private static int currentNumber = Random.Shared.Next(1, MAXIMUM + 1);
    private static int nextNumber = Random.Shared.Next(1, MAXIMUM + 1);
    private static int pot;

    public static int GetPot() {return pot;}
    
    public static void Guess(bool higher)
    {
        if ((higher && nextNumber >= currentNumber) || !higher && nextNumber <= currentNumber)
        {
            Console.WriteLine("You guessed right!");
            pot ++;
        }
        else 
        {
         Console.WriteLine("Bad luck, you guessed wrong.");
         pot --;
        }
        currentNumber = nextNumber;
        nextNumber = Random.Shared.Next(1, MAXIMUM);
        Console.WriteLine($"The current number is {currentNumber}");
    }

    public static void Hint()
    {
        int half = MAXIMUM / 2;
        if (nextNumber >= half)
        {
            Console.WriteLine("The current number is " + currentNumber +  " The next number is at least " + half );
        }
        else Console.WriteLine("The current number is " + currentNumber + " the next number is at most " + half);
        pot --;

    }

}