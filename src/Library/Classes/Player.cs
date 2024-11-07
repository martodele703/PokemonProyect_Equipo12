namespace Poke.Clases;

public class Trainer
{
    // Atributos privados
    public List<Pokemon> Pokemons;
    public Pokemon ActualPokemon;
    public List<Items> Items;
    private string name { get; set; }

    // Constructor
    public Trainer(string name, Pokemon ActualPokemon)
    {
        Pokemons = new List<Pokemon>();
        this.ActualPokemon = ActualPokemon;
        this.name = name;
        
        Items = new List<Items>();
        // Agrego los items
        
        Items.Add(new SuperPotion());
        Items.Add(new SuperPotion());
        Items.Add(new SuperPotion());
        Items.Add(new SuperPotion());
        
        Items.Add(new TotalCure());
        Items.Add(new TotalCure());
        
        Items.Add(new RevivePotion());
        
    }
    
    public double PokemonLife()
    {
        double suma = 0;
        foreach (var pokemon in Pokemons)
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
        foreach (var pokemon in Pokemons)
        {
            Console.WriteLine(pokemon.Name);
            Console.WriteLine(pokemon.Hp);
        }
    }
    
    // Método para obtener el Pokémon actual
    public Pokemon getActualPokemon()
    {
        return ActualPokemon;
    }

    public void RemoveItem(Items item)
    {
        Items.Remove(item);
    }
    
    // Método para usar un item
    public void useItem(Items item, Pokemon objective)
    {
        item.Use(objective);
    }
}    