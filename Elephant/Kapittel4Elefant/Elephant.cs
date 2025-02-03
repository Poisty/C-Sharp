using System;
using System.Globalization;

namespace Kapittel4Elefant;

public class Elephant
{

    public string? name;
    public int earsize;


    public void WhoAmI()
    {

        Console.WriteLine("My name is " + name);
        Console.WriteLine("My ears are " + earsize + " inches tall");

    }

    public void HearMessage(string message, Elephant whoSaidIt)
    {
        Console.WriteLine(name + " heard a message");
        Console.WriteLine(whoSaidIt.name + " said this: " + message);
    }

}
