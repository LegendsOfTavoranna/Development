using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFace
{

	public MeshData meshData;
	public TileFaceType tileFaceType;

	int verticesPerFace;

	public TileFace (int verticesPerFace)
	{

		meshData = new MeshData();

		this.verticesPerFace = verticesPerFace;
	}


}

public static class TileFaceExtensions
{


}

public enum TileFaceType
{
	Front,
	Back,
	Left,
	Right,
	Up,
	Down
}