﻿namespace DamageCalculator;

public partial class MainPage : ContentPage
{
		SwordDamage swordDamage = new SwordDamage();


	public MainPage()
	{
		InitializeComponent();
		swordDamage.SetFlaming(Flaming.IsChecked);
		swordDamage.SetMagic(Magic.IsChecked);
		RollDice();
	}

	private void RollDice()
	{
		swordDamage.Roll = 0;
		swordDamage.Roll += Random.Shared.Next(1,7);
		swordDamage.Roll += Random.Shared.Next(1,7);
		swordDamage.Roll += Random.Shared.Next(1,7);
		swordDamage.SetFlaming(Flaming.IsChecked);
		swordDamage.SetMagic(Magic.IsChecked);
		DisplayDamage(); 
	}

	private void DisplayDamage()
	{
		Damage.Text = $"Rolled {swordDamage.Roll} for {swordDamage.Damage} HP";
	}

	private void Flaming_CheckedChanged(object sender, CheckedChangedEventArgs e )
	{
		swordDamage.SetFlaming(e.Value);
		DisplayDamage();
	}

		private void Magic_CheckedChanged(object sender, CheckedChangedEventArgs e )
	{
		swordDamage.SetMagic(e.Value);
		DisplayDamage();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		RollDice();
    }

}

