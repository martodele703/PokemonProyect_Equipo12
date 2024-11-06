namespace Poke.Clases;

public class IsAsleep
{
    public void Sleep(Pokemon objective)
    {
        objective.State = "Dormido";
        if (objective.State == "Dormido")
        {
            Random random = new Random();
            int sleepTurns = random.Next(1,5); // Por 1 a 4 turnos no puede atacar
            int atackCapacity = 0;
        }
    }
}