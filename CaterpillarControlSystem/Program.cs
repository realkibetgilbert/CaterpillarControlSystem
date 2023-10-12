


class Program
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

            Console.WriteLine("Enter a command (U/D/L/R/G/S/Q):");

            string input = Console.ReadLine().ToUpper();

            switch (input)
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

    static void InitializePlanet(char[,] planet)
    {
        for (int x = 0; x < planet.GetLength(0); x++)
        {
            for (int y = 0; y < planet.GetLength(1); y++)
            {
                planet[x, y] = '*';
            }
        }


        // adding obstacles to specific coordinates of the planet
        planet[5, 5] = '#';

        planet[10, 15] = '#';

        //adding spices to the specific cordinates of the planet
        planet[12, 20] = '$';
        planet[18, 8] = '$';

        //planet[6, 8] = 'B';
        planet[24, 18] = 'B';
        planet[6, 8] = 'B';
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
