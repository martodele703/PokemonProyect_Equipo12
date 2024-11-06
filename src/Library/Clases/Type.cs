namespace Poke.Clases;

public static class Type
{
    public static PokemonType type;
    public enum PokemonType
    {
        Water,
        Fire,
        Electric,
        Plant
    }
    
    public static int VentajaPokemon(PokemonType type1, PokemonType type2)
    {
        if (type1 == PokemonType.Water && type2 == PokemonType.Fire)
            return 1; 
        
        if (type1 == PokemonType.Fire && type2 == PokemonType.Plant)
            return 1; 
        
        if (type1 == PokemonType.Electric && type2 == PokemonType.Water)
            return 1; 
        
        if (type1 == PokemonType.Plant && type2 == PokemonType.Electric)
            return 1;

        if (type1 == type2)
            return 0; //empate

        return -1; //desventaja en los demas
    }
}