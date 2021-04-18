using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monster;
    public float timeGap = 10f;
    public Transform[] spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMonster", timeGap, timeGap);
    }

    void SpawnMonster()
    {
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        Instantiate(monster, spawnPositions[spawnIndex].position, spawnPositions[spawnIndex].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
