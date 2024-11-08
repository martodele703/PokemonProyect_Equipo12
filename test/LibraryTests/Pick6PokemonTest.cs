using NUnit.Framework;
using Poke.Clases;
using Type = Poke.Clases.Type;
using System.IO;
using System.Collections.Generic;

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
            catalogoPokemon = new List<Pokemon>
            {
                new Pokemon("Pikachu", 100, 10, "1", Type.PokemonType.Bug),
                new Pokemon("Charmander", 100, 10, "2", Type.PokemonType.Fire),
                new Pokemon("Bulbasaur", 100, 10, "3", Type.PokemonType.Plant),
                new Pokemon("Squirtle", 100, 10, "4", Type.PokemonType.Water),
                new Pokemon("Eevee", 100, 10, "5", Type.PokemonType.Normal),
                new Pokemon("Snorlax", 100, 10, "6", Type.PokemonType.Normal),
                new Pokemon("Jigglypuff", 100, 10, "7", Type.PokemonType.Flying)
            };

            jugador = new Trainer("Jugador 1", catalogoPokemon[0]);
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

            Assert.That(jugador.Pokemons.Count, Is.EqualTo(6), "El jugador debería tener 6 Pokémon.");
            for (int i = 0; i < 6; i++)
            {
                Assert.That(jugador.Pokemons[i], Is.EqualTo(catalogoPokemon[i]), $"El Pokémon {i + 1} no coincide.");
            }

            foreach (var pokemon in jugador.Pokemons)
            {
                Assert.That(consoleOutput.ToString(), Does.Contain(pokemon.Name), $"El nombre de {pokemon.Name} no se mostró en consola.");
            }
        }
    }
}
