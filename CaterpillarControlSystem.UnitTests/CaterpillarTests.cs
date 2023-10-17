using Xunit;

public class CaterpillarTests
{
    [Fact]
    public void Caterpillar_EatsSpice_ShouldRemoveSpiceFromPlanet()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        // Set the head position to a spice location
        caterpillar.MoveUp(1);
        caterpillar.MoveUp(1);
        int headX = caterpillar.GetHeadX();
        int headY = caterpillar.GetHeadY();
        planet[headX, headY] = '$';

        // Act
        caterpillar.CheckCollision();

        // Assert
        Assert.Equal('*', planet[headX, headY]);
    }
    [Fact]
    public void Caterpillar_EatsBooster_ShouldRemoveBoosterFromPlanet()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        // Set the head position to a booster location
        caterpillar.MoveUp(1);
        caterpillar.MoveUp(1);
        int headX = caterpillar.GetHeadX();
        int headY = caterpillar.GetHeadY();
        planet[headX, headY] = 'B';

        // Act
        caterpillar.CheckCollision();

        // Assert
        Assert.Equal('*', planet[headX, headY]);
    }
    [Fact]
    public void Caterpillar_HitsObstacle_ShouldDisintegrate()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

       
        caterpillar.MoveUp(1);
        caterpillar.MoveUp(1);
        int headX = caterpillar.GetHeadX();
        int headY = caterpillar.GetHeadY();
        planet[headX, headY] = '#';

        // Act
        caterpillar.CheckCollision();

        // Assert
        // Check if caterpillar has disintegrated (back to initial state)
        Assert.Collection(caterpillar.GetSegments(), segment => Assert.Equal("H", segment), segment => Assert.Equal("T", segment));
    }
    [Fact]
    public void MoveUp_WhenHeadYIsGreaterThanZero_ShouldMoveHeadUp()
    {
        // Arrange
    
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);
        int initialHeadY = caterpillar.GetHeadY();

        // Act
        caterpillar.MoveUp(1);

        int newHeadY = caterpillar.GetHeadY();

        // Assert
        Assert.True(newHeadY < initialHeadY);
    }
    [Fact]
    public void MoveDown_WhenHeadYIsLessThanPlanetHeightMinusOne_ShouldMoveHeadDown()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        caterpillar.MoveUp(1); 

        int initialHeadY = caterpillar.GetHeadY();

        // Act
        caterpillar.MoveDown(1);

        int newHeadY = caterpillar.GetHeadY();

        // Assert
        Assert.True(newHeadY > initialHeadY);
    }

    [Fact]
    public void MoveLeft_WhenHeadXIsGreaterThanZero_ShouldMoveHeadLeft()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        caterpillar.MoveRight(1); // Move the head right once

        int initialHeadX = caterpillar.GetHeadX();

        // Act
        caterpillar.MoveLeft(1);
        int newHeadX = caterpillar.GetHeadX();

        // Assert
        Assert.True(newHeadX < initialHeadX);
    }
    [Fact]
    public void MoveRight_WhenHeadXIsLessThanPlanetWidthMinusOne_ShouldMoveHeadRight()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        // Set the initial head position to allow moving right
        caterpillar.MoveLeft(1); // Move the head left once

        int initialHeadX = caterpillar.GetHeadX();

        // Act
        caterpillar.MoveRight(1);
        int newHeadX = caterpillar.GetHeadX();

        // Assert
        Assert.True(newHeadX > initialHeadX);
    }
    [Fact]
    public void Grow_WhenSegmentsCountIsLessThanMaxSegments_ShouldAddSegment()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);

        Caterpillar caterpillar = new Caterpillar(planet);
        int initialSegmentCount = caterpillar.GetSegments().Count;

        // Act
        caterpillar.Grow();
        int newSegmentCount = caterpillar.GetSegments().Count;

        // Assert
        Assert.True(newSegmentCount > initialSegmentCount);
    }
    [Fact]
    public void Shrink_WhenSegmentsCountIsGreaterThanTwo_ShouldRemoveSegment()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        // Grow the caterpillar initially
        caterpillar.Grow();

        int initialSegmentCount = caterpillar.GetSegments().Count;

        // Act
        caterpillar.Shrink();
        int newSegmentCount = caterpillar.GetSegments().Count;

        // Assert
        Assert.True(newSegmentCount < initialSegmentCount);
    }
    [Fact]
    public void Undo_WhenCommandHistoryHasCommands_ShouldUndoLastCommand()
    {
        // Arrange
        char[,] planet = new char[30, 30];
        Program.InitializePlanet(planet);
        Caterpillar caterpillar = new Caterpillar(planet);

        // Move the caterpillar
        caterpillar.MoveUp(1);

        int initialHeadY = caterpillar.GetHeadY();

        // Act: Undo the move
        caterpillar.Undo();

        // Assert: The head should be back to the initial position
        Assert.Equal(initialHeadY, caterpillar.GetHeadY());
    }
}
