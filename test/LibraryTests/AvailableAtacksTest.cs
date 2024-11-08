using NUnit.Framework;
using Poke.Clases;
using Type = Poke.Clases.Type;

namespace LibraryTests
{
    [TestFixture]
    public class AvailableAttacksTest
    {
        private Trainer jugador;
        private Pokemon pokemon;
        private Attack ataqueBasico;
        private Attack ataqueEspecial;
        private Plays plays;

        [SetUp]
        public void SetUp()
        {
            // Configuración de un pokemon con ataques
            ataqueBasico = new Attack("Ataque Básico", 10, Type.PokemonType.Water, false);
            ataqueEspecial = new Attack("Ataque Especial", 20, Type.PokemonType.Electric, true);
            pokemon = new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Electric);
            pokemon.AttackList = new List<Attack> { ataqueBasico, ataqueEspecial };
            jugador = new Trainer("Jugador1", pokemon);
            plays = new Plays();
        }

        [Test]
        public void MostrarAtaquesDisponibles_Test()
        {
            // Verificar que se muestran los ataques para el turno actual
            List<Attack> ataquesDisponibles = pokemon.AttackList;
            Assert.IsTrue(ataqueBasico, ataquesDisponibles);
            Assert.IsTrue(ataqueEspecial, ataquesDisponibles);
        }

        [Test]
        public void AtaqueEspecial_RestriccionDeTurnos_Test()
        {
            //debe permitir usar el ataque especial
            bool puedeUsarEspecialTurno1 = Battle.Turn == 1 ? true : false;  
            Assert.IsFalse(puedeUsarEspecialTurno1, "No debe poder usar ataque especial en el primer turno");

            // Avanzamos al turno 2 (turno de ataque especial permitido)
            Battle.PlayTurn(jugador, new Trainer("Jugador2", new Pokemon("Charmander", 100, 10, "3", Type.PokemonType.Fire)));
            bool puedeUsarEspecialTurno2 = Battle.Turn == 2;  
            Assert.IsTrue(puedeUsarEspecialTurno2, "Debe poder usar ataque especial en el segundo turno");
        }
    }
}