[System.Serializable]
public enum TileDirection
{

	Up, UpperRight, Right, DownRight, Down, DownLeft, Left, UpperLeft
}

public static class TileDirectionExtensions
{

	public static TileDirection Opposite (this TileDirection direction)
	{

		return (int)direction < 4 ? (direction + 4) : (direction - 4);
	}

	public static TileDirection Previous (this TileDirection direction)
	{

		return direction == TileDirection.Up ? TileDirection.UpperLeft : (direction - 1);
	}

	public static TileDirection Next (this TileDirection direction)
	{

		return direction == TileDirection.UpperLeft ? TileDirection.Up : (direction + 1);
	}
}