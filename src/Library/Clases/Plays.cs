namespace Poke.Clases;

public class Plays
{
    public void PossiblePlays(Player player1, Player player2, Items item, Pokemon objective)
    {
        Console.WriteLine("1. Atacar \n 2. Cambiar de Pokemon \n 3. Usar Item");
        string playElection = Console.ReadLine();
        if (playElection == "1")
        {
            // Mostrar los ataques disponibles
            Console.WriteLine("Selecciona un ataque:");
            for (int i = 0; i < player1.ActualPokemon.AttackList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player1.ActualPokemon.AttackList[i].Name}");
            }

            // Leer la elección del usuario
            if (int.TryParse(Console.ReadLine(), out int selectedAtackIndex) &&
                selectedAtackIndex > 0 &&
                selectedAtackIndex <= player1.ActualPokemon.AttackList.Count)
            {
                // Obtener el ataque seleccionado de la lista
                Attack selectedAtack = player1.ActualPokemon.AttackList[selectedAtackIndex - 1];

                // Realizar el ataque con el ataque seleccionado
                player1.ActualPokemon.Atack(player2.ActualPokemon, player1.ActualPokemon, selectedAtack);
            }
            else if (playElection == "2")
            {
                Console.WriteLine("Selecciona un Pokemon:");
                for (int i = 0; i < player1.Pokemons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player1.Pokemons[i].Name}");
                }
                string newPokemon = Console.ReadLine();
                Pokemon selectedPokemon = player1.Pokemons[int.Parse(newPokemon) - 1];
                player1.ActualPokemon = selectedPokemon;
            }
            else if (playElection == "3")
            {
                item.Use(objective);
            }
            else
            {
                Console.WriteLine("Eleccion invalida");
            }
        }
    }
}