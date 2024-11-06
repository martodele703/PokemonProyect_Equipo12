namespace Poke.Clases;

public abstract class Attack
{
    
    public string Name { get; set; }
    public Type.PokemonType Type { get; set; }
    public double Damage { get; set; }
    public bool IsSpecial { get; set; }
    
    public double? CalculateDamage(Pokemon atacante, Pokemon defensor)
    {
        return null;
    }
}

