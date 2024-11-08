namespace Poke.Clases
{
    public static class Type
    {
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

        public enum TypeAdvantage
        {
            Advantage = 1,
            Neutral = 0,
            Disadvantage = -1
        }

        private static readonly Dictionary<(PokemonType, PokemonType), TypeAdvantage> typeAdvantages = new()
        {
            {(PokemonType.Water, PokemonType.Fire), TypeAdvantage.Advantage},
            {(PokemonType.Water, PokemonType.Rock), TypeAdvantage.Advantage},
            {(PokemonType.Water, PokemonType.Earth), TypeAdvantage.Advantage},
            {(PokemonType.Bug, PokemonType.Plant), TypeAdvantage.Advantage},
            {(PokemonType.Bug, PokemonType.Psychic), TypeAdvantage.Advantage},
            {(PokemonType.Dragon, PokemonType.Dragon), TypeAdvantage.Advantage},
            {(PokemonType.Electric, PokemonType.Water), TypeAdvantage.Advantage},
            {(PokemonType.Electric, PokemonType.Flying), TypeAdvantage.Advantage},
            {(PokemonType.Ghost, PokemonType.Ghost), TypeAdvantage.Advantage},
            {(PokemonType.Ghost, PokemonType.Psychic), TypeAdvantage.Advantage},
            {(PokemonType.Fire, PokemonType.Plant), TypeAdvantage.Advantage},
            {(PokemonType.Fire, PokemonType.Bug), TypeAdvantage.Advantage},
            {(PokemonType.Fire, PokemonType.Ice), TypeAdvantage.Advantage},
            {(PokemonType.Ice, PokemonType.Plant), TypeAdvantage.Advantage},
            {(PokemonType.Ice, PokemonType.Earth), TypeAdvantage.Advantage},
            {(PokemonType.Ice, PokemonType.Flying), TypeAdvantage.Advantage},
            {(PokemonType.Ice, PokemonType.Dragon), TypeAdvantage.Advantage},
            {(PokemonType.Fighter, PokemonType.Normal), TypeAdvantage.Advantage},
            {(PokemonType.Fighter, PokemonType.Rock), TypeAdvantage.Advantage},
            {(PokemonType.Fighter, PokemonType.Ice), TypeAdvantage.Advantage},
            {(PokemonType.Plant, PokemonType.Water), TypeAdvantage.Advantage},
            {(PokemonType.Plant, PokemonType.Earth), TypeAdvantage.Advantage},
            {(PokemonType.Plant, PokemonType.Rock), TypeAdvantage.Advantage},
            {(PokemonType.Psychic, PokemonType.Fighter), TypeAdvantage.Advantage},
            {(PokemonType.Rock, PokemonType.Fire), TypeAdvantage.Advantage},
            {(PokemonType.Rock, PokemonType.Flying), TypeAdvantage.Advantage},
            {(PokemonType.Rock, PokemonType.Ice), TypeAdvantage.Advantage},
            {(PokemonType.Rock, PokemonType.Bug), TypeAdvantage.Advantage},
            {(PokemonType.Earth, PokemonType.Fire), TypeAdvantage.Advantage},
            {(PokemonType.Earth, PokemonType.Electric), TypeAdvantage.Advantage},
            {(PokemonType.Earth, PokemonType.Poison), TypeAdvantage.Advantage},
            {(PokemonType.Earth, PokemonType.Rock), TypeAdvantage.Advantage},
            {(PokemonType.Poison, PokemonType.Plant), TypeAdvantage.Advantage},
            {(PokemonType.Flying, PokemonType.Plant), TypeAdvantage.Advantage},
            {(PokemonType.Flying, PokemonType.Fighter), TypeAdvantage.Advantage},
            {(PokemonType.Flying, PokemonType.Bug), TypeAdvantage.Advantage}
        };

        public static TypeAdvantage GetTypeAdvantage(PokemonType type1, PokemonType type2)
        {
            if (type1 == type2)
                return TypeAdvantage.Neutral;

            return typeAdvantages.TryGetValue((type1, type2), out var advantage) ? advantage : TypeAdvantage.Disadvantage;
        }
    }
}
