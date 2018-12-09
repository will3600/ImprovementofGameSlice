using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    // Creates array that you can place prefabs into. Array is in the TileManager object in the hierarchy
    public GameObject[] tilePrefabs;

    // spawn the prefabs in relation to the players position
    private Transform playerTransform;

    // Where in z do we want to place the object
    private float spawnZ = 0.0f;

    // The length of each prefab made
    private float tileLength = 10.0f;

    // Prevents the prefabs being deleted for the specified length
    private float safeZone = 10.0f;

    // The amount of prefabs at any given time on screen
    private int amnTilesOnScreen = 10;

    // Keeps track of the last prefab used
    private int lastPrefabIndex = 0;

    // Field for the list of relevant prefabs
    private List<GameObject> activeTiles;

	// Use this for initialization
	private void Start ()
    {
        // Keeps track of what prefabs are relevant or not
        activeTiles = new List<GameObject>();
        // Finds the player character with the player tag on them
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Spawns the first prefab in the array until i = 2
        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();  
        }
    }
	
	// Update is called once per frame
	private void Update ()
    {
        // Spawns and Deletes the prefabss after specified safe zone
		if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    // Function for spawning prefabs
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            // References any one of the prefabs in the TileManager array
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            // Makes it so that the first prefabs are the ones with no obstacles on them
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;  
       
        // Gives the prefabs the position to spawn at and makes it a child of the TileManager object
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    // Function for deleting prefabs
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    // Randomises the prefabs and prevents using the same one over and over
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
