using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject treasurePrefab;

    public List<Transform> spawnPoints;
    [SerializeField] private int treasuresSpawned = 3;

    void Start()
    {
        SpawnTreasure();
    }

    void SpawnTreasure()
    {

        for (int i = 0; i < treasuresSpawned; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Instantiate(treasurePrefab, spawnPoints[randomIndex].position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            spawnPoints.RemoveAt(randomIndex);
        }
    }
}
