using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnTrees : MonoBehaviour
{
    public List<GameObject> treePrefabs;
    public int treeNum;
    Vector3 spawnPos;

    void Start()
    {
        for (int i = 0; i < treeNum; i++)
        {
            spawnPos = GenerateRandomWayPoint();
            GameObject newTree = Instantiate(treePrefabs[Random.Range(0, treePrefabs.Count)], spawnPos, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newTree.transform.parent = transform;
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
