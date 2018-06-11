using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour 
{
	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZaxis = -10.0f;
	private float tileLength = 10.0f;
	private int maxTilesOnScreen = 20;
	private List<GameObject> activeTiles;
	private int lastPrefabIndex = 0;

	// Use this for initialization
	private void Start () 
	{
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		SpawnTile (0);
		SpawnTile (0);
		SpawnTile (0);
		SpawnTile (0);
		for (int i = 0; i < maxTilesOnScreen - 4; i ++)
		{
			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if(playerTransform.position.z - 60.0f > (spawnZaxis - maxTilesOnScreen * tileLength))
		{
			SpawnTile ();
			DeleteTile ();
		}
	}

	private void SpawnTile (int prefabIndex = -1)
	{
		GameObject go;
		if (prefabIndex != -1)
		{
			go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}
		else
		{
			go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
		}
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZaxis;
		spawnZaxis += tileLength;
		activeTiles.Add (go);
	}

	private void DeleteTile ()
	{
		Destroy (activeTiles[0]);
		activeTiles.RemoveAt(0);
	}

	private int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
		{
			return 0;
		}

		int randomIndex = Random.Range (0, tilePrefabs.Length);

		lastPrefabIndex = randomIndex;

		return randomIndex;
	}
}
