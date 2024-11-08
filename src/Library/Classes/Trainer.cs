namespace Poke.Clases;

/// <summary>
/// Representa a un entrenador en el juego, quien tiene una lista de pokemones y una lista de items.
/// </summary>
public class Trainer
{
    /// <summary>
    /// Lista de pokemones que posee el entrenador.
    /// </summary>
    public List<Pokemon> Pokemons;

    /// <summary>
    /// El pokemon actualmente activo del entrenador.
    /// </summary>
    public Pokemon ActualPokemon;

    /// <summary>
    /// Lista de items que el entrenador tiene disponibles.
    /// </summary>
    public List<Items> Items;

    /// <summary>
    /// Nombre del entrenador.
    /// </summary>
    private string name { get; set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Trainer"/>.
    /// </summary>
    /// <param name="name">Nombre del entrenador.</param>
    /// <param name="ActualPokemon">El pokemon actual del entrenador.</param>
    public Trainer(string name, Pokemon ActualPokemon)
    {
        Pokemons = new List<Pokemon>();
        this.ActualPokemon = ActualPokemon;
        this.name = name;
        
        Items = new List<Items>();

        // Agrega items iniciales al entrenador
        Items.Add(new SuperPotion());
        Items.Add(new SuperPotion());
        Items.Add(new SuperPotion());
        Items.Add(new SuperPotion());
        Items.Add(new TotalCure());
        Items.Add(new TotalCure());
        Items.Add(new RevivePotion());
    }
    
    /// <summary>
    /// Calcula la vida total de todos los pokemones del entrenador.
    /// </summary>
    /// <returns>La suma de los puntos de vida de todos los pokemones.</returns>
    public double PokemonLife()
    {
        double suma = 0;
        foreach (var pokemon in Pokemons)
        {
            suma += pokemon.Hp;
        }

        return suma;
    }

    /// <summary>
    /// Verifica si el entrenador tiene un item específico.
    /// </summary>
    /// <param name="items">El item a buscar.</param>
    /// <returns>Verdadero si el entrenador tiene el item; de lo contrario, falso.</returns>
    public bool GetItem(Items items)
    {
        return Items.Contains(items);
    }

    /// <summary>
    /// Muestra la información de todos los pokemones que posee el entrenador.
    /// </summary>
    public void GetPokemonsInfo()
    {
        foreach (var pokemon in Pokemons)
        {
            Console.WriteLine(pokemon.Name);
            Console.WriteLine(pokemon.Hp);
        }
    }

    /// <summary>
    /// Obtiene el pokemon actualmente activo del entrenador.
    /// </summary>
    /// <returns>El pokemon actual.</returns>
    public Pokemon getActualPokemon()
    {
        return ActualPokemon;
    }

    /// <summary>
    /// Elimina un item específico de la lista de items del entrenador.
    /// </summary>
    /// <param name="item">El item a eliminar.</param>
    public void RemoveItem(Items item)
    {
        Items.Remove(item);
    }

    /// <summary>
    /// Usa un item específico en un pokemon objetivo.
    /// </summary>
    /// <param name="item">El item a usar.</param>
    /// <param name="objective">El pokemon en el cual usar el item.</param>
    public void useItem(Items item, Pokemon objective)
    {
        item.Use(objective);
    }
}