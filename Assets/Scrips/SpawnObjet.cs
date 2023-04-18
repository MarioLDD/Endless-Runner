using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjet : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 15f;
    private int numberOfTiles = 7;
    private bool start;
    public static float velocity = 4f;
    public float aceleration;

    //public int indexTile;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
        for(int i = 0; i < numberOfTiles; i++)
        {
            if(i==0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
            if(i==numberOfTiles-1)
            {
                start=false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTile (int tileIndex)
    {
        if(start)
        {
            Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, Quaternion.identity);
            zSpawn += tileLength;
        }
        else
        {
            Instantiate(tilePrefabs[tileIndex], transform.forward * tileLength *5, Quaternion.identity);
        }
    }
    public void RandomSpawnTile()
    {
        SpawnTile(Random.Range(0, tilePrefabs.Length));
    }
    public void Aceleration()
    {
        velocity = velocity + aceleration;
    }
}
