namespace Poke.Clases;

public class EstaDormido
{
    public void Dormir(Pokemon objetivo)
    {
        objetivo.State = "Dormido";
        if (objetivo.State == "Dormido")
        {
            Random random = new Random();
            int turnosDormido = random.Next(1,5); // Por 1 a 4 turnos no puede atacar
            int capacidadDeAtacar = 0;
        }
    }
}