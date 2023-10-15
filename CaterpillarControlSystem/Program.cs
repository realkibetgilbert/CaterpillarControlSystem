


public class Program
{
    static void Main()
    {
        int planetWidth = 30;
        int planetHeight = 30;
        char[,] planet = new char[planetWidth, planetHeight];
        InitializePlanet(planet);

        Caterpillar caterpillar = new Caterpillar(planet);


        while (true)
        {
            Console.Clear();

            DisplayPlanet(planet, caterpillar);

            Console.WriteLine("Enter a command (e.g., 'U 4' to move up 4 times or 'Q' to quit):");

            string input = Console.ReadLine().ToUpper();

            string[] parts = input.Split(' ');

            if (parts.Length == 2 && int.TryParse(parts[1], out int steps))
            {
                for (int i = 0; i < steps; i++)
                {
                    switch (parts[0])
                    {
                        case "U":
                            caterpillar.MoveUp();
                            break;
                        case "D":
                            caterpillar.MoveDown();
                            break;
                        case "L":
                            caterpillar.MoveLeft();
                            break;
                        case "R":
                            caterpillar.MoveRight();
                            break;
                        case "G":
                            caterpillar.Grow();
                            break;
                        case "S":
                            caterpillar.Shrink();
                            break;
                        case "Q":
                            return;
                        default:
                            Console.WriteLine("Invalid command. Please enter U, D, L, R, G, S, or Q.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid command format: " + input);
            }
        }
    }


    public static void InitializePlanet(char[,] planet)
    {
        int planetWidth = planet.GetLength(0);
        int planetHeight = planet.GetLength(1);
        Random random = new Random();

        // Fill the planet with '*' initially 
        for (int x = 0; x < planetWidth; x++)
        {
            for (int y = 0; y < planetHeight; y++)
            {
                planet[x, y] = '*';
            }
        }
        // fill planet with obstacles
        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(planetWidth);
            int y = random.Next(planetHeight);
            planet[x, y] = '#';
        }
        //fill planet with spices

        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(planetWidth);
            int y = random.Next(planetHeight);
            planet[x, y] = '$';
        }
        // fill planet with boosters

        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(planetWidth);
            int y = random.Next(planetHeight);
            planet[x, y] = 'B';
        }
    }


    static void DisplayPlanet(char[,] planet, Caterpillar caterpillar)
    {
        for (int y = 0; y < planet.GetLength(1); y++)
        {
            for (int x = 0; x < planet.GetLength(0); x++)
            {
                if (x == caterpillar.GetHeadX() && y == caterpillar.GetHeadY())
                {
                    Console.Write(caterpillar.GetSegments()[0][0]);
                }
                else if (x == caterpillar.GetTailX() && y == caterpillar.GetTailY())
                {
                    Console.Write(caterpillar.GetSegments()[1][0]);
                }
                else
                {
                    Console.Write(planet[x, y]);
                }
            }
            Console.WriteLine();
        }
    }



}
