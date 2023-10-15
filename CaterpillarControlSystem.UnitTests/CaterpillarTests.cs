using Xunit;

public class CaterpillarTests
{
    [Fact]
    public void MoveUp_WhenHeadYIsGreaterThanZero_ShouldMoveHeadUp()
    {
        // Arrange
    
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);
        int initialHeadY = caterpillar.GetHeadY();

        // Act
        caterpillar.MoveUp();

        int newHeadY = caterpillar.GetHeadY();

        // Assert
        Assert.True(newHeadY < initialHeadY);
    }
}
