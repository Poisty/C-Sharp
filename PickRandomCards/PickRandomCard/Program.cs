﻿namespace PickRandomCards;

internal class Program
{
    static void Main(String[] args){
        Console.Write("Enter the numbers of cards to pick: ");
        string? line = Console.ReadLine();

        if (int.TryParse(line, out int numberOfCards))
        {
            string[] cards = CardPicker.PickSomeCards(numberOfCards);
            foreach (string card in cards)
            {
                Console.WriteLine(card);
            }
        }
        else
        {
            Console.Write("Please enter a valid number.");
        }
    }
}