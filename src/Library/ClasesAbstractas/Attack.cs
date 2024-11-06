namespace Poke.Clases;

public abstract class Attack
{
    private string nombre;

    private int daño;

    private string Type;

    private bool esEspecial;
    
    public string Nombre { get; set; }
    public Type.PokemonType Tipo { get; set; }
    public double Daño { get; set; }
    public bool EsEspecial { get; set; }
    
    public double? CalcularDanio(Pokemon atacante, Pokemon defensor)
    {
        return null;
    }
}

