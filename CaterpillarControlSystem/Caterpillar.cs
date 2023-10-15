using System;

public class Caterpillar
{
    private List<string> segments;
    private int headX;
    private int headY;
    private int tailX;
    private int tailY;
    private const int MaxSegments = 5;
    private char[,] planet;

    public Caterpillar(char[,] planet)
    {
        segments = new List<string> { "H", "T" };
        headX = planet.GetLength(0) / 2;
        headY = planet.GetLength(1) - 1;
        tailX = headX;
        tailY = headY - 1;
        this.planet = planet;
    }

    public void MoveUp()
    {
        if (headY > 0)
        {
            tailX = headX;
            tailY = headY;
            headY--;
            CheckCollision();
        }
    }

    public void MoveDown()
    {
        if (headY < planet.GetLength(1) - 1)
        {
            tailX = headX;
            tailY = headY;
            headY++;
            CheckCollision();
        }
    }

    public void MoveLeft()
    {
        if (headX > 0)
        {
            tailX = headX;
            tailY = headY;
            headX--;
            CheckCollision();
        }
    }

    public void MoveRight()
    {
        if (headX < planet.GetLength(0) - 1)
        {
            tailX = headX;
            tailY = headY;
            headX++;
            CheckCollision();
        }
    }

    public void Grow()
    {
        if (segments.Count < MaxSegments)
        {
            // Store the current coordinates of 'T'
            int currentTailX = this.GetTailX();
            int currentTailY = this.GetTailY();

            // Insert "0" behind the head
            segments.Insert(1, "0");

            // Update the tail coordinates to move it backward
            tailX -= (tailX - headX);
            tailY -= (tailY - headY);

            // Update the planet: Clear the old 'T' position and set the new 'T'
            planet[currentTailX, currentTailY] = '0';
            planet[tailX, tailY] = 'T';
        }
    }


public void Shrink()
    {
        if (segments.Count > 2)
        {
            segments.RemoveAt(segments.Count - 1);
        }
    }

    public List<string> GetSegments()
    {
        return segments;
    }

    public int GetHeadX()
    {
        return headX;
    }

    public int GetHeadY()
    {
        return headY;
    }

    public int GetTailX()
    {
        return tailX;
    }

    public int GetTailY()
    {
        return tailY;
    }

    private void CheckCollision()
    {
        char currentCell = planet[headX, headY];

        if (currentCell == '$')
        {

            planet[headX, headY] = '*';
        }
        else if (currentCell == 'B')
        {
          
            planet[headX, headY] = '*';
        }
        else if (currentCell == '#')
        {
            Disintegrate();
        }
    }

    private void Disintegrate()
    {
        segments.Clear();
        segments.Add("H");
        segments.Add("T");
        headX = planet.GetLength(0) / 2;
        headY = planet.GetLength(1) - 1;
        tailX = headX;
        tailY = headY - 1;
    }
}


