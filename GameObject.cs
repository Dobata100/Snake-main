/// <summary>
/// A snake game object, may be food or a snake part.
/// </summary>
class GameObject : IDisposable
{
    bool _disposed;

    /// <summary>
    /// The x pos of the object.
    /// </summary>
    public int X { get; private set; }

    /// <summary>
    /// The x pos of the object.
    /// </summary>
    public int Y { get; private set; }

    /// <summary>
    /// Initialize (draw) the object.
    /// </summary>
    /// <param name="x">The x pos of the object.</param>
    /// <param name="y">The y pos of the object.</param>
    public GameObject(int x, int y)
    {
        X = x;
        Y = y;
        Canvas.Draw(X, Y);
    }

    ~GameObject()
    {
        Dispose(false);
    }

    /// <summary>
    /// Dispose (erase) the game object.
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
            // Nothing to do
        }
        Canvas.Erase(X, Y);
        _disposed = true;
    }
}