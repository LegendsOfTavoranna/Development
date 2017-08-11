using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshData
{

	public List<Vector3> vertices;
	public List<int> triangles;

	public Vector3[] normals;

	public MeshData ()
	{

		this.vertices = new List<Vector3>();
		this.triangles = new List<int>();
	}

	public MeshData (MeshData meshData)
	{

		this.vertices = meshData.vertices;
		this.triangles = meshData.triangles;
	}

	public MeshData (List<Vector3> vertices, List<int> triangles)
	{

		this.vertices = vertices;
		this.triangles = triangles;
	}

	public void AddQuad (Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
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

	public static MeshData CombineMeshData (MeshData meshData1, MeshData meshData2)
	{

		return meshData1.AddMeshData(meshData2);
	}
}

public static class MeshDataExtensions
{

	public static MeshData AddMeshData (this MeshData meshData, MeshData meshData1)
	{

		meshData.vertices.AddRange(meshData1.vertices);
		meshData.triangles.AddRange(meshData1.triangles);

		return meshData;
	}

	public static Vector3[] CalculateNormals (this MeshData meshData)
	{

		return CalculateMeshData.CalculateNormals(ref meshData.vertices, ref meshData.triangles);
	}
}