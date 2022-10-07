using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnDucks : MonoBehaviour
{
    public Transform duckParent;
    public List<GameObject> duckPrefabs;
    Vector3 spawnPos;
    public int duckNumPerType;

    void Start()
    {
        foreach (GameObject duckType in duckPrefabs)
        {
            SpawnDuckObjects(duckType);
        }
    }

    public void SpawnDuckObjects(GameObject duckType)
    {
        for (int i = 0; i < duckNumPerType; i++)
        {
            spawnPos = GenerateRandomWayPoint();
            GameObject newDuck = Instantiate(duckType, spawnPos, Quaternion.Euler(new Vector3(-90, Random.Range(0, 360), 0)));
            newDuck.transform.parent = duckParent;
        }
    }

    public Vector3 GenerateRandomWayPoint()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int maxIndices = navMeshData.indices.Length - 3;

        // pick the first indice of a random triangle in the nav mesh
        int firstVertexSelected = UnityEngine.Random.Range(0, maxIndices);
        int secondVertexSelected = UnityEngine.Random.Range(0, maxIndices);

        // spawn on verticies
        Vector3 point = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];

        Vector3 firstVertexPosition = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];
        Vector3 secondVertexPosition = navMeshData.vertices[navMeshData.indices[secondVertexSelected]];

        // eliminate points that share a similar X or Z position to stop spawining in square grid line formations
        if ((int)firstVertexPosition.x == (int)secondVertexPosition.x || (int)firstVertexPosition.z == (int)secondVertexPosition.z)
        {
            point = GenerateRandomWayPoint(); // re-roll a position - I'm not happy with this recursion it could be better
        }
        else
        {
            // select a random point on it
            point = Vector3.Lerp(firstVertexPosition, secondVertexPosition, UnityEngine.Random.Range(0.05f, 0.95f));
        }

        return point;
    }
}
