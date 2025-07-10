/// <summary>
/// A canvas based on console.
/// </summary>
static class Canvas
{
    static Canvas()
    {
        Console.Title = "Snake";
        Console.CursorVisible = false;
    }

    /// <summary>
    /// Canvas width.
    /// </summary>
    public static int Width => Console.WindowWidth / 2;

    /// <summary>
    /// Canvas height.
    /// </summary>
    public static int Height => Console.WindowHeight;

    /// <summary>
    /// Draw a pixel.
    /// </summary>
    /// <param name="x">Coord x of the pixel.</param>
    /// <param name="y">Coord y of the pixel.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void Draw(int x, int y)
    {
        if (x < 0 || x > Width || y < 0 || y > Height)
        {
            throw new ArgumentOutOfRangeException();
        }
        Console.SetCursorPosition(x * 2, y);
        Console.Write("██");
    }

    /// <summary>
    /// Erase a pixel.
    /// </summary>
    /// <param name="x">Coord x of the pixel.</param>
    /// <param name="y">Coord y of the pixel.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void Erase(int x, int y)
    {
        if (x < 0 || x > Width || y < 0 || y > Height)
        {
            throw new ArgumentOutOfRangeException();
        }
        Console.SetCursorPosition(x * 2, y);
        Console.Write("  ");
    }

    /// <summary>
    /// Write text.
    /// </summary>
    /// <param name="x">Coord x of the first char of the string.</param>
    /// <param name="y">Corrd y of the first char of the string.</param>
    /// <param name="text">The string to write.</param>
    public static void Write(int x, int y, string text)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }

    /// <summary>
    /// Clear the canvas.
    /// </summary>
    public static void Clear()
    {
        Console.Clear();
    }
}