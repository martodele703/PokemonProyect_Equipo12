using NUnit.Framework;
using Poke.Clases;
using Type = System.Type;

namespace LibraryTests;

[TestFixture]
public class PlayersWaitListTest
{
    private OriginalTrainer trainer1;
    private OriginalTrainer trainer2;
    private Pokemon pokemon;

    [SetUp]
    public void SetUp()
    {
        pokemon = new Pokemon("Pikachu", 100, 10, "1", Poke.Clases.Type.PokemonType.Electric);
        trainer1 = new OriginalTrainer("Jugador1", pokemon);
        trainer2 = new OriginalTrainer("Jugador1", pokemon);
    }

    [Test]
    public void Constructor_AddsInitialPlayers_WhenProvided()
    {
        WaitList waitList = new WaitList(trainer1, trainer2);

        Assert.That(waitList.CheckIn().Count, Is.EqualTo(2), "Los jugadores iniciales deberían estar en la lista de espera.");
    }

    [Test]
    public void AddToWaitList_AddsTrainer_WhenTrainerIsNotNull()
    {
        WaitList waitList = new WaitList();
        OriginalTrainer newOriginalTrainer = new OriginalTrainer("NewPlayer", pokemon);
        
        waitList.AddToWaitList(newOriginalTrainer);
        
        Assert.That(waitList.HasEnoughPlayers(), Is.True, "El entrenador debería haber sido añadido a la lista de espera.");
    }

    [Test]
    public void AddToWaitList_DoesNotAddNullTrainer()
    {
        WaitList waitList = new WaitList();
        
        waitList.AddToWaitList(null);
        
        Assert.That(waitList.HasEnoughPlayers(), Is.False, "Un entrenador nulo no debería añadirse a la lista de espera.");
    }

    [Test]
    public void CheckIn_RemovesTwoTrainers_WhenEnoughPlayersAreAvailable()
    {
        WaitList waitList = new WaitList(trainer1, trainer2);
        
        List<OriginalTrainer> playersToPlay = waitList.CheckIn();

        Assert.That(playersToPlay.Count, Is.EqualTo(2), "Debería haber dos jugadores listos para jugar.");
        Assert.That(waitList.HasEnoughPlayers(), Is.False, "La lista de espera debería estar vacía después de remover dos jugadores.");
    }

    [Test]
    public void CheckIn_DoesNotRemovePlayers_WhenNotEnoughPlayersAreAvailable()
    {
        WaitList waitList = new WaitList(trainer1);
        
        List<OriginalTrainer> playersToPlay = waitList.CheckIn();
        
        Assert.That(playersToPlay.Count, Is.EqualTo(0), "No debería haber jugadores listos para jugar.");
        Assert.That(waitList.HasEnoughPlayers(), Is.False, "La lista de espera no debería tener jugadores suficientes.");
    }

    [Test]
    public void HasPlayers_ReturnsTrue_WhenTwoOrMorePlayersInWaitList()
    {
        WaitList waitList = new WaitList(trainer1, trainer2);

        bool result = waitList.HasEnoughPlayers();
        
        Assert.That(result, Is.True, "Debería retornar true cuando hay dos o más jugadores en la lista de espera.");
    }

    [Test]
    public void HasPlayers_ReturnsFalse_WhenLessThanTwoPlayersInWaitList()
    {
        WaitList waitList = new WaitList(trainer1);

        bool result = waitList.HasEnoughPlayers();

        Assert.That(result, Is.False, "Debería retornar false cuando hay menos de dos jugadores en la lista de espera.");
    }
}