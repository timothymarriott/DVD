

public class Vector2
{

    public float x { get; set; }
    public float y { get; set; }

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float Magnitude()
    {
        return (float)Math.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude > 0)
        {
            x /= magnitude;
            y /= magnitude;
        }
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }

    public static Vector2 operator *(Vector2 a, float scalar)
    {
        return new Vector2(a.x * scalar, a.y * scalar);
    }

    public static Vector2 operator *(Vector2 a, Vector2 scalar)
    {
        return new Vector2(a.x * scalar.x, a.y * scalar.y);
    }

    public static Vector2 operator /(Vector2 a, float scalar)
    {
        if (scalar != 0)
        {
            return new Vector2(a.x / scalar, a.y / scalar);
        }
        throw new DivideByZeroException("Division by zero is not allowed.");
    }

    public static implicit operator System.Numerics.Vector2(Vector2 customVector)
    {
        return new System.Numerics.Vector2(customVector.x, customVector.y);
    }

    public static implicit operator Vector2(System.Numerics.Vector2 customVector)
    {
        return new Vector2(customVector.X, customVector.Y);
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }

}


public class Vector2I
{

    public int x { get; set; }
    public int y { get; set; }

    public Vector2I(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public float Magnitude()
    {
        return (float)Math.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float magnitude = Magnitude();
        if (magnitude > 0)
        {
            x = (int)MathF.Round(x / magnitude);
            y = (int)MathF.Round(y / magnitude);
        }
    }

    public static Vector2I operator +(Vector2I a, Vector2I b)
    {
        return new Vector2I(a.x + b.x, a.y + b.y);
    }

    public static Vector2I operator -(Vector2I a, Vector2I b)
    {
        return new Vector2I(a.x - b.x, a.y - b.y);
    }

    public static Vector2I operator *(Vector2I a, float scalar)
    {
        return new Vector2I((int)MathF.Round(a.x * scalar), (int)MathF.Round(a.y * scalar));
    }

    public static Vector2I operator *(Vector2I a, Vector2I scalar)
    {
        return new Vector2I(a.x * scalar.x, a.y * scalar.y);
    }

    public static Vector2I operator /(Vector2I a, float scalar)
    {
        if (scalar != 0)
        {
            return new Vector2I((int)MathF.Round(a.x / scalar), (int)MathF.Round(a.y / scalar));
        }
        throw new DivideByZeroException("Division by zero is not allowed.");
    }

    public static implicit operator System.Numerics.Vector2(Vector2I customVector)
    {
        return new System.Numerics.Vector2(customVector.x, customVector.y);
    }

    public static implicit operator Vector2I(System.Numerics.Vector2 customVector)
    {
        return new Vector2I((int)MathF.Round(customVector.X), (int)MathF.Round(customVector.Y));
    }
    public static implicit operator Vector2I(Vector2 customVector)
    {
        return new Vector2I((int)MathF.Round(customVector.x), (int)MathF.Round(customVector.y));
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }

}
