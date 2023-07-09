using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> spawnedEnemy;
    [SerializeField] int maxSpawned;
    int spawnAmount;
    bool maxSpawnedReached;
    private void Start()
    {
        
        for (int i = 0; i < maxSpawned; i++)
        {
            spawnedEnemy.Add(null);
        }
        Spawn();
        EnemyController.OnDeath += Spawn;
    }
    void Update()
    {
        spawnAmount = maxSpawned - spawnedEnemy.Count;

    }
    void Spawn()
    {
        if (maxSpawnedReached)
        {
            for (int i = 0; i < spawnedEnemy.Count; i++)
            {
                if (spawnedEnemy[i] == null)
                {
                    maxSpawnedReached = false;
                    break;
                }
            }
                
        }
        for (int i = 0; i < spawnedEnemy.Count; i++)
        {
            if (spawnedEnemy[i] == null)
            {
                var objNull = Instantiate(prefab, this.gameObject.transform);
                spawnedEnemy[i] = objNull;
                objNull.transform.position = this.gameObject.transform.position;
                continue;
            }
        }
    }
}
