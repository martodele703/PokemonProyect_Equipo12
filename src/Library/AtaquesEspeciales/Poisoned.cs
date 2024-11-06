namespace Poke.Clases;

public class Poisoned
{
    public void Envenenar(Pokemon objetivo)
    {
        objetivo.State = "Poisoned";
        if (objetivo.State == "Poisoned")
        {
            objetivo.Hp *= 0.95;
        }
    }
}