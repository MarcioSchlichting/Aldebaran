using Aldebaran.Accounts.Models.ValueObjects;

namespace Aldebaran.Accounts.Tests.Accounts;

[TestFixture]
public class NameTests
{
    [TestCase("")]
    [TestCase(null)]
    public void WhenInformInvalidName_ThenShouldThrowException(string nameArg)
    {
        // Arrange
        var name = nameArg;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Name(name));

        // Assert
        Assert.AreEqual("Invalid name", exception.Message);
    }
    
    [Test]
    public void WhenInformValidName_ThenShouldCreateName()
    {
        // Arrange
        var name = "Marcio Sérgios";

        // Act
        var result = new Name(name);
        
        // Assert
        Assert.IsTrue(name == result);
    }
    
    [Test]
    public void WhenNameIsLessThan5Characters_ThenShouldThrowException()
    {
        // Arrange
        var name = "Marc";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Name(name));

        // Assert
        Assert.AreEqual("Invalid name", exception.Message);
    }
    
    [Test]
    public void WHenNameIsEqualsTo5Characters_ThenShouldThrowException()
    {
        // Arrange
        var name = "Marc1";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Name(name));

        // Assert
        Assert.AreEqual("Invalid name", exception.Message);
    }
}