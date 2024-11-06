namespace Poke.Clases;

public class Jugadas
{
    public void PosiblesJugadas(Player jugador1, Player jugador2, Items item, Pokemon objetivo)
    {
        Console.WriteLine("1. Atacar \n 2. Cambiar de Pokemon \n 3. Usar Item");
        string eleccionJugada = Console.ReadLine();
        if (eleccionJugada == "1")
        {
            // Mostrar los ataques disponibles
            Console.WriteLine("Selecciona un ataque:");
            for (int i = 0; i < jugador1.PokemonActual.ListaDeAtaques.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {jugador1.PokemonActual.ListaDeAtaques[i].Nombre}");
            }

            // Leer la elección del usuario
            if (int.TryParse(Console.ReadLine(), out int ataqueSeleccionadoIndex) &&
                ataqueSeleccionadoIndex > 0 &&
                ataqueSeleccionadoIndex <= jugador1.PokemonActual.ListaDeAtaques.Count)
            {
                // Obtener el ataque seleccionado de la lista
                Attack ataqueSeleccionado = jugador1.PokemonActual.ListaDeAtaques[ataqueSeleccionadoIndex - 1];

                // Realizar el ataque con el ataque seleccionado
                jugador1.PokemonActual.Atacar(jugador2.PokemonActual, jugador1.PokemonActual, ataqueSeleccionado);
            }
            else if (eleccionJugada == "2")
            {
                Console.WriteLine("Selecciona un Pokemon:");
                for (int i = 0; i < jugador1.Pokemones.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {jugador1.Pokemones[i].Nombre}");
                }
                string nuevoPokemon = Console.ReadLine();
                Pokemon pokemonSeleccionado = jugador1.Pokemones[int.Parse(nuevoPokemon) - 1];
                jugador1.PokemonActual = pokemonSeleccionado;
            }
            else if (eleccionJugada == "3")
            {
                item.Usar(objetivo);
            }
            else
            {
                Console.WriteLine("Eleccion invalida");
            }
        }
    }
}