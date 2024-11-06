namespace Poke.Clases;

public class Paralizado
{
    public void Paralizar(Pokemon objetivo)
    {
        objetivo.estado = "Paralizado";
        if (objetivo.estado == "Paralizado")
        {
            Random random = new Random();
            int capacidadDeAtacar = random.Next(0,2); // 0 o 1 definen si puede atacar
        }
    }
}