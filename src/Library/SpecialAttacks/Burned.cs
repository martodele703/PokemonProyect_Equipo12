namespace Poke.Clases;

public class Burned
{
    public void Burn(Pokemon objective)
    {
        objective.State = "Burned";
        if (objective.State == "Burned")
        {
            objective.Hp *= 0.9;
        }
    }
}