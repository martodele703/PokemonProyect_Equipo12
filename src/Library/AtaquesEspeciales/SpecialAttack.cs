namespace Poke.Clases;

public class SpecialAttack : Attack
{
    public SpecialAttack(string nombre, int daño, Type.PokemonType tipo)
    {
        this.Nombre = nombre;
        this.Daño = daño;
        this.Tipo = tipo;
        this.EsEspecial = true;
    }
}