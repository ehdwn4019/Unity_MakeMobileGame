using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monster;
    public float timeGap = 3f;
    public Transform[] spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMonster", timeGap, timeGap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMonster()
    {
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        Instantiate(monster, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
    }
}
