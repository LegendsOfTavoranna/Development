using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	public Tile[] neighbors = new Tile[8];

	public TileVertices tileVertices;

	public int xPos, yPos;

	public int bitMask;

	public MeshData meshData;

	public Block block;

	public void Initialize ()
	{

		SetBitMaskValue();

		tileVertices = new TileVertices(this);
	}

	public void SetBitMaskValue ()
	{

		int value = 1;
		for (TileDirection direction = TileDirection.Up; direction <= TileDirection.UpperLeft; direction++)
		{

			if (neighbors[(int)direction] != null)
			{

				Tile neighbor = neighbors[(int)direction];

				if (block.name == neighbor.block.name)
				{

					bitMask += value;
				}
			}

			value *= 2;
		}
	}

	public Tile (int xPos, int yPos)
	{

		this.xPos = xPos;
		this.yPos = yPos;

		meshData = new MeshData();
	}

	public void SetNeighbor (TileDirection direction, Tile tile)
	{

		neighbors[(int)direction] = tile;
		tile.neighbors[(int)direction.Opposite()] = this;
	}
}