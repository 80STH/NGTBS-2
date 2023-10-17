


using System;

public struct GridPosition : IEquatable<GridPosition>
{
    public int x;
    public int z;

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               x == position.x &&
               z == position.z;
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public override string ToString()
    {
        return $"x: {x}; z: {z}";
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

    public static GridPosition operator +(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x + b.x, a.z + b.z);
    }

    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x - b.x, a.z - b.z);
    }

    public static GridPosition TileMove(GridPosition gridPosition, string direction)
    {
        if (gridPosition.z % 2 == 0)
        {
            switch (direction)
            {
                case "LeftDown":
                    gridPosition.z -= 1;
                    gridPosition.x -= 1;
                    break;
                case "Left":
                    gridPosition.x -= 1;
                    break;
                case "LeftUp":
                    gridPosition.x += 1;
                    gridPosition.z -= 1;
                    break;
                case "RightUp":
                    gridPosition.x -= 1;
                    gridPosition.z += 1;
                    break;
                case "Right":
                    gridPosition.x += 1;
                    break;
                case "RightDown":
                    gridPosition.x += 1;
                    gridPosition.z += 1;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (direction)
            {
                case "LeftDown":
                    gridPosition.z -= 1;
                    break;
                case "Left":
                    gridPosition.x -= 1;
                    break;
                case "LeftUp":
                    gridPosition.z += 1;
                    break;
                case "RightUp":
                    gridPosition.z += 1;
                    gridPosition.x += 1;
                    break;
                case "Right":
                    gridPosition.x += 1;
                    break;
                case "RightDown":
                    gridPosition.z -= 1;
                    break;
                default:
                    break;
            }
        }
        return gridPosition;
    }
}
