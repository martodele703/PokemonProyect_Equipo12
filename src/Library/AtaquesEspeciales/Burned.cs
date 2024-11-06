namespace Poke.Clases;

public class Burned
{
    public void Quemar(Pokemon objetivo)
    {
        objetivo.State = "Burned";
        if (objetivo.State == "Burned")
        {
            objetivo.Hp *= 0.9;
        }
    }
}