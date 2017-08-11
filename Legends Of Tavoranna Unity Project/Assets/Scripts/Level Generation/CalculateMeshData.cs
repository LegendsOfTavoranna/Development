using UnityEngine;
using System.Collections.Generic;

public static class CalculateMeshData
{

	public static Vector3[] CalculateNormals(ref List<Vector3> vertices, ref List<int> triangles)
	{

		Vector3[] vertexNormals = new Vector3[vertices.Count];

		int triangleCount = triangles.Count / 3;

		for (int i = 0; i < triangleCount; i++)
		{

			int normalTriangleIndex = i * 3;
			int vertexIndexA = triangles[normalTriangleIndex];
			int vertexIndexB = triangles[normalTriangleIndex + 1];
			int vertexIndexC = triangles[normalTriangleIndex + 2];

			Vector3 triangleNormal = SurfaceNormalFromIndices (vertexIndexA, vertexIndexB, vertexIndexC, ref vertices);
			vertexNormals [vertexIndexA] += triangleNormal;
			vertexNormals [vertexIndexB] += triangleNormal;
			vertexNormals [vertexIndexC] += triangleNormal;
		}

		for (int i = 0; i < vertexNormals.Length; i++) {
			vertexNormals [i].Normalize ();
		}

		return vertexNormals;
	}

	private static Vector3 SurfaceNormalFromIndices(int indexA, int indexB, int indexC, ref List<Vector3> vertices) {
		Vector3 pointA = vertices [indexA];
		Vector3 pointB = vertices [indexB];
		Vector3 pointC = vertices [indexC];

		Vector3 sideAB = pointB - pointA;
		Vector3 sideAC = pointC - pointA;
		return Vector3.Cross (sideAB, sideAC).normalized;
	}
}