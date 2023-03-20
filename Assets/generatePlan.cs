using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlan : MonoBehaviour
{
    private int terrainDimension;
    private int terrainResolution;

    private Mesh mesh;

    void Start()
    {
        terrainDimension = GameManager.Instance.getDimension();
        terrainResolution = GameManager.Instance.getResolution();
        // Calcul du nombre de vertices et de triangles
        int verticesPerSide = terrainResolution + 1;
        int numVertices = verticesPerSide * verticesPerSide;
        int numTriangles = 2 * (terrainResolution * terrainResolution);

        // Création du maillage
        mesh = new Mesh();
        mesh.name = "TerrainMesh";
        mesh.Clear();

        // Génération des vertices
        Vector3[] vertices = new Vector3[numVertices];
        float spacing = (float)terrainDimension / terrainResolution;

        for (int i = 0; i < verticesPerSide; i++)
        {
            for (int j = 0; j < verticesPerSide; j++)
            {
                vertices[i * verticesPerSide + j] = new Vector3(i * spacing, 0, j * spacing);
            }
        }

        // Assignation des vertices au maillage
        mesh.vertices = vertices;

        // Génération des triangles
        int[] triangles = new int[numTriangles * 3];
        int triangleIndex = 0;

        for (int i = 0; i < terrainResolution; i++)
        {
            for (int j = 0; j < terrainResolution; j++)
            {
                int topLeftVertex = i * verticesPerSide + j;
                int topRightVertex = i * verticesPerSide + j + 1;
                int bottomLeftVertex = (i + 1) * verticesPerSide + j;
                int bottomRightVertex = (i + 1) * verticesPerSide + j + 1;

                triangles[triangleIndex++] = topLeftVertex; // 0
                triangles[triangleIndex++] = topRightVertex; // 1
                triangles[triangleIndex++] = bottomLeftVertex; // 2

                triangles[triangleIndex++] = topRightVertex; // 3
                triangles[triangleIndex++] = bottomRightVertex; // 4
                triangles[triangleIndex++] = bottomLeftVertex; // 5
            }
        }

        // Assignation des triangles au maillage
        mesh.triangles = triangles;

        // Assignation du maillage au composant MeshFilter du GameObject
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
