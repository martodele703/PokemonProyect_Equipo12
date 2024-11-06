namespace Poke.Clases;

public class SpecialAttack : Attack
{
    public SpecialAttack(string name, int damage, Type.PokemonType type)
    {
        this.Name = name;
        this.Damage = damage;
        this.Type = type;
        this.IsSpecial = true;
    }
}