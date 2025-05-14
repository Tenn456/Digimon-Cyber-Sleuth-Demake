using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform enemySpawnPoint;
    public GameObject[] allyPrefabs;
    public GameObject playerDigimon;
    public Transform playerDigimonSpawnPoint;
    public GameObject rootUI;
    public GameObject[] rootUIButtons;
    public int onButton = 0;
    public List<GameObject> friendlies = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyIndicator;
    public Wargreymon wargreymon;
    public Metalgarurumon metalgarurumon;
    public GameObject enemyDigimon;

    public bool choosingEnemytoAttack;
    public bool attacking;
    public bool enemyAttacking;
    public float indicatorRotateSpeed;
    public float indicatorScaleSpeed;
    public int onEnemy = 0;
    public int index1;
    public bool enemyTurnStarted = false;
    public bool playerTurnStarted = false;

    public Vector3 indicatorMinScale;
    public Vector3 indicatorMaxScale;

    public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }
    public BattleState state;
    public enum UIState { Root, Attack, Waiting }
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
            if (!enemyTurnStarted)
            {
                StartCoroutine(EnemyTurn());
                enemyTurnStarted = true;
                playerTurnStarted = false;
            }

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
        if (!playerTurnStarted)
        {
            Debug.Log("Player's Turn! Choose an action.");
            rootUI.SetActive(true);
            uiState = UIState.Root;
            playerTurnStarted = true;
        }


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
        Debug.Log($"{wargreymon.stats.digimonName} attacks {metalgarurumon.stats.digimonName}!");

        DamageCalculation();

        yield return new WaitForSeconds(1f);

        if (metalgarurumon.currentHP <= 0)
        {
            state = BattleState.Won;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.EnemyTurn;
        }
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's Turn...");
        yield return new WaitForSeconds(1f);

        Debug.Log($"{metalgarurumon.stats.digimonName} attacks {wargreymon.stats.digimonName}!");
        enemyAttacking = true;

        EnemyDamageCalculation();

        yield return new WaitForSeconds(1f);

        if (wargreymon.currentHP <= 0)
        {
            state = BattleState.Lost;
            StartCoroutine(EndBattle());
            enemyTurnStarted = false;
        }
        else
        {
            state = BattleState.PlayerTurn;
            enemyTurnStarted = false;
        }
    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.Won)
            Debug.Log("You win!");
        else if (state == BattleState.Lost)
            Debug.Log("You were defeated...");

        yield return new WaitForSeconds(1f);

        GameManager.Instance.EndBattle();
    }

    void DamageCalculation()
    {
        if (attacking)
        {
            int damageDone;
            damageDone = (wargreymon.stats.atk * 50) / metalgarurumon.stats.def;

            Debug.Log($"{metalgarurumon.stats.digimonName} takes {damageDone} damage");

            metalgarurumon.currentHP -= damageDone;
            //metalgarurumon.currentHP -= 1000000000;

            if (metalgarurumon.currentHP < 0)
            {
                metalgarurumon.currentHP = 0;
            }

            Debug.Log($"{metalgarurumon.stats.digimonName} has {metalgarurumon.currentHP} HP remaining!");

            attacking = false;
        }
    }

    void EnemyDamageCalculation()
    {
        if (enemyAttacking)
        {
            int damageDone;
            damageDone = (metalgarurumon.stats.atk * 50) / wargreymon.stats.def;

            Debug.Log($"{wargreymon.stats.digimonName} takes {damageDone} damage");

            wargreymon.currentHP -= damageDone;
            //wargreymon.currentHP -= 1000000000;

            if (wargreymon.currentHP < 0)
            {
                wargreymon.currentHP = 0;
            }

            Debug.Log($"{wargreymon.stats.digimonName} has {wargreymon.currentHP} HP remaining!");

            enemyAttacking = false;
        }
    }

    void SpawnPlayerDigimon()
    {
        playerDigimon = allyPrefabs[0];
            
        GameObject spawnedAlly = Instantiate(playerDigimon, playerDigimonSpawnPoint.position, Quaternion.identity);
        wargreymon = spawnedAlly.GetComponent<Wargreymon>();
        //wargreymon.stats = GameManager.Instance.playerDigimon;

        friendlies.Add(spawnedAlly);
    }

    void SpawnRandomEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        // index = Random.Range(0, enemyPrefabs.Length);
        index1 = 0;
        enemyDigimon = enemyPrefabs[index1];

        GameObject spawnedEnemy = Instantiate(enemyDigimon, enemySpawnPoint.position, Quaternion.identity);

        if (index1 == 0)
        {
            metalgarurumon = spawnedEnemy.GetComponent<Metalgarurumon>();
        }

        enemies.Add(spawnedEnemy);
    }

    void RootUI()
    {
        Image image = rootUIButtons[onButton].GetComponent<Image>();

        image.color = Color.gray;

        // If on Attack Button
        if (onButton == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                image.color = Color.white;
                onButton = 1;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                image.color = Color.white;
                onButton = 3;
            }

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                choosingEnemytoAttack = true;
                uiState = UIState.Attack;
            }
        }
        // If on Skill Button
        else if (onButton == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                image.color = Color.white;
                onButton = 0;
            }
        }
        // If on Guard Button
        else if (onButton == 2)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                image.color = Color.white;
                onButton = 0;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                image.color = Color.white;
                onButton = 1;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                image.color = Color.white;
                onButton = 3;
            }
        }
        // If on Item Button
        else if (onButton == 3)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                image.color = Color.white;
                onButton = 0;
            }
        }
    }

    void EnemySelector()
    {
        float t = Mathf.PingPong(Time.time * indicatorScaleSpeed, 1f);

        enemyIndicator.SetActive(true);

        enemyIndicator.transform.position = enemySpawnPoint.position;
        enemyIndicator.transform.Rotate(0f, 0f, indicatorRotateSpeed * Time.deltaTime);
        enemyIndicator.transform.localScale = Vector3.Lerp(indicatorMinScale, indicatorMaxScale, t);

        // For navigating multiple enemies
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (enemies.Count > 0 && onEnemy > 0)
        //    {
        //        onEnemy -= 1;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if (onEnemy < enemies.Count)
        //    {
        //        onEnemy += 1;
        //    }
        //}

        if (choosingEnemytoAttack)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                enemyIndicator.SetActive(false);
                rootUI.SetActive(false);

                attacking = true;
                choosingEnemytoAttack = false;
                uiState = UIState.Waiting;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                enemyIndicator.SetActive(false);

                choosingEnemytoAttack = false;
                uiState = UIState.Root;
            }
        }
    }


}
