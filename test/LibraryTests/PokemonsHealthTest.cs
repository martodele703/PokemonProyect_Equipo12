using NUnit.Framework;
using Poke.Clases;
using Type = Poke.Clases.Type;

namespace LibraryTests
{
    [TestFixture]
    public class PokemonsHealthTest
    {
        private Pokemon pokemon1;
        private Pokemon pokemon2;
        private Attack attack;

        [SetUp]
        public void Setup()
        {
            pokemon1 = new Pokemon("Pikachu", 100, 50, null, Type.PokemonType.Electric);
            pokemon2 = new Pokemon("Bulbasaur", 80, 40, null, Type.PokemonType.Plant);
            attack = new Attack("Thunderbolt", 25, Type.PokemonType.Electric, false);
        }

        [Test]
        public void Test_PokemonHpUpdatesAfterAttack()
        {
            // Asegurarse de que el HP es correcto
            Assert.AreEqual(80, pokemon2.Hp);

            // Pikachu ataca a Bulbasaur
            pokemon1.Attack(pokemon2, pokemon1, attack);
            Assert.AreEqual(55, pokemon2.Hp, "Los puntos de vida de Bulbasaur no se actualizaron correctamente después del ataque.");
        }

        [Test]
        public void Test_PokemonIsAliveAfterTakingDamage()
        {
            // Realizar un ataque y reducir los HP de Pikachu
            pokemon1.RecibeDamage(30);
            Assert.AreEqual("El Pokemon está vivo", pokemon1.IsAlive());
        }

        [Test]
        public void Test_PokemonDiesWhenHpIsZero()
        {
            // Reducir los puntos de vida de Pikachu hasta que esté muerto
            pokemon1.RecibeDamage(100);
            Assert.AreEqual("El Pokemon está muerto", pokemon1.IsAlive());
        }

        [Test]
        public void Test_PokemonHpNotBelowZero()
        {
            // Reducir los puntos de vida de Pikachu a un valor negativo
            pokemon1.RecibeDamage(200);
            Assert.AreEqual(0, pokemon1.Hp, "Los puntos de vida de Pikachu no deberían ser negativos.");
        }
    }
}
