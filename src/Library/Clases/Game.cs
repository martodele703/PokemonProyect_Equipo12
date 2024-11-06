namespace Poke.Clases;

public class Game
{
    private Pokemon pokemonJugador;
    private int turnoAleatorio { get; set; }
    private Pokemon pokemonOponente;
    private Jugadas jugadas;

    private int turno;
    // Constructor
    public Pokemon PokemonJugador { get; set; }
    public Pokemon PokemonOponente { get; set; }
    public int TurnoActual { get; set; }

    public void JugadaInicial(Player jugador1, Player jugador2, Pokemon nuevoPokemon, Items item, Pokemon objetivo)
    {
        Random random = new Random();
        int primerTurno = random.Next(1, 3);
        if (primerTurno == 1)
        {
            turno = 1;
        }
        else
        {
            turno = 2;
        }
    }
    public Game(Pokemon pokemonJugador, Pokemon pokemonOponente)
    {
        PokemonJugador = pokemonJugador;
        PokemonOponente = pokemonOponente;
        jugadas = new Jugadas();
        TurnoActual = 1;
    }

    public string JugarTurno(Player jugador1, Player jugador2)
    {
        if (turno == 1)
        {
            Console.WriteLine("Turno del jugador 1");
            jugadas.PosiblesJugadas(jugador1, jugador2, jugador1.Items[0], jugador2.PokemonActual);
            turno = 2; // Cambia de turno para que vaya el otro jugador
        }
        else
        {
            Console.WriteLine("Turno del jugador 2");
            jugadas.PosiblesJugadas(jugador1, jugador2, jugador1.Items[0], jugador2.PokemonActual);
            turno = 1; // Idem que arriba
        }
        TurnoActual += 1;
        if (JuegoTerminado(jugador1, jugador2) == true)
        {
            return "Juego terminado";
        }
        else
        {
            return "Siguiente turno!";
        }
    }

    public void InfoTurno(Player jugador1, Player jugador2)
    {
        Console.WriteLine("Turno: " + TurnoActual);
        Console.WriteLine($"Información de los pokemones totales del juego:");
        jugador1.GetPokemonsInfo();
        jugador2.GetPokemonsInfo();
    }
    public bool JuegoTerminado(Player jugador1, Player jugador2)
    {
        jugador1.VidaPokemon();
        jugador2.VidaPokemon();
        if (jugador1.VidaPokemon() == 0)
        {
            Console.WriteLine("El jugador 2 ha ganado");
            return true;
        }
        else if (jugador2.VidaPokemon() == 0)
        {
            Console.WriteLine($"El jugador 1 ha ganado");
            return true;
        }
        else
        {
            return false;
        }
    }
}