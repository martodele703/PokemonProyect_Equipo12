namespace Poke.Clases;

public abstract class Items
{
    public string Nombre { get; set; }
    public abstract void Usar(Pokemon objetivo);
}