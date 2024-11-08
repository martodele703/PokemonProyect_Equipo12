using NUnit.Framework;
using Poke.Clases;
using Type = Poke.Clases.Type;
using System.IO;

namespace LibraryTests
{
    [TestFixture]
    public class IniciateBattleWithWaitListOpponentTest
    {
        private Trainer jugador1;
        private Trainer jugador2;
        private Battle battle;

        [SetUp]
        public void SetUp()
        {
            jugador1 = new Trainer("Jugador 1", new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Electric));
            jugador2 = new Trainer("Jugador 2", new Pokemon("Charizard", 100, 10, "2", Type.PokemonType.Fire));
            jugador1.Pokemons.Add(jugador1.ActualPokemon);
            jugador2.Pokemons.Add(jugador2.ActualPokemon);
            battle = new Battle(jugador1.ActualPokemon, jugador2.ActualPokemon);
        }

        [Test]
        public void NotificarInicioDeBatalla_Test()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            battle.CompleteBattle(jugador1, jugador2);
            Assert.That(consoleOutput.ToString(), Contains.Substring("El jugador 1 comienza la batalla"));
            Assert.That(consoleOutput.ToString(), Contains.Substring("El jugador 2 comienza la batalla"));
        }

        [Test]
        public void DeterminarTurnoAleatorio_Test()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            string turnoInicial = "";
            for (int i = 0; i < 10; i++)
            {
                battle.CompleteBattle(jugador1, jugador2);
                if (consoleOutput.ToString().Contains("El jugador 1 comienza la batalla"))
                {
                    turnoInicial = "Jugador 1";
                }
                else if (consoleOutput.ToString().Contains("El jugador 2 comienza la batalla"))
                {
                    turnoInicial = "Jugador 2";
                }

                Assert.That(turnoInicial, Is.Not.Empty);
            }
        }
    }
}