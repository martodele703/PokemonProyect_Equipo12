namespace Poke.Clases;

public class CuraTotal : Items
{
    public CuraTotal()
    {
        Nombre = "Cura Total";
    }

    public override void Usar(Pokemon objetivo)
    {
        // Lógica para eliminar efectos de estado (dormido, paralizado, etc.)
    }
}