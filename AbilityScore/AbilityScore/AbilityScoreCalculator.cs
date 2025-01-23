using System;

namespace AbilityScore;

public class AbilityScoreCalculator
{
    public int RollResult = 14;
    public double DevideBy = 1.75;
    public int AddAmount = 2;
    public int Minimum = 3;
    public int Score;

    public void CalculateAbilityScore()
    {
        double devided = RollResult / DevideBy;

        int added = AddAmount += (int)devided;

        if (added < Minimum)
        {
            Score = Minimum;
        } else
        {
            Score = added;
        }
    }
}
