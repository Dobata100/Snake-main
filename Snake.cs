/// <summary>
/// A snake.
/// </summary>
class Snake : IDisposable
{
    private bool _disposed;
    private Direction _direction = Direction.Right;

    /// <summary>
    /// Initialize (draw) a snake in the canvas center.
    /// </summary>
    public Snake()
    {
        int x = Canvas.Width / 2;
        int y = Canvas.Height / 2;
        BodyParts = new();
        BodyParts.AddLast(new GameObject(x, y));
        BodyParts.AddLast(new GameObject(x - 1, y));
        BodyParts.AddLast(new GameObject(x - 2, y));
    }

    /// <summary>
    /// The body parts of the snake.
    /// </summary>
    public LinkedList<GameObject> BodyParts { get; }

    /// <summary>
    /// The moving direction of the snake.
    /// </summary>
    public Direction Direction
    {
        get => _direction;
        set
        {
            int t = (int)(value | _direction);
            if (t == 0b0101 || t == 0b1010)
            {
                return;
            }
            _direction = value;
        }
    }

    /// <summary>
    /// Get the front position of the snake.
    /// </summary>
    /// <returns>Tuple (x, y) which represents the front pos.</returns>
    /// <exception cref="InvalidOperationException">The snake has no body part.</exception>
    public (int x, int y) GetFrontPos()
    {
        GameObject head = BodyParts.First?.Value ?? throw new InvalidOperationException();
        int x = head.X, y = head.Y;
        switch (Direction)
        {
            case Direction.Left:
                x -= 1;
                break;
            case Direction.Up:
                y -= 1;
                break;
            case Direction.Right:
                x += 1;
                break;
            case Direction.Down:
                y += 1;
                break;
            default:
                break;
        }
        return (x, y);
    }

    /// <summary>
    /// Eat the given food (and add it to body parts).
    /// </summary>
    /// <param name="food">The food to eat.</param>
    public void Eat(GameObject food)
    {
        BodyParts.AddFirst(food);
    }

    /// <summary>
    /// Take a step towards current direction.
    /// </summary>
    public void Move()
    {
        BodyParts.Last?.Value.Dispose();
        BodyParts.RemoveLast();

        (int x, int y) = GetFrontPos();

        BodyParts.AddFirst(new GameObject(x, y));
    }

    /// <summary>
    /// Dispose (erase) the snake.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }
        if (disposing)
        {
            foreach (var pixel in BodyParts)
            {
                pixel.Dispose();
            }
        }
        _disposed = true;
    }
}