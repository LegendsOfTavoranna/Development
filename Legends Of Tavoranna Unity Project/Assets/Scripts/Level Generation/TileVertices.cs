using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileVertices
{
	public Tile tile;

	public TileFace up;
	public TileFace right;
	public TileFace down;
	public TileFace left;

	public TileFace front; // will always be visible
	public TileFace back; // will always be visible

	private int bitMask;
	private int xPos, yPos;

	private Block block;

	public TileVertices(Tile tile)
	{
		
		this.tile = tile;
		this.bitMask = tile.bitMask;
		this.xPos = tile.xPos;
		this.yPos = tile.yPos;
		this.block = tile.block;
	}
}

public static class TileVerticesExtensions
{

	public static MeshData CreateMeshData (this TileVertices tileVertices)
	{

		MeshData meshData = new MeshData();

		meshData.AddMeshData(tileVertices.front.meshData);
		meshData.AddMeshData(tileVertices.back.meshData);

		meshData.AddMeshData(tileVertices.up.meshData);

		meshData.AddMeshData(tileVertices.right.meshData);

		meshData.AddMeshData(tileVertices.down.meshData);

		meshData.AddMeshData(tileVertices.left.meshData);

		return meshData;
	}
}