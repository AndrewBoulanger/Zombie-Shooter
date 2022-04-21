using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public int numToSpawn;

    [SerializeField] GameObject[] slimeToSpawn;

    public SpawnerVolume[] volumes;

    GameObject followObject;

    void Awake()
    {
        followObject = GameObject.FindGameObjectWithTag("Player");
    }

    public SlimeComponent Spawn()
    {
        GameObject randomSlime = slimeToSpawn[Random.Range(0, slimeToSpawn.Length)];
        SpawnerVolume spawnerVolume = volumes[Random.Range(0, volumes.Length)];
        if(!followObject) return null;

        GameObject newSlime = Instantiate(randomSlime, spawnerVolume.GetPositionInBox(), spawnerVolume.transform.rotation );
        SlimeComponent result = newSlime.GetComponent<SlimeComponent>();
        result.Initialize(followObject);
        return result;
    }

    public SlimeComponent Spawn( Vector3 loc, Quaternion rot)
    {
        GameObject randomSlime = slimeToSpawn[Random.Range(0, slimeToSpawn.Length)];
        if (!followObject) return null;

        GameObject newSlime = Instantiate(randomSlime, loc, rot);
        SlimeComponent result = newSlime.GetComponent<SlimeComponent>();
        result.Initialize(followObject);
        return result;
    }
}
