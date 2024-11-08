using NUnit.Framework;
using Poke.Clases;
using Type = System.Type;

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
            // Crear los entrenadores y asignarles un Poke activo
            jugador1 = new Trainer("Jugador 1", new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Electric));
            jugador2 = new Trainer("Jugador 2", new Pokemon("Charizard", 100, 10, "2", Type.PokemonType.Fire));

            // Asegurarse de que los entrenadores tienen algunos Pkes
            jugador1.Pokemons.Add(jugador1.ActualPokemon);
            jugador2.Pokemons.Add(jugador2.ActualPokemon);

            // Crear la batalla
            battle = new Battle(jugador1.ActualPokemon, jugador2.ActualPokemon);
        }

        [Test]
        public void NotificarInicioDeBatalla_Test()
        {
            // Redirigir la salida normal para capturar los mensajes de inicio
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            battle.Game(jugador1, jugador2);
            Assert.IsTrue(consoleOutput.ToString().Contains("El jugador 1 comienza la batalla"));
            Assert.IsTrue(consoleOutput.ToString().Contains("El jugador 2 comienza la batalla"));
        }

        [Test]
        public void DeterminarTurnoAleatorio_Test()
        {
            // Redirigir la salida estándar para capturar el turno inicial
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Iniciar la batalla varias veces y verificar que el turno es aleatorio
            string turnoInicial = "";
            for (int i = 0; i < 10; i++)
            {
                battle.Game(jugador1, jugador2);
                if (consoleOutput.ToString().Contains("El jugador 1 comienza la batalla"))
                {
                    turnoInicial = "Jugador 1";
                }
                else if (consoleOutput.ToString().Contains("El jugador 2 comienza la batalla"))
                {
                    turnoInicial = "Jugador 2";
                }

                // Asegurarse de que el turno es aleatorio, es decir, que no siempre es el mismo
                Assert.AreNotEqual(turnoInicial, "");
            }
        }
    }
}
