using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeManager : MonoBehaviour {
	public GameObject[] bridgePrefabs;
	private Transform playerTransform;
	
	private float spawnZ = 0.0f;
	private float spawnX = 0.0f;
	private float bridgeHeight = 0.0f;

	private float spawnZp = 16.0f;
	private float spawnXp = 16.0f;
	private float bridgeHeightp = -4.5f;
	
	private float spawnZb = 11.0f;
	private float spawnXb = 0f;
	private float bridgeHeightb = 2.4f;

	private float bridgeLength = 18.0f;
	private int totalTilesOnScreen =  5;  
	private float safeZone = 25.0f;
	private List<GameObject> activeBridges;
	private int lastPrefabIndex = 0;

	// Use this for initialization
	void Start () {
		activeBridges = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		for(int i=0; i < totalTilesOnScreen ; i++){
			if(i <2)
				SpawnBridge(4);
			else
				SpawnBridge();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z - safeZone > (spawnZ - totalTilesOnScreen * bridgeLength)){
			SpawnBridge();
			DeleteBridge();
		}
	}
	void SpawnBridge(int prefabIndex = -1){
		GameObject bridge;
		int index;
		if(prefabIndex == -1)
			index = RandomPrefabIndex();
		else
			index = prefabIndex;
		bridge = Instantiate(bridgePrefabs[index]) as GameObject;
		bridge.transform.SetParent(transform);
		if(index < 4){
			spawnX =  spawnXp;
			bridgeHeight = bridgeHeightp;
			spawnZ = spawnZp;
		}
		else{
			spawnX =  spawnXb;
			bridgeHeight = bridgeHeightb;
			spawnZ = spawnZb;
		}
		bridge.transform.position = Vector3.right * spawnX;
		bridge.transform.position += Vector3.forward  * spawnZ;
		bridge.transform.position += Vector3.up * bridgeHeight;
		spawnZ += bridgeLength; 
		spawnZb = spawnZ - 2.0f;
		spawnZp = spawnZ + 3.0f; 
		activeBridges.Add (bridge);
	}
	void DeleteBridge(){
		Destroy(activeBridges[0]);
		activeBridges.RemoveAt(0);
	}	
	private int RandomPrefabIndex(){
		if(bridgePrefabs.Length <=1 )
			return 0;
		int randomIndex = lastPrefabIndex;
		while(randomIndex == lastPrefabIndex){
			randomIndex = Random.Range(0, bridgePrefabs.Length);
		}	
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
