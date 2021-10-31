using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    SpawnerRoads spawnerRoads;
    // Start is called before the first frame update
    void Start()
    {
        spawnerRoads = GetComponent<SpawnerRoads>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTriggerEntered()
    {
        spawnerRoads.MoveRoad();
    }
}
