using Poke.Clases;

namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase recibe las acciones y devuelve los resultados que permiten
/// implementar las historias de usuario. Otras clases que implementan el bot
/// usan esta <see cref="Facade"/> pero no conocen el resto de las clases del
/// dominio. Esta clase es un singleton.
/// </summary>
public class Facade
{
    private static Facade? _instance;

    // Este constructor privado impide que otras clases puedan crear instancias
    // de esta.
    private Facade()
    {
        this.WaitingList = new WaitingList();
        this.BattlesList = new BattlesList();
    }

    /// <summary>
    /// Obtiene la única instancia de la clase <see cref="Facade"/>.
    /// </summary>
    public static Facade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Facade();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Inicializa este singleton. Es necesario solo en los tests.
    /// </summary>
    public static void Reset()
    {
        _instance = null;
    }
    
    private WaitingList WaitingList { get; }
    
    private BattlesList BattlesList { get; }

    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string AddTrainerToWaitingList(string displayName)
    {
        if (this.WaitingList.AddTrainer(displayName))
        {
            return $"{displayName} agregado a la lista de espera";
        }
        
        return $"{displayName} ya está en la lista de espera";
    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="displayName">El jugador a remover.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string RemoveTrainerFromWaitingList(string displayName)
    {
        if (this.WaitingList.RemoveTrainer(displayName))
        {
            return $"{displayName} removido de la lista de espera";
        }
        else
        {
            return $"{displayName} no está en la lista de espera";
        }
    }

    /// <summary>
    /// Obtiene la lista de jugadores esperando.
    /// </summary>
    /// <returns>Un mensaje con el resultado.</returns>
    public string GetAllTrainersWaiting()
    {
        if (this.WaitingList.Count == 0)
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Trainer trainer in this.WaitingList.GetAllWaiting())
        {
            result = result + trainer.DisplayName + "; ";
        }
        
        return result;
    }

    /// <summary>
    /// Determina si un jugador está esperando para jugar.
    /// </summary>
    /// <param name="displayName">El jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string TrainerIsWaiting(string displayName)
    {
        Trainer? trainer = this.WaitingList.FindTrainerByDisplayName(displayName);
        if (trainer == null)
        {
            return $"{displayName} no está esperando";
        }
        
        return $"{displayName} está esperando";
    }

    /// <summary>
    /// Crea una batalla entre dos jugadores y los elimina de la lista de espera.
    /// </summary>
    /// <param name="player">El primer jugador.</param>
    /// <param name="opponent">El oponente.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    private string CreateBattle(Trainer player, Trainer opponent)
    {
        this.WaitingList.RemoveTrainer(player.DisplayName);
        this.WaitingList.RemoveTrainer(opponent.DisplayName);
        
        BattlesList.AddBattle(player, opponent);
        return $"Comienza {player.DisplayName} vs {opponent.DisplayName}";
    }

    /// <summary>
    /// Inicia una batalla entre dos jugadores.
    /// </summary>
    /// <param name="playerDisplayName">El primer jugador.</param>
    /// <param name="opponentDisplayName">El oponente (opcional).</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string StartBattle(string playerDisplayName, string? opponentDisplayName)
    {
        Trainer? player = this.WaitingList.FindTrainerByDisplayName(playerDisplayName);
        if (player == null)
        {
            return $"{playerDisplayName} no está en la lista de espera";
        }

        Trainer? opponent;

        if (!OpponentProvided() && !SomebodyIsWaiting())
        {
            return "No hay nadie esperando";
        }
        
        if (!OpponentProvided())
        {
            opponent = this.WaitingList.GetAnyoneWaiting();
            return this.CreateBattle(player, opponent!);
        }

        opponent = this.WaitingList.FindTrainerByDisplayName(opponentDisplayName!);
        
        if (!OpponentFound())
        {
            return $"{opponentDisplayName} no está esperando";
        }
        
        return this.CreateBattle(player, opponent!);
        
        // Funciones locales para mejorar la legibilidad

        bool OpponentProvided()
        {
            return !string.IsNullOrEmpty(opponentDisplayName);
        }

        bool SomebodyIsWaiting()
        {
            return this.WaitingList.Count != 0;
        }

        bool OpponentFound()
        {
            return opponent != null;
        }
    }
} 
