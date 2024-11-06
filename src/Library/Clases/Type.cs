namespace Poke.Clases;

public class Type
{
    public enum PokemonType
    {
        Agua,
        Fuego,
        Electrico,
        Roca
    }
    
    public static int VentajaPokemon(PokemonType tipo1, PokemonType tipo2)
    {
        if (tipo1 == PokemonType.Agua && tipo2 == PokemonType.Fuego)
            return 1; 
        
        if (tipo1 == PokemonType.Fuego && tipo2 == PokemonType.Roca)
            return 1; 
        
        if (tipo1 == PokemonType.Electrico && tipo2 == PokemonType.Agua)
            return 1; 
        
        if (tipo1 == PokemonType.Roca && tipo2 == PokemonType.Electrico)
            return 1;

        if (tipo1 == tipo2)
            return 0; //empate

        return -1; //desventaja en los demas
    }
}