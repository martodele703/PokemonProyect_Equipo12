namespace Poke.Clases;

public class NormalAttack : Attack
{
    // Constructor para inicializar un ataque
    public NormalAttack(string name, double damage, Type.PokemonType attackType, bool isSpecial) : base(name, damage, attackType, isSpecial)
    {
       
    }  
}