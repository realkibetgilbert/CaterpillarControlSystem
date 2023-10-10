class Program
{
    static void Main()
    {
        Caterpillar caterpillar = new Caterpillar();

        while (true)
        {
            Console.Clear(); 

            DisplayPlanet(caterpillar); 

            
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


    static void DisplayPlanet(Caterpillar caterpillar)
    {
        int planetWidth = 30;
        int planetHeight = 30;

        char[,] planet = new char[planetHeight, planetWidth];

        for (int y = 0; y < planetHeight; y++)
        {
            for (int x = 0; x < planetWidth; x++)
            {
                planet[x, y] = '*';
            }
        }

      
        planet[0, 11] = '$';
        planet[0, 29] = '$';
        planet[1, 3] = '$';
        planet[1, 12] = '$';
        planet[2, 8] = '$';
        planet[4, 5] = '$';
        planet[6, 6] = '$';
        planet[8, 0] = '$';
        planet[9, 6] = '$';
        planet[9, 20] = '$';
        planet[10, 7] = '$';
        planet[11, 22] = '$';
        planet[14, 8] = '$';
        planet[15, 0] = '$';
        planet[16, 13] = '$';
        planet[18, 4] = '$';
        planet[19, 6] = '$';
        planet[19, 11] = '$';
        planet[19, 24] = '$';
        planet[20, 9] = '$';
        planet[21, 1] = '$';
        planet[21, 25] = '$';
        planet[22, 16] = '$';
        planet[24, 7] = '$';
        planet[25, 13] = '$';
        planet[26, 21] = '$';
        planet[27, 14] = '$';
        planet[28, 2] = '$';
        planet[28, 22] = '$';

        planet[8, 12] = 'B';
        planet[10, 16] = 'B';
        planet[15, 0] = 'B';
        planet[19, 6] = 'B';
        planet[19, 11] = 'B';
        planet[19, 24] = 'B';
        planet[21, 1] = 'B';
        planet[21, 25] = 'B';
        planet[22, 16] = 'B';
        planet[28, 2] = 'B';
        planet[28, 22] = 'B';

        planet[0, 0] = 'S'; 

        
        int headX = caterpillar.GetHeadX();
        int headY = caterpillar.GetHeadY();

        foreach (var segment in caterpillar.GetSegments())
        {
            if (headX >= 0 && headX < planetWidth && headY >= 0 && headY < planetHeight)
            {
                planet[headY, headX] = segment[0];
                headX++; 
            }
            else
            {
               
                break;
            }
        }


        
        Console.WriteLine("Planet:");

        for (int y = 0; y < planetHeight; y++)
        {
            for (int x = 0; x < planetWidth; x++)
            {
                Console.Write(planet[x, y]);
            }
            Console.WriteLine();
        }
    }

}
