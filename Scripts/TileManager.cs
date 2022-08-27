using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0f;
    public float tileLength = 30f;

    public int numberOfTiles = 10;
    public Transform playerTransform;

    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTime(0);
            }
            else
            {
                SpawnTime(Random.Range(0, tilePrefabs.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTime(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }

    }
    public void SpawnTime(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
