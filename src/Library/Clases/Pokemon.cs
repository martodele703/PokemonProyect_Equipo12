using Poke.Clases;

namespace Poke.Clases;

public class  Pokemon
{
    public string Nombre { get; set; }
    public int CapacidadDeAtacar;
    public string? State {get; set;}
    public double Hp { get; set; }
    public Type.PokemonType Type { get; set; }
    public List<Attack> ListaDeAtaques { get; set; }
    
    // Estados causados por ataques especiales
    public int? EstadoDormido { get; set; }  // Cantidad de turnos dormido, null si no está dormido
    
    public bool Paralizado { get; set; }
    public bool Envenenado { get; set; }
    public bool Quemado { get; set; }
    
    public Pokemon(string nombre, int salud, int CapacidadDeAtacar, string estado)
    {
        this.Nombre = nombre;
        this.Hp = salud;
        this.State = estado;
        this.CapacidadDeAtacar = 1;
        this.ListaDeAtaques = new List<Attack>();
    }
    

    public string EstaVivo()
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

    public void Atacar(Pokemon pokemonOponente, Pokemon pokemonUsuario , Attack ataque)
    {
        if (CapacidadDeAtacar == 1 )
        {
            double danioAtaque = ataque.Daño;
            pokemonOponente.RecibirDanio(danioAtaque);
        }
        else
        {
            Console.WriteLine($"{Nombre} no puede atacar en este turno ya que está {this.State}");
        }
    }

    public void AddAtaque(Attack nuevoAtaque)
    {
        if (ListaDeAtaques.Count < 4)
        {
            ListaDeAtaques.Add(nuevoAtaque);
        }
        else
        {
            Console.WriteLine("No se pueden agregar más ataques, el límite es 4");
        }
    }
    public void RecibirDanio(double danio)
    {
        Hp -= danio;
        if (Hp < 0) Hp = 0;
        Console.WriteLine($"{this.Nombre} recibio {danio} puntos de daño. El HP restante:{Hp}");
    }
    
    public void AddHP(double hp)
    {
        Hp += hp;
        Console.WriteLine($"{this.Nombre} recuperó {hp} puntos de vida.");
    }

    public List<Attack> GetAtaques() // falta este método
    {
        return null;
    }

    public Type.PokemonType GetTipo()
    {
        return Type;
    }

    public double GetHp()
    {
        return Hp;
    }

    // Verificar si tiene un estado ya aplicado
    public void AplicarEstado(Pokemon objetivo,string estado)
    {
        if (objetivo.State == null)
        {
            objetivo.State = estado;
        }
        else
        {
            Console.WriteLine($"{objetivo.Nombre} ya tiene un estado");
        }
    }
    
    // Metodo para que si el jugador le aplica CuraTotal, su estado vuelva a null
    public void CurarTotalConItem(Pokemon objetivo, Items item, Player jugador)
    {
        if (item is CuraTotal && (jugador.GetItem(item) == true))
        {
            objetivo.State = null;
            jugador.usarItem(item, objetivo);
            jugador.RemoveItem(item);
        }
        else
        {
            Console.WriteLine("No se puede usar este item para quitarle el estado al Pokemon");
        }
    }

    // Métodos para actualizar estados en cada turno
    public void ActualizarEstado()
    {
        if (EstadoDormido.HasValue && EstadoDormido > 0)
        {
            EstadoDormido--;
            if (EstadoDormido == 0)
            {
                EstadoDormido = null;
            }
        }

        if (Envenenado) 
        {
            RecibirDanio(Hp * 0.05);  // Pierde 5% del HP total si está envenenado
        }
        if (Quemado)
        {
            RecibirDanio(Hp * 0.10);     // Pierde 10% del HP total si está quemado
        }

        if (Paralizado)
        {
            Random random = new Random();
            int CapacidadDeAtacar = random.Next(0,2); // 0 o 1 definen si puede atacar
        }
    }
}