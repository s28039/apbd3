namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstIsEmpty()
    {
        
        //Arrange
        var UserService = new UserService();

        //Act
        var result = UserService.AddUser(null, "Kowalski", "kowalski@wp.pl", DateTime.Now, 1);
        

        //Assert
        Assert.False(result);

    }
}