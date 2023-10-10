class Caterpillar
{
    private List<string> segments;
    private int headX;
    private int headY;
    private const int MaxSegments = 5;

    public Caterpillar()
    {
        segments = new List<string> { "H", "T" };
        headX = 0;
        headY = 0; 
    }

    
    public void MoveUp()
    {
        
        headY--;
    }

    
    public void MoveDown()
    {
      
        headY++;
    }

    
    public void MoveLeft()
    {
        
        headX--;
    }

    
    public void MoveRight()
    {
       
        headX++;
    }

    
    public int GetHeadX()
    {
        return headX;
    }

    
    public int GetHeadY()
    {
        return headY;
    }

    
    public void Grow()
    {
        if (segments.Count < MaxSegments)
        {
            segments.Insert(1, "0"); 
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
}
