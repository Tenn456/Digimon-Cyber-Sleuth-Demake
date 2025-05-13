using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Assign in Inspector
    public Transform enemySpawnPoint; // Assign in Inspector
    public GameObject playerDigimon;
    public Transform playerDigimonSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayerDigimon();
        SpawnRandomEnemy();
    }

    void SpawnPlayerDigimon()
    {
        GameObject PlayerDigimon = Instantiate(playerDigimon, playerDigimonSpawnPoint.position, Quaternion.identity);
        Wargreymon wargreymon = PlayerDigimon.GetComponent<Wargreymon>();
        wargreymon.stats = GameManager.Instance.playerDigimon;
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[index];

        Instantiate(enemyToSpawn, enemySpawnPoint.position, Quaternion.identity);
    }
}
