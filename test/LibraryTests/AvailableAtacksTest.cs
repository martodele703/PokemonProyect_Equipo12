using NUnit.Framework;
using Poke.Clases;
using Type = Poke.Clases.Type;
namespace LibraryTests;
[TestFixture]
public class AvailableAttacksTest
{
    private Trainer jugador;
    private Pokemon pokemon;
    private Attack ataqueBasico;
    private Attack ataqueEspecial;
    private Battle battle; // Declaramos la instancia de Battle

    [SetUp]
    public void SetUp()
    {
        ataqueBasico = new Attack("Ataque Básico", 10, Type.PokemonType.Water, false);
        ataqueEspecial = new Attack("Ataque Especial", 20, Type.PokemonType.Electric, true);
        pokemon = new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Electric);
        pokemon.AttackList = new List<Attack> { ataqueBasico, ataqueEspecial };
        jugador = new Trainer("Jugador1", pokemon);

        // Creación de la instancia de Battle
        battle = new Battle(pokemon, new Pokemon("Charmander", 100, 10, "2", Type.PokemonType.Fire));
    }

    [Test]
    public void MostrarAtaquesDisponibles_Test()
    {
        // Verificar que se muestran los ataques para el turno actual
        List<Attack> ataquesDisponibles = pokemon.AttackList;
        Assert.That(ataquesDisponibles, Does.Contain(ataqueBasico));
        Assert.That(ataquesDisponibles, Does.Contain(ataqueEspecial));
    }

    [Test]
    public void AtaqueEspecial_RestriccionDeTurnos_Test()
    {
        // Simulamos el turno 1
        battle.CompleteBattle(jugador, new Trainer("Jugador2", new Pokemon("Charmander", 100, 10, "3", Type.PokemonType.Fire)));
        
        // Ahora verificamos si el turno ha avanzado
        bool puedeUsarEspecialTurno1 = battle.Turn == 1 ? false : true;
        Assert.That(puedeUsarEspecialTurno1, Is.False, "No debe poder usar ataque especial en el primer turno");
        battle.CompleteBattle(jugador, new Trainer("Jugador2", new Pokemon("Charmander", 100, 10, "3", Type.PokemonType.Fire)));
        
        // Ahora verificamos si puede usar el ataque especial en el segundo turno
        bool puedeUsarEspecialTurno2 = battle.Turn == 2;
        Assert.That(puedeUsarEspecialTurno2, Is.True, "Debe poder usar ataque especial en el segundo turno");
    }
}
