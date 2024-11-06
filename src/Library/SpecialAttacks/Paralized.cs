namespace Poke.Clases;

public class Paralized
{
    public void Paralize(Pokemon objective)
    {
        objective.State = "Paralizado";
        if (objective.State == "Paralizado")
            
        {
            Random random = new Random();
            int atackCapacity = random.Next(0,2); // 0 o 1 definen si puede atacar
        }
    }
}