using NUnit.Framework;

namespace gettingstarted;

public class HardLinqExercises : IHardLinqExercises
{
    public List<string> GetAnagrams(string word, List<string> words)
    {
        throw new NotImplementedException();
    }

    public List<int> GetLongestIncreasingSequence(List<int> numbers)
    {
        throw new NotImplementedException();
    }
}

public interface IHardLinqExercises
{
    List<string> GetAnagrams(string word, List<string> words);
    List<int> GetLongestIncreasingSequence(List<int> numbers);
}

[TestFixture]
public class HardLinqTests
{
    private IHardLinqExercises _exercises;

    [SetUp]
    public void Setup()
    {
        _exercises = new HardLinqExercises();
    }

    [Test]
    public void TestGetAnagrams()
    {
        // Arrange
        string word = "post";
        var words = new List<string> { "stop", "tops", "spot", "posts", "hello", "world" };

        // Act
        var result = _exercises.GetAnagrams(word, words);

        // Assert
        Assert.That(result, Is.EquivalentTo(new List<string> { "stop", "tops", "spot" }));
    }

    [Test]
    public void TestGetLongestIncreasingSequence()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 1, 2, 3, 4, 1, 2 };

        // Act
        var result = _exercises.GetLongestIncreasingSequence(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3, 4 }));
    }
}