namespace Aldebaran.Accounts.Tests.Accounts;

[TestFixture]
public class UserNameTests
{
    [Test]
    public void UserName_ShouldBeValid_WhenLengthIsBetweenMinAndMax()
    {
        // Arrange
        var userName = new UserName("1234567890");
        var validator = new UserNameValidator();
        
        // Act
        var result = validator.Validate(userName);
        
        // Assert
        Assert.That(result.IsValid, Is.True);
    }
}