using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Assign in Inspector
    public Transform enemySpawnPoint; // Assign in Inspector
    public GameObject playerDigimon;
    public Transform playerDigimonSpawnPoint;
    public GameObject rootUI;
    public GameObject[] rootUIButtons;
    public int onButton = 0;
    public List<GameObject> friendlies = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyIndicator;

    public bool choosingEnemytoAttack;
    public bool inRootUI = true;
    public bool attacking;

    public string playerDigimonName;
    public int playerHp;
    public int playerSp;
    public int playerAtk;
    public int playerIntel;
    public int playerDef;
    public int playerSpd;

    public string enemyDigimonName;
    public int enemyHp;
    public int enemySp;
    public int enemyAtk;
    public int enemyIntel;
    public int enemyDef;
    public int enemySpd;

    public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }
    public BattleState state;
    public enum UIState { Root, Attack }
    public UIState uiState;

    // Start is called before the first frame update
    void Start()
    {
        rootUI.SetActive(false);
        enemyIndicator.SetActive(false);
        StartCoroutine(BeginBattle());
    }

    void Update()
    {
        if (state == BattleState.PlayerTurn)
        {
            PlayerTurn();
        }
        else if (state == BattleState.EnemyTurn)
        {
            EnemyTurn();
        }
    }

    IEnumerator BeginBattle()
    {
        state = BattleState.Start;

        SpawnPlayerDigimon();
        SpawnRandomEnemy();

        yield return new WaitForSeconds(1f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("Player's Turn! Choose an action.");
        // Enable UI buttons here
        rootUI.SetActive(true);

        Image image = rootUIButtons[onButton].GetComponent<Image>();

        image.color = Color.gray;

        if (uiState == UIState.Root)
        {
            RootUI();
        }
        else if (uiState == UIState.Attack)
        {
            EnemySelector();
        }

        if (attacking)
        {
            OnPlayerAttack();
        }


    }

    public void OnPlayerAttack()
    {
        if (state != BattleState.PlayerTurn) return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        //Debug.Log($"{stats.name} attacks ");

        yield return new WaitForSeconds(1f);

        state = BattleState.EnemyTurn;
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's Turn...");
        yield return new WaitForSeconds(1f);
    }

    void EndBattle()
    {
        if (state == BattleState.Won)
            Debug.Log("You win!");
        else if (state == BattleState.Lost)
            Debug.Log("You were defeated...");

        // You can load a scene, return to overworld, show rewards, etc.
    }

    void SpawnPlayerDigimon()
    {
        GameObject PlayerDigimon = Instantiate(playerDigimon, playerDigimonSpawnPoint.position, Quaternion.identity);
        Wargreymon wargreymon = PlayerDigimon.GetComponent<Wargreymon>();
        wargreymon.stats = GameManager.Instance.playerDigimon;

        friendlies.Add(PlayerDigimon);
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        //int index = Random.Range(0, enemyPrefabs.Length);
        int index = 0;
        GameObject enemyDigimon = enemyPrefabs[index];

        Instantiate(enemyDigimon, enemySpawnPoint.position, Quaternion.identity);

        if (index == 0)
        {
            MetalGarurumonStats metalgarurumon = enemyDigimon.GetComponent<MetalGarurumonStats>();
            //enemyDigimonName = metalgarurumon.digimonName;
            //enemyHp = metalgarurumon.hp;
            //enemySp = metalgarurumon.sp;
            //enemyAtk = metalgarurumon.atk;
            //enemyIntel = metalgarurumon.intel;
            //enemyDef = metalgarurumon.def;
            //enemySpd = metalgarurumon.spd;
        }

        enemies.Add(enemyDigimon);
    }

    void RootUI()
    {
        Image image = rootUIButtons[onButton].GetComponent<Image>();

        image.color = Color.gray;

        // If on Attack Button
        if (onButton == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                image.color = Color.white;
                onButton = 1;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                image.color = Color.white;
                onButton = 3;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                uiState = UIState.Attack;
            }
        }
        // If on Skill Button
        else if (onButton == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                image.color = Color.white;
                onButton = 0;
            }
        }
        // If on Guard Button
        else if (onButton == 2)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                image.color = Color.white;
                onButton = 0;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                image.color = Color.white;
                onButton = 1;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                image.color = Color.white;
                onButton = 3;
            }
        }
        // If on Item Button
        else if (onButton == 3)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                image.color = Color.white;
                onButton = 0;
            }
        }
    }

    void EnemySelector()
    {
        enemyIndicator.SetActive(true);

        enemyIndicator.transform.position = enemySpawnPoint.position;

        if (choosingEnemytoAttack)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                enemyIndicator.SetActive(false);

                attacking = true;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                enemyIndicator.SetActive(false);

                uiState = UIState.Root;
            }
        }
    }


}
