
using CaterpillarControlSystem;
using Serilog;

public class Caterpillar
{
    private List<string> segments;
    private int headX;
    private int headY;
    private int tailX;
    private int tailY;
    private const int MaxSegments = 5;
    private char[,] planet;
    private Stack<ICommand> commandHistory = new Stack<ICommand>();
    private Stack<ICommand> redoHistory = new Stack<ICommand>();
    private Dictionary<ICommand, int> commandExecutionCount = new Dictionary<ICommand, int>();

    public Caterpillar(char[,] planet)
    {
        segments = new List<string> { "H", "T" };
        headX = planet.GetLength(0) / 2;
        headY = planet.GetLength(1) - 1;
        tailX = headX;
        tailY = headY - 1;
        this.planet = planet;

    }
    public void MoveUp(int steps)
    {
        if (headY > 0)
        {
            for (int i = 0; i < steps; i++)
            {
                ICommand command = new MoveUpCommand(this);
                command.Execute();
                commandHistory.Push(command);
                Log.Information("Command: MoveUp executed.");
                UpdateCommandExecutionCount(command, steps);
            }
        }
    }
    public void MovingUp()
    {
        tailX = headX;
        tailY = headY;
        headY--;
        CheckCollision();
    }
    public void MoveDown(int steps)
    {
        if (headY < planet.GetLength(1) - 1)
        {
            for (int i = 0; i < steps; i++)
            {
                ICommand command = new MovingDownCommand(this);
                command.Execute();
                commandHistory.Push(command);
                Log.Information("Command: MoveDown executed.");
                UpdateCommandExecutionCount(command, steps);
            }
        }
    }
    public void MovingDown()
    {
        tailX = headX;
        tailY = headY;
        headY++;
        CheckCollision();
    }
    public void MoveLeft(int steps)
    {
        if (headX > 0)
        {
            for (int i = 0; i < steps; i++)
            {
                ICommand command = new MovingLeftCommand(this);
                command.Execute();
                commandHistory.Push(command);
                Log.Information("Command: Moveleft executed.");
                UpdateCommandExecutionCount(command, steps);
            }
        }
    }
    public void MovingLeft()
    {
        tailX = headX;
        tailY = headY;
        headX--;
        CheckCollision();
    }
    public void MoveRight(int steps)
    {
        if (headX < planet.GetLength(0) - 1)
        {
            for (int i = 0; i < steps; i++)
            {
                ICommand command = new MovingRightCommand(this);
                command.Execute();
                commandHistory.Push(command);
                Log.Information("Command: MoveRight executed.");
                UpdateCommandExecutionCount(command, steps);
            }
        }
    }
    public void MovingRight()
    {
        tailX = headX;
        tailY = headY;
        headX++;
        CheckCollision();
    }
    private void UpdateCommandExecutionCount(ICommand command, int count)
    {
        if (commandExecutionCount.ContainsKey(command))
        {
            commandExecutionCount[command] += count;
        }
        else
        {
            commandExecutionCount.Add(command, count);
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
    public void CheckCollision()
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
    public void Disintegrate()
    {
        segments.Clear();
        segments.Add("H");
        segments.Add("T");
        headX = planet.GetLength(0) / 2;
        headY = planet.GetLength(1) - 1;
        tailX = headX;
        tailY = headY - 1;
    }
    public void Undo()
    {
        if (commandHistory.Count > 0)
        {
            ICommand command = commandHistory.Pop();
            Log.Information("Undo: Command {CommandName} undone.", command.GetType().Name);
            int executionCount = commandExecutionCount.ContainsKey(command) ? commandExecutionCount[command] : 1;
            for (int i = 0; i < executionCount; i++)
            {
                command.Undo();
            }

            redoHistory.Push(command);
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
    public void Redo()
    {
        if (redoHistory.Count > 0)
        {
            ICommand command = redoHistory.Pop();
            Log.Information("Redo: Command {CommandName} redone.", command.GetType().Name);

            // Redo the command for the number of times it was executed
            int executionCount = commandExecutionCount.ContainsKey(command) ? commandExecutionCount[command] : 1;
            for (int i = 0; i < executionCount; i++)
            {
                command.Execute();
            }

            // Move the command back to the command history
            commandHistory.Push(command);
        }
        else
        {
            Console.WriteLine("Nothing to redo.");
        }
    }

}


