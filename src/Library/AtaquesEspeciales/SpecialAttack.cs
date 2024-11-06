namespace Poke.Clases;

public class SpecialAttack : Attack
{
    public SpecialAttack(string nombre, int daño, string tipo)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipo = tipo;
        this.EsEspecial = true;
    }
}