using System;

namespace SloppyJoe;

public class MenuItem
{
    public string[] Proteins = [ "Roast Beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu" ];

    public string[] Condiments = [ "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" ];

    public string[] Breads = [ "rye", "white", "wheat", "pumpernickel", "a roll" ];

    public string Description = "";
    public string Price = "";
    public void Generate()
    {
        string protein = Proteins[Random.Shared.Next(Proteins.Length)];
        string condiment = Condiments[Random.Shared.Next(Condiments.Length)];
        string bread = Breads[Random.Shared.Next(Breads.Length)];
        Description = protein + "with" + condiment +  "on" + bread;
        
        int bucks = Random.Shared.Next(5,15);
        int cents = Random.Shared.Next(1,100);
        decimal price = bucks + (cents * .01M);
        Price = price.ToString();
    }
}
