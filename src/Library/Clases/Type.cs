namespace Poke.Clases;

public static class Type
{
    public static PokemonType type;
    public enum PokemonType
    {

        Water,
        Bug,
        Dragon,
        Electric,
        Ghost,
        Fire,
        Ice,
        Fighter,
        Normal,
        Plant,
        Psychic,
        Rock,
        Earth,
        Poison,
        Flying
    }
    
    public static int PokemonAdvantage(PokemonType type1, PokemonType type2)
    {
        if (type1 == PokemonType.Water && (type2 == PokemonType.Fire || type2 == PokemonType.Rock || type2 == PokemonType.Earth))
            return 1;
        if (type1 == PokemonType.Bug && (type2 == PokemonType.Plant || type2 == PokemonType.Psychic))
            return 1;
        if (type1 == PokemonType.Dragon && type2 == PokemonType.Dragon)
            return 1;
        if (type1 == PokemonType.Electric && (type2 == PokemonType.Water || type2 == PokemonType.Flying))
            return 1;
        if (type1 == PokemonType.Ghost && (type2 == PokemonType.Ghost || type2 == PokemonType.Psychic))
            return 1;
        if (type1 == PokemonType.Fire && (type2 == PokemonType.Plant || type2 == PokemonType.Bug || type2 == PokemonType.Ice))
            return 1;
        if (type1 == PokemonType.Ice && (type2 == PokemonType.Plant || type2 == PokemonType.Earth || type2 == PokemonType.Flying || type2 == PokemonType.Dragon))
            return 1;
        if (type1 == PokemonType.Fighter && (type2 == PokemonType.Normal || type2 == PokemonType.Rock || type2 == PokemonType.Ice))
            return 1;
        if (type1 == PokemonType.Plant && (type2 == PokemonType.Water || type2 == PokemonType.Earth || type2 == PokemonType.Rock))
            return 1;
        if (type1 == PokemonType.Psychic && type2 == PokemonType.Fighter)
            return 1;
        if (type1 == PokemonType.Rock && (type2 == PokemonType.Fire || type2 == PokemonType.Flying || type2 == PokemonType.Ice || type2 == PokemonType.Bug))
            return 1;
        if (type1 == PokemonType.Earth && (type2 == PokemonType.Fire || type2 == PokemonType.Electric || type2 == PokemonType.Poison || type2 == PokemonType.Rock))
            return 1;
        if (type1 == PokemonType.Poison && type2 == PokemonType.Plant)
            return 1;
        if (type1 == PokemonType.Flying && (type2 == PokemonType.Plant || type2 == PokemonType.Fighter || type2 == PokemonType.Bug))
            return 1;
        
        // Empate
        if (type1 == type2)
            return 0; 
        
        // Desventaja en los demas casos
        return -1; 

    }
}