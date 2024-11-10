namespace Poke.Clases;

public class WaitList
{
    private List<string> waitList;

    public WaitList()
    {
        waitList = new List<string>();
    }

    /// <summary>
    /// Agrega una persona a la lista de espera.
    /// </summary>
    /// <param name="name">El nombre de la persona.</param>
    public void AddToWaitList(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            waitList.Add(name);
            Console.WriteLine($"{name} ha sido añadido a la lista de espera.");
        }
        else
        {
            Console.WriteLine("El nombre no puede estar vacío.");
        }
    }

    /// <summary>
    /// Remueve la primera persona de la lista de espera.
    /// </summary>
    public void RemoveFromWaitList()
    {
        if (waitList.Count > 0)
        {
            string name = waitList[0];
            waitList.RemoveAt(0);
            Console.WriteLine($"{name} ha sido removido de la lista de espera.");
        }
        else
        {
            Console.WriteLine("La lista de espera está vacía.");
        }
    }

    /// <summary>
    /// Muestra el estado actual de la lista de espera.
    /// </summary>
    public void ShowWaitList()
    {
        if (waitList.Count > 0)
        {
            Console.WriteLine("Lista de espera actual:");
            for (int i = 0; i < waitList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {waitList[i]}");
            }
        }
        else
        {
            Console.WriteLine("La lista de espera está vacía.");
        }
    }

    /// <summary>
    /// Devuelve el número de personas en la lista de espera.
    /// </summary>
    /// <returns>La cantidad de personas en la lista de espera.</returns>
    public int Count()
    {
        return waitList.Count;
    }
}