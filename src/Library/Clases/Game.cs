namespace Poke.Clases;

public class Game
{
    
    public int AleatoryTurn { get; set; }
    
    public Plays plays;
    
    public int Turn;
    
    // Constructor
    public Pokemon PlayerPokemon { get; set; }
    public Pokemon OpponentPokemon { get; set; }
    public int ActualTurn { get; set; }

    public void InitialTurn(Player player1, Player player2, Pokemon newPokemon, Items item, Pokemon objective)
    {
        Random random = new Random();
        int firstTurn = random.Next(1, 3);
        if (firstTurn == 1)
        {
            Turn = 1;
        }
        else
        {
            Turn = 2;
        }
    }
    public Game(Pokemon pokemonplayer, Pokemon opponentPokemon)
    {
        PlayerPokemon = pokemonplayer;
        OpponentPokemon = opponentPokemon;
        plays = new Plays();
        ActualTurn = 1;
    }

    public string PlayTurn(Player player1, Player player2)
    {
        if (Turn == 1)
        {
            Console.WriteLine("Turno del jugador 1");
            plays.PossiblePlays(player1, player2, player1.Items[0], player2.ActualPokemon);
            Turn = 2; // Cambia de turno para que vaya el otro jugador
        }
        else
        {
            Console.WriteLine("Turno del jugador 2");
            plays.PossiblePlays(player1, player2, player1.Items[0], player2.ActualPokemon);
            Turn = 1; // Idem que arriba
        }
        ActualTurn += 1;
        if (GameFinished(player1, player2) == true)
        {
            return "Juego terminado";
        }
        else
        {
            return "Siguiente turno!";
        }
    }

    public void InfoTurn(Player player1, Player player2)
    {
        Console.WriteLine("Turno: " + ActualTurn);
        Console.WriteLine($"Información de los pokemones totales del juego:");
        player1.GetPokemonsInfo();
        player2.GetPokemonsInfo();
    }
    public bool GameFinished(Player player1, Player player2)
    {
        player1.PokemonLife();
        player2.PokemonLife();
        if (player1.PokemonLife() == 0)
        {
            Console.WriteLine("El player 2 ha ganado");
            return true;
        }
        else if (player2.PokemonLife() == 0)
        {
            Console.WriteLine($"El player 1 ha ganado");
            return true;
        }
        return false;
    }
}