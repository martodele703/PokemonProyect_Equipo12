using NUnit.Framework;
using Poke.Clases;
using Type = Poke.Clases.Type;

namespace LibraryTests
{
    [TestFixture]
    public class ChangePokemonTest
    {
        private Trainer jugador;
        private Trainer oponente;
        private Pokemon pokemon1;
        private Pokemon pokemon2;
        private Pokemon pokemonOponente;
        private Battle batalla;

        [SetUp]
        public void SetUp()
        {
            pokemon1 = new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Bug);
            pokemon2 = new Pokemon("Bulbasaur", 100, 10, "2", Type.PokemonType.Water);
            pokemonOponente = new Pokemon("Charmander", 100, 10, "3", Type.PokemonType.Fire);
            jugador = new Trainer("Jugador1", pokemon1);
            oponente = new Trainer("Jugador2", pokemonOponente);
            batalla = new Battle(pokemon1, pokemonOponente);
        }

        [Test]
        public void CambioDePokemon_PierdeTurno_Test()
        {
            double turnoAntesDelCambio = batalla.Turn;
            jugador.ActualPokemon = pokemon2;
            batalla.CompleteBattle(jugador, oponente);
            Assert.That(batalla.Turn, Is.EqualTo(turnoAntesDelCambio), "El cambio de Pokémon no debe hacer que el turno cambie.");
        }
    }
}