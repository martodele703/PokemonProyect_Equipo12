using NUnit.Framework;
using Poke.Clases;
namespace LibraryTests
{
    [TestFixture]
    public class Pick6PokemonTest
    {
        private Trainer jugador;
        private List<Pokemon> catalogoPokemon;

        [SetUp]
        public void SetUp()
        {
            // Crear un catálogo de Pokémon de ejemplo
            catalogoPokemon = new List<Pokemon>
            {
                new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Electric),
                new Pokemon("Charmander", 100, 10, "2", Type.PokemonType.Fire),
                new Pokemon("Bulbasaur", 100, 10, "3", Type.PokemonType.Plant),
                new Pokemon("Squirtle", 100, 10, "4", Type.PokemonType.Water),
                new Pokemon("Eevee", 100, 10, "5", Type.PokemonType.Normal),
                new Pokemon("Snorlax", 100, 10, "6", Type.PokemonType.Normal),
                new Pokemon("Jigglypuff", 100, 10, "7", Type.PokemonType.Flying)
            };

            // Crear un jugador con un nombre
            jugador = new Trainer("Jugador 1", catalogoPokemon[0]); // empieza con Pikachu
        }

        [Test]
        public void Elegir6PokemonsTest()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Console.WriteLine("Selecciona tus 6 Pokémon:");
            for (int i = 0; i < catalogoPokemon.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {catalogoPokemon[i].Name}");
            }
            for (int i = 0; i < 6; i++)
            {
                jugador.Pokemons.Add(catalogoPokemon[i]);
            }
            Assert.AreEqual(6, jugador.Pokemons.Count, "El jugador debería tener 6 Pokémon.");
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(catalogoPokemon[i], jugador.Pokemons[i], $"El Pokémon {i + 1} no coincide.");
            }
            foreach (var pokemon in jugador.Pokemons)
            {
                Assert.IsTrue(consoleOutput.ToString().Contains(pokemon.Name), $"El nombre de {pokemon.Name} no se mostró en consola.");
            }
        }
    }
}
