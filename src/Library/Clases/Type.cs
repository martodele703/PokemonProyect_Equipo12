namespace Poke.Clases;

public static class Type
{
    public static PokemonType type;
    public enum PokemonType
    {
        Agua, Bicho, Dragon, Electrico, Fantasma, Fuego, Hielo, Lucha, Normal, Planta, Psiquico, Roca, Tierra, Veneno, Volador
    }
    
    public static int VentajaPokemon(PokemonType tipo1, PokemonType tipo2)
    {
        if (tipo1 == PokemonType.Agua && (tipo2 == PokemonType.Fuego || tipo2 == PokemonType.Roca || tipo2 == PokemonType.Tierra))
            return 1;
        if (tipo1 == PokemonType.Bicho && (tipo2 == PokemonType.Planta || tipo2 == PokemonType.Psiquico))
            return 1;
        if (tipo1 == PokemonType.Dragon && tipo2 == PokemonType.Dragon)
            return 1;
        if (tipo1 == PokemonType.Electrico && (tipo2 == PokemonType.Agua || tipo2 == PokemonType.Volador))
            return 1;
        if (tipo1 == PokemonType.Fantasma && (tipo2 == PokemonType.Fantasma || tipo2 == PokemonType.Psiquico))
            return 1;
        if (tipo1 == PokemonType.Fuego && (tipo2 == PokemonType.Planta || tipo2 == PokemonType.Bicho || tipo2 == PokemonType.Hielo))
            return 1;
        if (tipo1 == PokemonType.Hielo && (tipo2 == PokemonType.Planta || tipo2 == PokemonType.Tierra || tipo2 == PokemonType.Volador || tipo2 == PokemonType.Dragon))
            return 1;
        if (tipo1 == PokemonType.Lucha && (tipo2 == PokemonType.Normal || tipo2 == PokemonType.Roca || tipo2 == PokemonType.Hielo))
            return 1;
        if (tipo1 == PokemonType.Planta && (tipo2 == PokemonType.Agua || tipo2 == PokemonType.Tierra || tipo2 == PokemonType.Roca))
            return 1;
        if (tipo1 == PokemonType.Psiquico && tipo2 == PokemonType.Lucha)
            return 1;
        if (tipo1 == PokemonType.Roca && (tipo2 == PokemonType.Fuego || tipo2 == PokemonType.Volador || tipo2 == PokemonType.Hielo || tipo2 == PokemonType.Bicho))
            return 1;
        if (tipo1 == PokemonType.Tierra && (tipo2 == PokemonType.Fuego || tipo2 == PokemonType.Electrico || tipo2 == PokemonType.Veneno || tipo2 == PokemonType.Roca))
            return 1;
        if (tipo1 == PokemonType.Veneno && tipo2 == PokemonType.Planta)
            return 1;
        if (tipo1 == PokemonType.Volador && (tipo2 == PokemonType.Planta || tipo2 == PokemonType.Lucha || tipo2 == PokemonType.Bicho))
            return 1;
        
        // Empate
        if (tipo1 == tipo2)
            return 0; 
        
        // Desventaja en los demas casos
        return -1; 
    }
}