using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform spawnPoint;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyDigimon = enemyPrefab[0];

        // Spawns the enemy
        GameObject spawnedEnemy = Instantiate(enemyDigimon, spawnPoint.position, Quaternion.identity);
        enemy = spawnedEnemy.GetComponent<Enemy>();

        enemy.stats.hp *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemy.stats.hp);
    }
}
