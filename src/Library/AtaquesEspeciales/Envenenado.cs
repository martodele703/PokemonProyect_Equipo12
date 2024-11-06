namespace Poke.Clases;

public class Envenenado
{
    public void Envenenar(Pokemon objetivo)
    {
        objetivo.estado = "Envenenado";
        if (objetivo.estado == "Envenenado")
        {
            objetivo.Hp *= 0.95;
        }
    }
}