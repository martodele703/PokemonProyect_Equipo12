namespace Poke.Clases;

public class SuperPocion : Items
{
    public SuperPocion()
    {
        Nombre = "Súper Pocion";
    }

    public override void Usar(Pokemon objetivo)
    {
        objetivo.AddHP(70);  // Recupera 70 puntos de HP
    }
}
