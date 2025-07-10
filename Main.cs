Canvas.Write(0, 0, "Welcome to the snake game!");
while (true)
{
    Canvas.Write(0, 1, "Press [ENTER] to start...");
    ConsoleKeyInfo pressedKey;
    do
    {
        pressedKey = Console.ReadKey();
    } while (pressedKey.Key != ConsoleKey.Enter);

    Canvas.Clear();

    int finalScore = RunGame();

    Canvas.Write(0, 0, $"GAME OVER! Score: {finalScore}");
}

// Run the game and return the score when the game is over.
int RunGame()
{
    Snake playerSnake = new();
    GameObject currentFood = SpawnFood();

    while (true)
    {
        while (Console.KeyAvailable)
        {
            Direction newDirection = Console.ReadKey().Key switch
            {
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.RightArrow => Direction.Right,
                ConsoleKey.DownArrow => Direction.Down,
                _ => playerSnake.Direction
            };
            if (newDirection != playerSnake.Direction)
            {
                playerSnake.Direction = newDirection;
                break;
            }
        }

        (int headX, int headY) = playerSnake.GetFrontPos();
        bool hasCollided = playerSnake.BodyParts.Any(segment => segment.X == headX && segment.Y == headY)
                           || headX < 0 || headY < 0 || headX >= Canvas.Width || headY >= Canvas.Height;

        if (hasCollided)
        {
            currentFood.Dispose();
            playerSnake.Dispose();
            return playerSnake.BodyParts.Count - 3;
        }
        else if (headX == currentFood.X && headY == currentFood.Y)
        {
            playerSnake.Eat(currentFood);
            currentFood = SpawnFood();
        }
        else
        {
            playerSnake.Move();
        }

        Thread.Sleep(150);
    }

    // Local function to spawn food at random location.
    GameObject SpawnFood()
    {
        int foodX, foodY;
        do
        {
            foodX = Random.Shared.Next(0, Canvas.Width);
            foodY = Random.Shared.Next(0, Canvas.Height);
        }
        while (playerSnake.BodyParts.Any(segment => foodX == segment.X && foodY == segment.Y));

        return new GameObject(foodX, foodY);
    }
}
