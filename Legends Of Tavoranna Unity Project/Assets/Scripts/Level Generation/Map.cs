using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public static Tile[,] tileLayers;

	public int xMapSize, yMapSize, layerCount;

	public void Initialize()
	{

		tileLayers = new Tile[xMapSize, yMapSize];

		for (int y = 0; y < yMapSize; y++)
		{
			for (int x = 0; x < xMapSize; x++)
			{

				GameObject obj = new GameObject(string.Format("Tile {0}, {1}", x, y));
				obj.transform.position = new Vector3(x, y);
				Tile tile = obj.AddComponent<Tile>();
				tile.xPos = x;
				tile.yPos = y;
				tileLayers[x, y] = tile;
				tile.neighbors = new Tile[8];
				tile.block = new Block("name");

				if (x > 0)
				{

					tile.SetNeighbor(TileDirection.Left, tileLayers[x - 1, y]);
				}

				if (y > 0)
				{

					tile.SetNeighbor(TileDirection.Down, tileLayers[x, y - 1]);

					if (x > 0)
					{

						tile.SetNeighbor(TileDirection.DownLeft, tileLayers[x - 1, y - 1]);
					}

					if (x < xMapSize - 1)
					{

						tile.SetNeighbor(TileDirection.DownRight, tileLayers[x + 1, y - 1]);
					}
				}
			}
		}

		for (int y = 0; y < yMapSize; y++)
		{
			for (int x = 0; x < xMapSize; x++)
			{

				tileLayers[x, y].Initialize();
			}
		}
	}
}