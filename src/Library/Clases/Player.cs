namespace Poke.Clases;

public class Player
{
    // Atributos privados
    public List<Pokemon> Pokemones;
    public Pokemon PokemonActual;
    public List<Items> Items;
    private string nombre { get; set; }

    // Constructor
    public Player(string nombre, Pokemon PokemonActual)
    {
        Pokemones = new List<Pokemon>();
        this.PokemonActual = PokemonActual;
        this.nombre = nombre;
        
        Items = new List<Items>();
        // Agrego los items
        
        Items.Add(new SuperPocion());
        Items.Add(new SuperPocion());
        Items.Add(new SuperPocion());
        Items.Add(new SuperPocion());
        
        Items.Add(new CuraTotal());
        Items.Add(new CuraTotal());
        
        Items.Add(new RevivirPocion());
        
    }
    
    public double VidaPokemon()
    {
        double suma = 0;
        foreach (var pokemon in Pokemones)
        {
            suma += pokemon.Hp;
        }

        return suma;
    }
    public bool GetItem(Items items)
    {
        if (Items.Contains(items))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Metodo para obtener la info de todos los pokemones
    public void GetPokemonsInfo()
    {
        foreach (var pokemon in Pokemones)
        {
            Console.WriteLine(pokemon.Nombre);
            Console.WriteLine(pokemon.Hp);
        }
    }
    
    // Método para obtener el Pokémon actual
    public Pokemon getPokemonActual()
    {
        return PokemonActual;
    }

    public void RemoveItem(Items item)
    {
        Items.Remove(item);
    }
    
    // Método para usar un item
    public void usarItem(Items item, Pokemon objetivo)
    {
        item.Usar(objetivo);
    }
}    