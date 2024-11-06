namespace Poke.Clases;

public class Quemado
{
    public void Quemar(Pokemon objetivo)
    {
        objetivo.estado = "Quemado";
        if (objetivo.estado == "Quemado")
        {
            objetivo.Hp *= 0.9;
        }
    }
}