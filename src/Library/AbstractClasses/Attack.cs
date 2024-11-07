namespace Poke.Clases
{
    public class Attack
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public Type.PokemonType AttackType { get; set; }
        
        public bool IsSpecial { get; set; }

        // Constructor para inicializar un ataque
        public Attack(string name, double damage, Type.PokemonType attackType, bool isSpecial)
        {
            Name = name;
            Damage = damage;
            AttackType = attackType;
            IsSpecial = isSpecial;
        }
        // Método que calcula el daño basado en la efectividad de tipos
        public double CalculateDamage(Pokemon target)
        {
            // Consultar la ventaja de tipo entre el atacante y el objetivo
            var typeAdvantage = Type.GetTypeAdvantage(this.AttackType, target.Type);

            // Modificar el daño según la ventaja de tipo
            double effectiveness = 1.0;
            switch (typeAdvantage)
            {
                case Type.TypeAdvantage.Advantage:
                    effectiveness = 2.0;  // El tipo de ataque es fuerte contra el tipo objetivo
                    break;
                case Type.TypeAdvantage.Neutral:
                    effectiveness = 1.0;  // No hay ventaja ni desventaja
                    break;
                case Type.TypeAdvantage.Disadvantage:
                    effectiveness = 0.5;  // El tipo de ataque es débil contra el tipo objetivo
                    break;
            }

            // Calcular el daño final aplicando la efectividad
            return Damage * effectiveness;
        }
    }
}