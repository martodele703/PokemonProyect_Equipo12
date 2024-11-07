using Ucu.Poo.DiscordBot.Domain;

namespace Poke.Clases;

public class Battle
{
    public double AleatoryTurn { get; set; }
    public Plays plays;
    public double Turn;
    public Trainer PlayerPokemon { get; set; }
    public Trainer OpponentPokemon { get; set; }
    public double ActualTurn { get; set; }

    // Constructor
    public Battle(Trainer playerPokemon, Trainer opponentPokemon)
    {
        PlayerPokemon = playerPokemon;
        OpponentPokemon = opponentPokemon;
        plays = new Plays();
        ActualTurn = 1;
    }

    /// <summary>
    /// Inicializa el turno aleatorio entre dos jugadores.
    /// </summary>
    private void InitialTurn()
    {
        Random random = new Random();
        Turn = random.Next(1, 3); // 1 para el primer jugador, 2 para el segundo jugador
    }

    /// <summary>
    /// Juega un turno entre dos jugadores y alterna el turno.
    /// </summary>
    private void PlayTurn(Trainer player1, Trainer player2)
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
            plays.PossiblePlays(player2, player1, player2.Items[0], player1.ActualPokemon);
            Turn = 1; // Cambia de turno para el jugador 1
        }
        ActualTurn += 1;
    }

    /// <summary>
    /// Verifica si el juego ha terminado, devolviendo true si uno de los jugadores ha ganado.
    /// </summary>
    private bool GameFinished(Trainer player1, Trainer player2)
    {
        player1.PokemonLife();
        player2.PokemonLife();
        if (player1.PokemonLife() == 0)
        {
            Console.WriteLine("El jugador 2 ha ganado");
            return true;
        }
        else if (player2.PokemonLife() == 0)
        {
            Console.WriteLine("El jugador 1 ha ganado");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Información del turno actual y estado de los Pokémon de cada jugador.
    /// </summary>
    private void InfoTurn(Trainer player1, Trainer player2)
    {
        Console.WriteLine("Turno: " + ActualTurn);
        Console.WriteLine($"Información de los pokemones totales del juego:");
        player1.GetPokemonsInfo();
        player2.GetPokemonsInfo();
    }

    /// <summary>
    /// Ejecuta la batalla completa entre dos jugadores hasta que uno gane.
    /// </summary>
    public void Game(Trainer player1, Trainer player2)
    {
        InitialTurn();
        Console.WriteLine($"El jugador {Turn} comienza la batalla.");

        while (!GameFinished(player1, player2))
        {
            InfoTurn(player1, player2); // Muestra el estado actual de los Pokémon
            PlayTurn(player1, player2); // Ejecuta un turno alternando entre los jugadores
        }
        Console.WriteLine("La batalla ha terminado.");
    }
}
