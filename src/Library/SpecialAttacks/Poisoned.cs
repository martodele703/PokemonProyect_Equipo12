namespace Poke.Clases;

public class Poisoned
{
    public void Envenenar(Pokemon objective)
    {
        objective.State = "Poisoned";
        if (objective.State == "Poisoned")
        {
            objective.Hp *= 0.95;
        }
    }
}