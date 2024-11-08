using Poke.Clases;

namespace Poke.Clases;

public class  Pokemon
{
    public string Name { get; set; }
    public int AttackCapacity { get; set; }
    public string? State { get; set; }
    public double Hp { get; set; }
    public Type.PokemonType Type { get; set; }
    public List<Attack> AttackList { get; set; }
        
    public int? SleepState { get; set; }  // Cantidad de turnos dormido, null si no está dormido
    public bool Paralized { get; set; }
    public bool Poisoned { get; set; }
    public bool Burned { get; set; }
    
    public Pokemon(string name, int health, int AttackCapacity, string state)
    {
        this.Name = name;
        this.Hp = health;
        this.State = state;
        this.AttackCapacity = 1;
        this.AttackList = new List<Attack>();
    }
    

    public string IsAlive()
    {
        if (Hp > 0)
        {
            return "El Pokemon está vivo";
        }
        else
        {
            return "El Pokemon está muerto";
        }
    }

    public void Atack(Pokemon opponentPokemon, Pokemon playerPokemon, Attack ataque)
    {
        if (AttackCapacity == 1 )
        {
            double atackDamage = ataque.Damage;
            opponentPokemon.RecibeDamage(atackDamage);
        }
        else
        {
            Console.WriteLine($"{Name} no puede atacar en este turno ya que está {this.State}");
        }
    }

    public void AddAtack(Attack nuevoAtaque)
    {
        if (AttackList.Count < 4)
        {
            AttackList.Add(nuevoAtaque);
        }
        else
        {
            Console.WriteLine("No se pueden agregar más ataques, el límite es 4");
        }
    }
    public void RecibeDamage(double damage)
    {
        Hp -= damage;
        if (Hp < 0) Hp = 0;
        Console.WriteLine($"{this.Name} recibio {damage} puntos de daño. El HP restante:{Hp}");
    }
    
    public void AddHP(double hp)
    {
        Hp += hp;
        Console.WriteLine($"{this.Name} recuperó {hp} puntos de vida.");
    }

    public List<Attack> GetAtacks() 
    {
        return AttackList;
    }

    public Type.PokemonType GetType()
    {
        return Type;
    }

    public double GetHp()
    {
        return Hp;
    }

    // Verificar si tiene un estado ya aplicado
    public void ApplyState(Pokemon objective,string state)
    {
        if (objective.State == null)
        {
            objective.State = state;
        }
        else
        {
            Console.WriteLine($"{objective.Name} ya tiene un estado");
        }
    }
    
    // Metodo para que si el player le aplica CuraTotal, su estado vuelva a null
    public void TotalCureWithItem(Pokemon objective, Items item, Player player)
    {
        if (item is TotalCure && (player.GetItem(item) == true))
        {
            objective.State = null;
            player.useItem(item, objective);
            player.RemoveItem(item);
        }
        else
        {
            Console.WriteLine("No se puede usar este item para quitarle el estado al Pokemon");
        }
    }

    // Métodos para actualizar estados en cada turno
    public void StateActualization()
    {
        if (SleepState.HasValue && SleepState > 0)
        {
            SleepState--;
            if (SleepState == 0)
            {
                SleepState = null;
            }
        }

        if (Poisoned) 
        {
            RecibeDamage(Hp * 0.05);  // Pierde 5% del HP total si está envenenado
        }
        if (Burned)
        {
            RecibeDamage(Hp * 0.10);     // Pierde 10% del HP total si está quemado
        }

        if (Paralized)
        {
            Random random = new Random();
            int AttackCapacity = random.Next(0,2); // 0 o 1 definen si puede atacar
        }
    }
}