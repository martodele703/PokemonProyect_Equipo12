using NUnit.Framework;
using Poke.Clases;
using Type = System.Type;

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
            // Crear los Pokemon
            pokemon1 = new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Earth);
            pokemon2 = new Pokemon("Bulbasaur", 100, 10, "2", Type.PokemonType.Water);
            pokemonOponente = new Pokemon("Charmander", 100, 10, "3", Type.PokemonType.Fire);

            // Crear los entrenadores
            jugador = new Trainer("Jugador1", pokemon1);
            oponente = new Trainer("Jugador2", pokemonOponente);

            //batalla
            batalla = new Battle(pokemon1, pokemonOponente);
        }

        [Test]
        public void CambioDePokemon_PierdeTurno_Test()
        {
            // Guardamos el turno inicial antes del cambio
            double turnoAntesDelCambio = batalla.Turn;
            jugador.ActualPokemon = pokemon2; // El jugador cambia de Pokemon
            Battle.PlayTurn(jugador, oponente); // El turno se alterna, por lo que despues del cambio debe pasar al oponente
            Assert.AreNotEqual(turnoAntesDelCambio, batalla.Turn, "El cambio de Pokémon debe hacer que el turno cambie.");
        }
    }
}