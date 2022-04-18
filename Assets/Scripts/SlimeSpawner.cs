using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public int numToSpawn;

    [SerializeField] GameObject[] slimeToSpawn;

    public SpawnerVolume[] volumes;

    GameObject followObject;

    // Start is called before the first frame update
    void Start()
    {
        followObject = GameObject.FindGameObjectWithTag("Player");
        for(int i = 0; i < numToSpawn; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject randomSlime = slimeToSpawn[Random.Range(0, slimeToSpawn.Length)];
        SpawnerVolume spawnerVolume = volumes[Random.Range(0, volumes.Length)];
        if(!followObject) return;

        GameObject newSlime = Instantiate(randomSlime, spawnerVolume.GetPositionInBox(), spawnerVolume.transform.rotation );

        newSlime.GetComponent<SlimeComponent>().Initialize(followObject);
    }
}
