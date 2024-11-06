namespace Poke.Clases;

public class RevivirPocion : Items
{
    public RevivirPocion()
    {
        Nombre = "Revivir";
    }

    public override void Usar(Pokemon objetivo)
    {
        if (objetivo.GetHp() == 0)
        {
            objetivo.AddHP(objetivo.Hp / 2);  // Revive con el 50% del HP total
        }
    }
}