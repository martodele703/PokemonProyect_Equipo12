namespace Poke.Clases;

/// <summary>
/// Representa una batalla entre dos entrenadores Pokémon, gestionando turnos, jugadas, y verificando el final del juego.
/// </summary>
public class Battle
{
    /// <summary>
    /// Determina el turno inicial de forma aleatoria entre los dos jugadores.
    /// </summary>
    public double AleatoryTurn { get; set; }
    
    /// <summary>
    /// Instancia para gestionar las jugadas posibles en cada turno.
    /// </summary>
    public Plays plays;
    
    /// <summary>
    /// Representa el turno actual en la batalla, alternando entre los jugadores.
    /// </summary>
    public double Turn;
    
    /// <summary>
    /// Pokemon del jugador principal.
    /// </summary>
    public Pokemon PlayerPokemon { get; set; }
    
    /// <summary>
    /// Pokemon del oponente.
    /// </summary>
    public Pokemon OpponentPokemon { get; set; }
    
    /// <summary>
    /// Contador del turno actual.
    /// </summary>
    public double ActualTurn { get; set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Battle"/>.
    /// </summary>
    /// <param name="playerPokemon">El pokemon del jugador.</param>
    /// <param name="opponentPokemon">El pokemon oponente.</param>
    public Battle(Pokemon playerPokemon, Pokemon opponentPokemon)
    {
        PlayerPokemon = playerPokemon;
        OpponentPokemon = opponentPokemon;
        plays = new Plays();
        ActualTurn = 1;
    }

    /// <summary>
    /// Determina de forma aleatoria cuál jugador comienza el primer turno.
    /// </summary>
    private void InitialTurn()
    {
        Random random = new Random();
        Turn = random.Next(1, 3); // 1 para el primer jugador, 2 para el segundo jugador
    }

    /// <summary>
    /// Ejecuta un turno de la batalla, permitiendo a un jugador realizar una jugada y luego alterna el turno al otro jugador.
    /// </summary>
    /// <param name="player1">El primer entrenador.</param>
    /// <param name="player2">El segundo entrenador.</param>
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
    /// Verifica si la batalla ha terminado, es decir, si uno de los jugadores ha ganado.
    /// </summary>
    /// <param name="player1">El primer entrenador.</param>
    /// <param name="player2">El segundo entrenador.</param>
    /// <returns>True si uno de los jugadores ha ganado; de lo contrario, False.</returns>
    private bool BattleFinished(Trainer player1, Trainer player2)
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
    /// Muestra el estado actual de los Pokémon de ambos jugadores, incluyendo el turno actual.
    /// </summary>
    /// <param name="player1">El primer entrenador.</param>
    /// <param name="player2">El segundo entrenador.</param>
    private void InfoTurn(Trainer player1, Trainer player2)
    {
        Console.WriteLine("Turno: " + ActualTurn);
        Console.WriteLine($"Información de los pokemones totales del juego:");
        player1.GetPokemonsInfo();
        player2.GetPokemonsInfo();
    }

    /// <summary>
    /// Ejecuta la batalla completa entre dos pokemon, alternando turnos hasta que uno de los jugadores gane.
    /// </summary>
    /// <param name="player1">El primer entrenador.</param>
    /// <param name="player2">El segundo entrenador.</param>
    public void CompleteBattle(Trainer player1, Trainer player2)
    {
        InitialTurn();
        Console.WriteLine($"El jugador {Turn} comienza la batalla.");

        while (!BattleFinished(player1, player2))
        {
            InfoTurn(player1, player2); // Muestra el estado actual de los Pokémon
            PlayTurn(player1, player2); // Ejecuta un turno alternando entre los jugadores
        }
        Console.WriteLine("La batalla ha terminado.");
    }
}
