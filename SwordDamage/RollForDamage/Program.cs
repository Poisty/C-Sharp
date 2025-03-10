// See https://aka.ms/new-console-template for more information
using RollForDamage;

SwordDamage swordDamage = new SwordDamage();

Console.WriteLine("0 for no magic/flaming");
Console.WriteLine("1 for magic");
Console.WriteLine("2 for flaming");
Console.WriteLine("3 for both magic/flaming");
Console.WriteLine("Anything else to quit");

char key = Console.ReadKey().KeyChar;

if (key != '0' && key != '1' && key != '2' && key != '3') return;




int roll = Random.Shared.Next(1,7) + Random.Shared.Next(1,7) + Random.Shared.Next(1,7); 
swordDamage.Roll = roll;
swordDamage.SetMagic(key == '1' || key == '3');
swordDamage.SetFlaming(key == '2' || key == '3');
Console.WriteLine("\nRolled " + roll + " for " + swordDamage.Damage + " HP\n");
