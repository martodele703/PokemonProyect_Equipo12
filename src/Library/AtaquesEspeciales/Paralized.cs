namespace Poke.Clases;

public class Paralized
{
    public void Paralizar(Pokemon objetivo)
    {
        objetivo.State = "Paralized";
        if (objetivo.State == "Paralized")
        {
            Random random = new Random();
            int capacidadDeAtacar = random.Next(0,2); // 0 o 1 definen si puede atacar
        }
    }
}