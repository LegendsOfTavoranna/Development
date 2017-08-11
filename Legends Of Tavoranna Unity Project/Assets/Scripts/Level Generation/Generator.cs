using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

	public Material material;

	public int tileSizeInQuads;

	private void Start ()
	{

		Initialize();
	}

	public void Initialize()
	{

		Generate();
	}

	private void Generate()
	{
		
		GameObject.FindObjectOfType<Map>().Initialize();
	}
}

/*
public class Generator : MonoBehaviour
{

	public Material material;
	public MapDependencies[] map;

	private List<Vector3> vertices;
	private List<int> triangles;

	private void Start ()
	{

		Initialize();
	}

	public void Initialize ()
	{

		vertices = new List<Vector3>();
		triangles = new List<int>();

		Generate();

		Mesh mesh = new Mesh();
		GameObject obj = new GameObject();
		obj.name = "Chunk Object";
		var filter = obj.AddComponent<MeshFilter>();
		obj.AddComponent<MeshRenderer>().material = this.material;

		filter.mesh = mesh;
		mesh.SetVertices(vertices);
		mesh.SetTriangles(triangles, 0);

		mesh.RecalculateNormals();
	}

	private void Generate ()
	{

		int i = 0, height = 0;

		foreach (MapDependencies mapObj in map)
		{
			
			GeneratePlayArea(i * 4, height, mapObj.playAreaType);

			switch (mapObj.sideTerrainType)
			{

				case SideTerrainType.Normal:
					{
						GenerateSideNormal(i * 4, height, mapObj.playAreaType);
						break;
					}
				case SideTerrainType.Cliff:
					{
						GenerateSideCliff(i * 4, height, mapObj.playAreaType);
						break;
					}
				case SideTerrainType.SmoothSlope:
					{
						GenerateSideSmoothSlope(i * 4, height, mapObj.playAreaType);
						break;
					}
				case SideTerrainType.RoughSlope:
					{
						GenerateSideRoughSlope(i * 4, height, mapObj.playAreaType);
						break;
					}
			}

			switch (mapObj.playAreaType)
			{

				case PlayAreaType.Cliff:
					break;
				case PlayAreaType.Straight:
					break;
				case PlayAreaType.SlopeDown:
					height -= 2;
					break;
				case PlayAreaType.SlopeUp:
					height += 2;
					break;
			}

			i++;
		}
	}

	private void GeneratePlayArea (int xPos, int height, PlayAreaType playAreaType)
	{

		if (playAreaType == PlayAreaType.Cliff)
		{

			return;
		}

		float v1v3Height = height;
		float v2v4Height = height;

		for (int z = -2; z < 2; z++)
		{
			for (int x = xPos - 2, i = 0; x < xPos + 2; x++, i++)
			{

				if (playAreaType != PlayAreaType.Straight)
				{

					int heightDistance = playAreaType == PlayAreaType.SlopeUp ? 2 : -2;

					v1v3Height = Mathf.Lerp(height, height + heightDistance, i / 4f);
					v2v4Height = Mathf.Lerp(height, height + heightDistance, (i + 1) / 4f);
				}

				Vector3 v1 = new Vector3(x, v1v3Height, z);
				Vector3 v2 = new Vector3(x + 1, v2v4Height, z);
				Vector3 v3 = new Vector3(x, v1v3Height, z + 1);
				Vector3 v4 = new Vector3(x + 1, v2v4Height, z + 1);

				AddQuad(v1, v2, v3, v4);
			}
		}
	}

	private void GenerateSideNormal (int xPos, int height, PlayAreaType playAreaType)
	{


	}

	private void GenerateSideCliff (int xPos, int height, PlayAreaType playAreaType)
	{


	}

	private void GenerateSideSmoothSlope (int xPos, int height, PlayAreaType playAreaType)
	{


	}

	private void GenerateSideRoughSlope (int xPos, int height, PlayAreaType playAreaType)
	{


	}

	private void AddQuad (Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
	{

		int index = vertices.Count;

		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		vertices.Add(v4);

		triangles.Add(index);
		triangles.Add(index + 2);
		triangles.Add(index + 1);
		triangles.Add(index + 1);
		triangles.Add(index + 2);
		triangles.Add(index + 3);
	}
}
*/