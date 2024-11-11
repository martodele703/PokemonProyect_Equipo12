namespace Poke.Clases;

public class WaitList
{
    private List<Trainer> waitList;

    public WaitList(Trainer? player1 = null, Trainer? player2 = null)
    {
        waitList = new List<Trainer>();
        if (player1 != null)
        {
            waitList.Add(player1);
        }
        if (player2 != null)
        {
            waitList.Add(player2);
        }
    }

    public void AddToWaitList(Trainer trainer)
    {
        if (trainer != null)
        {
            waitList.Add(trainer);
            Console.WriteLine($"{trainer.name} ha sido añadido a la lista de espera.");
        }
    }

    public List<Trainer> CheckIn()
    {
        var playersToPlay = new List<Trainer>();
        
        if (waitList.Count >= 2)
        {
            playersToPlay.Add(waitList[0]);
            playersToPlay.Add(waitList[1]);

            Console.WriteLine($"{playersToPlay[0].name} y {playersToPlay[1].name} están listos para jugar.");

            waitList.RemoveRange(0, 2); // Elimina los dos primeros elementos de la lista de espera
        }
        else
        {
            Console.WriteLine("No hay suficientes personas en la lista de espera para comenzar el juego.");
        }

        return playersToPlay;
    }

    public bool HasEnoughPlayers()
    {
        return waitList.Count >= 2;
    }
}