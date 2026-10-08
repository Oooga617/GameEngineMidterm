using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerManager : Singleton<SpawnerManager>
{

    //contains list of enemy item spawners
    List<FruitSpawner> fSpawners;
    FruitSpawner droppedSpawner;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getSpawners()
    {
        fSpawners.Clear();
        FruitSpawner[] fruitSpawnerArray = GameObject.FindObjectsByType<FruitSpawner>(FindObjectsSortMode.None);
        fSpawners.AddRange(fruitSpawnerArray);
        activateSpawners();
    }

    void activateSpawners()
    {
        if (fSpawners.Count > 0 && fSpawners != null)
        {
            foreach (FruitSpawner spawner in fSpawners)
            {
                spawner.spawnPickUp();
            }
        }
        
    }
}
