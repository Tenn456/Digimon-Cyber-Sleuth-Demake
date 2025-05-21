using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using Unity.VisualScripting;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public GameObject spawnedAlly1;
    public GameObject spawnedAlly2;
    public GameObject spawnedEnemy1;
    public GameObject spawnedEnemy2;
    public GameObject spawnedEnemy3;
    public GameObject currentDigimon;

    public GameObject rootUI;
    public GameObject skillsUI;
    public GameObject itemUI;
    public GameObject enemyIndicator1;
    public GameObject enemyIndicator2;
    public GameObject enemyIndicator3;
    public GameObject allyIndicator1;
    public GameObject allyIndicator2;
    public GameObject player1UI;
    public GameObject player2UI;
    public GameObject player1Shield;
    public GameObject player2Shield;
    public GameObject enemy1Shield;
    public GameObject enemy2Shield;
    public GameObject enemy3Shield;
    public GameObject itemSelectorBox;
    public GameObject enemy1HPBar;
    public GameObject enemy2HPBar;
    public GameObject enemy3HPBar;

    public GameObject[] allyPrefabs;
    public GameObject[] enemyPrefabs;

    public GameObject[] rootUIButtons;
    public GameObject[] skillsUIButtons;

    public GameObject[] itemUIButtons;

    public Transform[] playerDigimonSpawnPoint;
    public Transform[] enemySpawnPoint;

    public Vector3 p1UiStartPosition;
    public Vector3 p1UiEndPosition;
    public Vector3 p2UiStartPosition;
    public Vector3 p2UiEndPosition;
    public Vector3 enemy1DamageBotPosition;
    public Vector3 enemy2DamageBotPosition;
    public Vector3 enemy3DamageBotPosition;
    public Vector3 player1DamageBotPosition;
    public Vector3 player2DamageBotPosition;
    public Vector3 player1StartPos;
    public Vector3 player2StartPos;
    public Vector3 enemy1StartPos;
    public Vector3 enemy2StartPos;
    public Vector3 enemy3StartPos;

    public List<GameObject> digimonOnField = new List<GameObject>();
    public List<GameObject> allyDigimonList = new List<GameObject>();
    public List<GameObject> enemyDigimonList = new List<GameObject>();
    public List<GameObject> allyDigimonAlive = new List<GameObject>();

    public TextMeshProUGUI skillDescriptionText;
    public TextMeshProUGUI skill1Name;
    public TextMeshProUGUI skill1Cost;
    public TextMeshProUGUI skill2Name;
    public TextMeshProUGUI skill2Cost;
    public TextMeshProUGUI skill3Name;
    public TextMeshProUGUI skill3Cost;
    public TextMeshProUGUI player1HP;
    public TextMeshProUGUI player2HP;
    public TextMeshProUGUI enemy1HP;
    public TextMeshProUGUI enemy2HP;
    public TextMeshProUGUI enemy3HP;
    public TextMeshProUGUI player1SP;
    public TextMeshProUGUI player2SP;
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI hpCapsuleAmountText;
    public TextMeshProUGUI spCapsuleAmountText;
    public TextMeshProUGUI damageToEnemy1Text;
    public TextMeshProUGUI damageToEnemy2Text;
    public TextMeshProUGUI damageToEnemy3Text;
    public TextMeshProUGUI damageToPlayer1Text;
    public TextMeshProUGUI damageToPlayer2Text;
    public TextMeshProUGUI healtoPlayer1Text;
    public TextMeshProUGUI healtoPlayer2Text;
    public TextMeshProUGUI spToPlayer1Text;
    public TextMeshProUGUI spToPlayer2Text;

    public VideoPlayer videoPlayer;
    public VideoClip terraForce;
    public VideoClip greatTornado;
    public VideoClip IceWolfClaw;
    public VideoClip freezingBreath;
    public VideoClip infinityCannon;
    public VideoClip forbiddenTrident;
    public VideoClip nightRaid;
    public VideoClip tidalWave;

    public Slider player1HPSlider;
    public Slider player2HPSlider;
    public Slider player1SPSlider;
    public Slider player2SPSlider;
    public Slider enemy1HPSlider;
    public Slider enemy2HPSlider;
    public Slider enemy3HPSlider;

    public Ally playerDigimon1;
    public Ally playerDigimon2;

    public Enemy enemyDigimon1;
    public Enemy enemyDigimon2;
    public Enemy enemyDigimon3;

    public AudioSource audioSource;
    public AudioClip moveButtons;
    public AudioClip backButton;
    public AudioClip selectButton;
    public AudioClip hit;
    public AudioClip heal;

    public int enemiesSpawned;
    public int targetDigimon;
    public int enemyTargetDigimon;
    public int allyNum = 1;
    public int enemyNum = 1;
    public int currentTurnIndex;
    public int enemyActionIndex;
    public int hpCapsuleAmount;
    public int hpSprayAmount;
    public int spCapsuleAmount;
    public int spSprayAmount;

    public int onButton;
    public int onSkillButton = 1;
    public int onEnemy = 1;
    public int onItemButton = 1;
    public int onAlly = 1;

    public bool usingAttack;
    public bool attacking;
    public bool enemyAttacking;
    public bool enemyTurn;
    public bool playerTurnStarted;
    public bool digimonSpeedFull;
    public bool playerDigimon1Turn;
    public bool playerDigimon2Turn;
    public bool enemyDigimon1Turn;
    public bool enemyDigimon2Turn;
    public bool enemyDigimon3Turn;
    public bool usingSkill;
    public bool targetingEnemy;
    public bool attackingEnemy1;
    public bool attackingEnemy2;
    public bool attackingEnemy3;
    public bool started;
    public bool enemyUsingSkill;
    public bool enemyGuarding;
    public bool usingItem;
    public bool targetingAlly;
    public bool targetingAlly1;
    public bool targetingAlly2;
    public bool targetingForItem;
    public bool damageDealt;
    public bool enemyAttackingP1;
    public bool enemyAttackingP2;
    public bool enemyUsingAttack;
    public bool playerUsingAttack;
    public bool playerHealing;
    public bool playerSpGain;

    public bool skillMenuUp;
    public bool itemMenuUp;
    public bool multiTarget;
    public bool p1UiUp;
    public bool p2UiUp;
    public bool damageGoingUp = true;
    public bool damageGoingDown;
    public bool damageGoingUp1 = true;
    public bool damageGoingDown1;
    public float pierceMultiplier = 1.8f;

    public float indicatorRotateSpeed;
    public float indicatorScaleSpeed;
    public float elapsedTime;
    public float elapsedTimeDamage;
    public float playerUiDuration = 0.3f;
    public float damageDuration = 0.5f;

    public Vector3 indicatorMinScale;
    public Vector3 indicatorMaxScale;

    public enum BattleState { Start, PlayerTurn, PlayerEndTurn, EnemyTurn, Won, Lost }
    public enum UIState { Waiting, Root, Target, Skills, Items }

    public BattleState state;
    public UIState uiState;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ui Menus
        rootUI.SetActive(false);
        skillsUI.SetActive(false);
        itemUI.SetActive(false);

        // Guard Bubbles
        player1Shield.SetActive(false);
        player2Shield.SetActive(false);
        enemy1Shield.SetActive(false);
        enemy2Shield.SetActive(false);
        enemy3Shield.SetActive(false);

        player1Shield.transform.position = playerDigimonSpawnPoint[0].position;
        player2Shield.transform.position = playerDigimonSpawnPoint[1].position;
        enemy1Shield.transform.position = enemySpawnPoint[0].position;
        enemy2Shield.transform.position = enemySpawnPoint[1].position;
        enemy3Shield.transform.position = enemySpawnPoint[2].position;

        // Damage Text
        damageToEnemy1Text.text = "";
        damageToEnemy2Text.text = "";
        damageToEnemy3Text.text = "";

        damageToPlayer1Text.text = "";
        damageToPlayer2Text.text = "";

        float textOffsetY = 0.8f;
        damageToEnemy1Text.transform.position = new Vector2(enemySpawnPoint[0].position.x, enemySpawnPoint[0].position.y + textOffsetY);
        damageToEnemy2Text.transform.position = new Vector2(enemySpawnPoint[1].position.x, enemySpawnPoint[1].position.y + textOffsetY);
        damageToEnemy3Text.transform.position = new Vector2(enemySpawnPoint[2].position.x, enemySpawnPoint[2].position.y + textOffsetY);

        damageToPlayer1Text.transform.position = new Vector2(playerDigimonSpawnPoint[0].position.x, playerDigimonSpawnPoint[0].position.y + textOffsetY);
        damageToPlayer2Text.transform.position = new Vector2(playerDigimonSpawnPoint[1].position.x, playerDigimonSpawnPoint[1].position.y + textOffsetY);

        enemy1DamageBotPosition = damageToEnemy1Text.transform.position;
        enemy2DamageBotPosition = damageToEnemy2Text.transform.position;
        enemy3DamageBotPosition = damageToEnemy3Text.transform.position;

        player1DamageBotPosition = damageToPlayer1Text.transform.position;
        player2DamageBotPosition = damageToPlayer2Text.transform.position;

        // Heal Text
        healtoPlayer1Text.text = "";
        healtoPlayer2Text.text = "";

        healtoPlayer1Text.transform.position = new Vector2(playerDigimonSpawnPoint[0].position.x, playerDigimonSpawnPoint[0].position.y + textOffsetY);
        healtoPlayer2Text.transform.position = new Vector2(playerDigimonSpawnPoint[1].position.x, playerDigimonSpawnPoint[1].position.y + textOffsetY);

        // SP Text
        spToPlayer1Text.text = "";
        spToPlayer2Text.text = "";

        spToPlayer1Text.transform.position = new Vector2(playerDigimonSpawnPoint[0].position.x, playerDigimonSpawnPoint[0].position.y + textOffsetY);
        spToPlayer2Text.transform.position = new Vector2(playerDigimonSpawnPoint[1].position.x, playerDigimonSpawnPoint[1].position.y + textOffsetY);

        // Enemy HP Bar
        enemy1HPBar.SetActive(false);
        enemy2HPBar.SetActive(false);
        enemy3HPBar.SetActive(false);

        float offsetX = 2.5f;
        float offsetY = 1f;

        enemy1HPBar.transform.position = new Vector2(enemySpawnPoint[0].position.x - offsetX, enemySpawnPoint[0].position.y + offsetY);
        enemy2HPBar.transform.position = new Vector2(enemySpawnPoint[1].position.x - offsetX, enemySpawnPoint[1].position.y + offsetY);
        enemy3HPBar.transform.position = new Vector2(enemySpawnPoint[2].position.x - offsetX, enemySpawnPoint[2].position.y + offsetY);

        // Target Indicators
        allyIndicator1.SetActive(false);
        allyIndicator2.SetActive(false);

        enemyIndicator1.SetActive(false);
        enemyIndicator2.SetActive(false);
        enemyIndicator3.SetActive(false);

        // Player Digimon UI
        p1UiStartPosition = player1UI.transform.position;
        p2UiStartPosition = player2UI.transform.position;

        p1UiEndPosition = p1UiStartPosition + Vector3.up * 0.5f;
        p2UiEndPosition = p2UiStartPosition + Vector3.up * 0.5f;

        SpawnDigimon();
    }

    void Update()
    {
        if (playerDigimon1)
        {
            player1HP.text = playerDigimon1.currentHP.ToString();
            player1SP.text = playerDigimon1.currentSP.ToString();
            player1Name.text = playerDigimon1.stats.digimonName.ToString();
        }
        if (playerDigimon2)
        {
            player2HP.text = playerDigimon2.currentHP.ToString();
            player2SP.text = playerDigimon2.currentSP.ToString();
            player2Name.text = playerDigimon2.stats.digimonName.ToString();
        }

        if (state == BattleState.Start)
        {
            if (!started)
            {
                StartCoroutine(BeginBattle());
            }
        }
        if (state == BattleState.PlayerTurn)
        {
            PlayerTurn();

            if (playerDigimon1Turn)
            {
                if (!p1UiUp)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / playerUiDuration);

                    player1UI.transform.position = Vector3.Lerp(player1UI.transform.position, p1UiEndPosition, t);

                    if (t >= 1f)
                    {
                        p1UiUp = true;
                        elapsedTime = 0;
                    }
                }
            }
            else if (playerDigimon2Turn)
            {
                if (!p2UiUp)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / playerUiDuration);

                    player2UI.transform.position = Vector3.Lerp(player2UI.transform.position, p2UiEndPosition, t);

                    if (t >= 1f)
                    {
                        p2UiUp = true;
                        elapsedTime = 0;
                    }
                }
            }
        }
        else if (state == BattleState.PlayerEndTurn)
        {
            PlayerEndTurn();
        }
        else if (state == BattleState.EnemyTurn)
        {
            if (!enemyTurn)
            {
                if (enemyDigimon1Turn)
                {
                    if (enemyDigimon1.guarding)
                    {
                        enemyDigimon1.guarding = false;
                        enemy1Shield.SetActive(false);
                    }
                }
                else if (enemyDigimon2Turn)
                {

                    if (enemyDigimon2.guarding)
                    {
                        enemyDigimon2.guarding = false;
                        enemy2Shield.SetActive(false);
                    }
                }
                else if (enemyDigimon3Turn)
                {
                    if (enemyDigimon3.guarding)
                    {
                        enemyDigimon3.guarding = false;
                        enemy3Shield.SetActive(false);
                    }
                }

                StartCoroutine(EnemyTurn());
            }
        }

        if (damageDealt)
        {
            if (attackingEnemy1)
            {
                Vector3 damageTopPosition = enemy1DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToEnemy1Text.transform.position = Vector3.Lerp(damageToEnemy1Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToEnemy1Text.transform.position = Vector3.MoveTowards(damageToEnemy1Text.transform.position, enemy1DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        damageDealt = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
            if (attackingEnemy2)
            {
                Vector3 damageTopPosition = enemy2DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToEnemy2Text.transform.position = Vector3.Lerp(damageToEnemy2Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToEnemy2Text.transform.position = Vector3.MoveTowards(damageToEnemy2Text.transform.position, enemy2DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        damageDealt = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
            if (attackingEnemy3)
            {
                Vector3 damageTopPosition = enemy3DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToEnemy3Text.transform.position = Vector3.Lerp(damageToEnemy3Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToEnemy3Text.transform.position = Vector3.MoveTowards(damageToEnemy3Text.transform.position, enemy3DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        damageDealt = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
            if (enemyAttackingP1)
            {
                Vector3 damageTopPosition = player1DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToPlayer1Text.transform.position = Vector3.Lerp(damageToPlayer1Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToPlayer1Text.transform.position = Vector3.MoveTowards(damageToPlayer1Text.transform.position, player1DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        damageDealt = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
            if (enemyAttackingP2)
            {
                Vector3 damageTopPosition = player2DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToPlayer2Text.transform.position = Vector3.Lerp(damageToPlayer2Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    damageToPlayer2Text.transform.position = Vector3.MoveTowards(damageToPlayer2Text.transform.position, player2DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        damageDealt = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
        }

        if (playerUsingAttack)
        {
            if (playerDigimon1Turn)
            {
                Vector3 attackPosition = player1StartPos + Vector3.right * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedAlly1.transform.position = Vector3.MoveTowards(spawnedAlly1.transform.position, attackPosition, t);

                    if (t >= 0.3f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedAlly1.transform.position = Vector3.MoveTowards(spawnedAlly1.transform.position, player1StartPos, t);

                    if (t >= 0.3f)
                    {
                        damageGoingDown = false;
                        damageGoingUp = true;
                        elapsedTimeDamage = 0;
                        playerUsingAttack = false;
                    }
                }
            }
            if (playerDigimon2Turn)
            {
                Vector3 attackPosition = player2StartPos + Vector3.right * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedAlly2.transform.position = Vector3.MoveTowards(spawnedAlly2.transform.position, attackPosition, t);

                    if (t >= 0.3f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedAlly2.transform.position = Vector3.MoveTowards(spawnedAlly2.transform.position, player2StartPos, t);

                    if (t >= 0.3f)
                    {
                        damageGoingDown = false;
                        damageGoingUp = true;
                        elapsedTimeDamage = 0;
                        playerUsingAttack = false;
                    }
                }
            }
        }

        if (enemyUsingAttack)
        {
            if (enemyDigimon1Turn)
            {
                Vector3 attackPosition = enemy1StartPos - Vector3.right * 0.5f;

                if (damageGoingUp1)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedEnemy1.transform.position = Vector3.MoveTowards(spawnedEnemy1.transform.position, attackPosition, t);

                    if (t >= 0.3f)
                    {
                        damageGoingUp1 = false;
                        damageGoingDown1 = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown1)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedEnemy1.transform.position = Vector3.MoveTowards(spawnedEnemy1.transform.position, enemy1StartPos, t);

                    if (t >= 0.3f)
                    {
                        damageGoingDown1 = false;
                        damageGoingUp1 = true;
                        elapsedTimeDamage = 0;
                        enemyUsingAttack = false;
                    }
                }
            }
            if (enemyDigimon2Turn)
            {
                Vector3 attackPosition = enemy2StartPos - Vector3.right * 0.5f;

                if (damageGoingUp1)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedEnemy2.transform.position = Vector3.MoveTowards(spawnedEnemy2.transform.position, attackPosition, t);

                    if (t >= 0.3f)
                    {
                        damageGoingUp1 = false;
                        damageGoingDown1 = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown1)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedEnemy2.transform.position = Vector3.MoveTowards(spawnedEnemy2.transform.position, enemy2StartPos, t);

                    if (t >= 0.3f)
                    {
                        damageGoingDown1 = false;
                        damageGoingUp1 = true;
                        elapsedTimeDamage = 0;
                        enemyUsingAttack = false;
                    }
                }
            }
            if (enemyDigimon3Turn)
            {
                Vector3 attackPosition = enemy3StartPos - Vector3.right * 0.5f;

                if (damageGoingUp1)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedEnemy3.transform.position = Vector3.MoveTowards(spawnedEnemy3.transform.position, attackPosition, t);

                    if (t >= 0.3f)
                    {
                        damageGoingUp1 = false;
                        damageGoingDown1 = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown1)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage);

                    spawnedEnemy3.transform.position = Vector3.MoveTowards(spawnedEnemy3.transform.position, enemy3StartPos, t);

                    if (t >= 0.3f)
                    {
                        damageGoingDown1 = false;
                        damageGoingUp1 = true;
                        elapsedTimeDamage = 0;
                        enemyUsingAttack = false;
                    }
                }
            }
        }

        if (playerHealing)
        {
            if (playerDigimon1)
            {
                Vector3 damageTopPosition = player1DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    healtoPlayer1Text.transform.position = Vector3.Lerp(healtoPlayer1Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    healtoPlayer1Text.transform.position = Vector3.MoveTowards(healtoPlayer1Text.transform.position, player1DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        playerHealing = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
            if (playerDigimon2)
            {
                Vector3 damageTopPosition = player2DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    healtoPlayer2Text.transform.position = Vector3.Lerp(healtoPlayer2Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    healtoPlayer2Text.transform.position = Vector3.MoveTowards(healtoPlayer2Text.transform.position, player2DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        playerHealing = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
        }

        if (playerSpGain)
        {
            if (playerDigimon1)
            {
                Vector3 damageTopPosition = player1DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    spToPlayer1Text.transform.position = Vector3.Lerp(spToPlayer1Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    spToPlayer1Text.transform.position = Vector3.MoveTowards(spToPlayer1Text.transform.position, player1DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        playerSpGain = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
            if (playerDigimon2)
            {
                Vector3 damageTopPosition = player2DamageBotPosition + Vector3.up * 0.5f;

                if (damageGoingUp)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    spToPlayer2Text.transform.position = Vector3.Lerp(spToPlayer2Text.transform.position, damageTopPosition, t);

                    if (t >= 0.2f)
                    {
                        damageGoingUp = false;
                        damageGoingDown = true;
                        elapsedTimeDamage = 0;
                    }
                }
                else if (damageGoingDown)
                {
                    elapsedTimeDamage += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTimeDamage / damageDuration);

                    spToPlayer2Text.transform.position = Vector3.MoveTowards(spToPlayer2Text.transform.position, player2DamageBotPosition, t);

                    if (t >= 0.2f)
                    {
                        elapsedTimeDamage = 0;

                        playerSpGain = false;
                        damageGoingDown = false;
                        damageGoingUp = true;
                    }
                }
            }
        }
    }

    IEnumerator BeginBattle()
    {
        state = BattleState.Start;

        SpeedCheck();
        TurnCheck();

        yield return new WaitForSeconds(1f);

        started = true;
    }

    public void SpeedCheck()
    {
        // Goes through the whole list
        digimonOnField.Sort((a, b) =>
        {
            int aSpeed = 0;
            int bSpeed = 0;

            // Checks if the digimon is an Ally or Enemy and grabs speed stat
            if (a.TryGetComponent<Ally>(out var allyA))
                aSpeed = allyA.currentSPD;
            else if (a.TryGetComponent<Enemy>(out var enemyA))
                aSpeed = enemyA.currentSPD;

            if (b.TryGetComponent<Ally>(out var allyB))
                bSpeed = allyB.currentSPD;
            else if (b.TryGetComponent<Enemy>(out var enemyB))
                bSpeed = enemyB.currentSPD;

            return bSpeed.CompareTo(aSpeed); // Descending order
        });

        // Prints turn order
        Debug.Log("Speed check complete. Turn order:");
        foreach (var digimon in digimonOnField)
        {
            string name = "Unknown";
            int speed = 0;

            if (digimon.TryGetComponent<Ally>(out var ally))
            {
                name = ally.stats.digimonName;
                speed = ally.currentSPD;
                //digimon.tag = "Player" + allyNum;
                //allyNum++;
            }
            else if (digimon.TryGetComponent<Enemy>(out var enemy))
            {
                name = enemy.stats.digimonName;
                speed = enemy.currentSPD;
                //digimon.tag = "Enemy" + enemyNum;
                //enemyNum++;
            }

            Debug.Log($"{name} - Speed: {speed}");
        }
    }

    public void TurnCheck()
    {
        if (!playerDigimon1.alive && !playerDigimon2.alive)
        {
            state = BattleState.Lost;
            StartCoroutine(EndBattle());
        }
        else
        {
            if (digimonOnField.Count == 0)
            {
                if (spawnedAlly1)
                {
                    digimonOnField.Add(spawnedAlly1);
                }
                if (spawnedAlly2)
                {
                    digimonOnField.Add(spawnedAlly2);
                }
                if (spawnedEnemy1)
                {
                    digimonOnField.Add(spawnedEnemy1);
                }
                if (spawnedEnemy2)
                {
                    digimonOnField.Add(spawnedEnemy2);
                }
                if (spawnedEnemy3)
                {
                    digimonOnField.Add(spawnedEnemy3);
                }

                SpeedCheck();
            }

            currentDigimon = digimonOnField[currentTurnIndex];

            if (currentDigimon.TryGetComponent<Ally>(out _))
            {
                if (currentDigimon == spawnedAlly1)
                {
                    if (playerDigimon1.currentHP > 0)
                    {
                        playerDigimon1Turn = true;
                        state = BattleState.PlayerTurn;
                        Debug.Log($"It's {playerDigimon1.stats.digimonName}'s turn (Player).");
                    }
                    else
                    {
                        digimonOnField.Remove(spawnedAlly1);
                        TurnCheck();
                    }
                }
                else if (currentDigimon == spawnedAlly2)
                {
                    if (playerDigimon2.currentHP > 0)
                    {
                        playerDigimon2Turn = true;
                        state = BattleState.PlayerTurn;
                        Debug.Log($"It's {playerDigimon2.stats.digimonName}'s turn (Player).");
                    }
                    else
                    {
                        digimonOnField.Remove(spawnedAlly2);
                        TurnCheck();
                    }
                }

            }
            else if (currentDigimon.TryGetComponent<Enemy>(out _))
            {
                if (spawnedEnemy1)
                {
                    if (currentDigimon == spawnedEnemy1)
                    {
                        enemyDigimon1Turn = true;

                        state = BattleState.EnemyTurn;
                        Debug.Log($"It's {enemyDigimon1.stats.digimonName}'s 1 turn (Enemy).");
                    }
                }
                if (spawnedEnemy2)
                {
                    if (currentDigimon == spawnedEnemy2)
                    {
                        enemyDigimon2Turn = true;
                        state = BattleState.EnemyTurn;
                        Debug.Log($"It's {enemyDigimon2.stats.digimonName}'s 2 turn (Enemy).");
                    }
                }
                if (spawnedEnemy3)
                {
                    if (currentDigimon == spawnedEnemy3)
                    {
                        enemyDigimon3Turn = true;
                        state = BattleState.EnemyTurn;
                        Debug.Log($"It's {enemyDigimon3.stats.digimonName}'s 3 turn (Enemy).");
                    }
                }
            }
        }
    }

    void PlayerTurn()
    {
        if (playerDigimon1Turn)
        {
            if (!playerTurnStarted)
            {
                if (playerDigimon1.atkBuffed)
                {
                    if (playerDigimon1.turnsAtkBuffed < 3)
                    {
                        playerDigimon1.turnsAtkBuffed++;
                    }
                    else
                    {
                        playerDigimon1.currentATK = playerDigimon1.stats.atk;
                        playerDigimon1.atkBuffed = false;
                        Debug.Log(playerDigimon1.currentATK);
                        Debug.Log("Attack Buff Ended");
                    }
                }
                Debug.Log("Attack Buffed: " + playerDigimon2.atkBuffed);

                if (spawnedEnemy1)
                {
                    onEnemy = 1;
                }
                else if (spawnedEnemy2)
                {
                    onEnemy = 1;
                }
                else if (spawnedEnemy3)
                {
                    onEnemy = 1;
                }

                if (spawnedEnemy1)
                {
                    enemy1HPBar.SetActive(true);
                }
                if (spawnedEnemy2)
                {
                    enemy2HPBar.SetActive(true);
                }
                if (spawnedEnemy3)
                {
                    enemy3HPBar.SetActive(true);
                }

                if (playerDigimon1.guarding)
                {
                    playerDigimon1.guarding = false;
                    player1Shield.SetActive(false);
                }

                onButton = 0;
                onSkillButton = 1;
                enemyTurn = false;
                rootUI.SetActive(true);
                uiState = UIState.Root;
                playerTurnStarted = true;
            }

            if (uiState == UIState.Root)
            {
                RootUI();
            }
            else if (uiState == UIState.Skills)
            {
                SkillsUI();
            }
            else if (uiState == UIState.Items)
            {
                ItemsUI();
            }
            else if (uiState == UIState.Target)
            {
                Selector();
            }

            if (attacking)
            {
                if (usingAttack)
                {
                    //OnPlayerAttack();
                    StartCoroutine(PlayerAttack());
                }
                else if (usingSkill)
                {
                    StartCoroutine(PlayerSkill());
                }

                attacking = false;
            }

            if (usingItem)
            {
                StartCoroutine(Item());
                usingItem = false;
            }
        }
        else if (playerDigimon2Turn)
        {
            if (!playerTurnStarted)
            {
                if (playerDigimon2.atkBuffed)
                {
                    if (playerDigimon2.turnsAtkBuffed < 3)
                    {
                        playerDigimon2.turnsAtkBuffed++;
                    }
                    else
                    {
                        playerDigimon2.currentATK = playerDigimon2.stats.atk;
                        playerDigimon2.atkBuffed = false;
                        Debug.Log(playerDigimon2.currentATK);
                        Debug.Log("Attack Buff Ended");
                    }

                }
                Debug.Log("Attack Buffed: " + playerDigimon2.atkBuffed);

                if (spawnedEnemy1)
                {
                    onEnemy = 1;
                }
                else if (spawnedEnemy2)
                {
                    onEnemy = 1;
                }
                else if (spawnedEnemy3)
                {
                    onEnemy = 1;
                }

                if (spawnedEnemy1)
                {
                    enemy1HPBar.SetActive(true);
                }
                if (spawnedEnemy2)
                {
                    enemy2HPBar.SetActive(true);
                }
                if (spawnedEnemy3)
                {
                    enemy3HPBar.SetActive(true);
                }

                if (playerDigimon2.guarding)
                {
                    playerDigimon2.guarding = false;
                    player2Shield.SetActive(false);
                }

                onButton = 0;
                onSkillButton = 1;
                enemyTurn = false;
                rootUI.SetActive(true);
                uiState = UIState.Root;
                playerTurnStarted = true;
            }

            if (uiState == UIState.Root)
            {
                RootUI();
            }
            else if (uiState == UIState.Skills)
            {
                SkillsUI();
            }
            else if (uiState == UIState.Items)
            {
                ItemsUI();
            }
            else if (uiState == UIState.Target)
            {
                Selector();
            }

            if (attacking)
            {
                if (usingAttack)
                {
                    //OnPlayerAttack();
                    StartCoroutine(PlayerAttack());
                }
                else if (usingSkill)
                {
                    StartCoroutine(PlayerSkill());
                }

                attacking = false;
            }

            if (usingItem)
            {
                StartCoroutine(Item());
                usingItem = false;
            }
        }
    }

    //public void OnPlayerAttack()
    //{
    //    if (state != BattleState.PlayerTurn) return;

    //    StartCoroutine(PlayerAttack());
    //}

    IEnumerator PlayerAttack()
    {
        if (playerDigimon1Turn)
        {
            if (attackingEnemy1)
            {
                Debug.Log($"{playerDigimon1.stats.digimonName} attacks {enemyDigimon1.stats.digimonName}!");
                playerUsingAttack = true;

                yield return new WaitForSeconds(1f);

                DamageCalculation();

                audioSource.PlayOneShot(hit);

                damageDealt = true;

                Debug.Log($"{enemyDigimon1.stats.digimonName} has {enemyDigimon1.currentHP} HP left!");

            }
            else if (attackingEnemy2)
            {
                Debug.Log($"{playerDigimon1.stats.digimonName} attacks {enemyDigimon2.stats.digimonName}!");
                playerUsingAttack = true;

                yield return new WaitForSeconds(1f);

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;

                Debug.Log($"{enemyDigimon2.stats.digimonName} has {enemyDigimon2.currentHP} HP left!");
            }
            else if (attackingEnemy3)
            {
                Debug.Log($"{playerDigimon1.stats.digimonName} attacks {enemyDigimon3.stats.digimonName}!");
                playerUsingAttack = true;

                yield return new WaitForSeconds(1f);

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;

                Debug.Log($"{enemyDigimon3.stats.digimonName} has {enemyDigimon3.currentHP} HP left!");
            }
        }
        else if (playerDigimon2Turn)
        {
            if (attackingEnemy1)
            {
                Debug.Log($"{playerDigimon2.stats.digimonName} attacks {enemyDigimon1.stats.digimonName}!");
                playerUsingAttack = true;

                yield return new WaitForSeconds(1f);

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;

                Debug.Log($"{enemyDigimon1.stats.digimonName} has {enemyDigimon1.currentHP} HP left!");

            }
            else if (attackingEnemy2)
            {
                Debug.Log($"{playerDigimon2.stats.digimonName} attacks {enemyDigimon2.stats.digimonName}!");
                playerUsingAttack = true;

                yield return new WaitForSeconds(1f);

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;

                Debug.Log($"{enemyDigimon2.stats.digimonName} has {enemyDigimon2.currentHP} HP left!");
            }
            else if (attackingEnemy3)
            {
                Debug.Log($"{playerDigimon2.stats.digimonName} attacks {enemyDigimon3.stats.digimonName}!");
                playerUsingAttack = true;

                yield return new WaitForSeconds(1f);

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;

                Debug.Log($"{enemyDigimon3.stats.digimonName} has {enemyDigimon3.currentHP} HP left!");
            }
        }

        yield return new WaitForSeconds(1f);

        damageToEnemy1Text.text = "";
        damageToEnemy2Text.text = "";
        damageToEnemy3Text.text = "";

        state = BattleState.PlayerEndTurn;
    }

    IEnumerator PlayerSkill()
    {
        if (playerDigimon1Turn)
        {
            if (onSkillButton == 1)
            {
                playerDigimon1.currentSP -= playerDigimon1.stats.skill1Cost;
                player1SPSlider.value = playerDigimon1.currentSP;

                Debug.Log($"{playerDigimon1.stats.digimonName} uses {playerDigimon1.stats.skill1Name}");

                if (spawnedEnemy1)
                {
                    attackingEnemy1 = true;
                }
                if (spawnedEnemy2)
                {
                    attackingEnemy2 = true;
                }
                if (spawnedEnemy1)
                {
                    attackingEnemy3 = true;
                }

                videoPlayer.clip = terraForce;
                videoPlayer.Play();

                yield return new WaitForSeconds(3f);

                videoPlayer.Stop();

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;

            }
            else if (onSkillButton == 2)
            {
                playerDigimon1.currentSP -= playerDigimon1.stats.skill2Cost;
                player1SPSlider.value = playerDigimon1.currentSP;

                videoPlayer.clip = greatTornado;
                videoPlayer.Play();

                if (attackingEnemy1)
                {
                    Debug.Log($"{playerDigimon1.stats.digimonName} uses {playerDigimon1.stats.skill2Name} on {enemyDigimon1.stats.digimonName}!");

                    yield return new WaitForSeconds(3f);

                    videoPlayer.Stop();

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else if (attackingEnemy2)
                {
                    Debug.Log($"{playerDigimon1.stats.digimonName} uses {playerDigimon1.stats.skill2Name} on {enemyDigimon2.stats.digimonName}!");

                    yield return new WaitForSeconds(3f);

                    videoPlayer.Stop();

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else if (attackingEnemy3)
                {
                    Debug.Log($"{playerDigimon1.stats.digimonName} uses {playerDigimon1.stats.skill2Name} on {enemyDigimon3.stats.digimonName}!");

                    yield return new WaitForSeconds(3f);

                    videoPlayer.Stop();

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
            }
            //else
            //{
            //    playerDigimon1.currentSP -= playerDigimon1.stats.skill3Cost;
            //}
        }
        else if (playerDigimon2Turn)
        {
            if (onSkillButton == 1)
            {
                playerDigimon2.currentSP -= playerDigimon2.stats.skill1Cost;
                player2SPSlider.value = playerDigimon2.currentSP;

                videoPlayer.clip = freezingBreath;
                videoPlayer.Play();

                if (attackingEnemy1)
                {
                    Debug.Log($"{playerDigimon2.stats.digimonName} uses {playerDigimon2.stats.skill1Name} on {enemyDigimon1.stats.digimonName}!");

                    yield return new WaitForSeconds(2f);

                    videoPlayer.Stop();

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else if (attackingEnemy2)
                {
                    Debug.Log($"{playerDigimon2.stats.digimonName} uses {playerDigimon2.stats.skill1Name} on {enemyDigimon2.stats.digimonName}!");

                    yield return new WaitForSeconds(2f);

                    videoPlayer.Stop();

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                if (attackingEnemy3)
                {
                    Debug.Log($"{playerDigimon2.stats.digimonName} uses {playerDigimon2.stats.skill1Name} on {enemyDigimon3.stats.digimonName}!");

                    yield return new WaitForSeconds(2f);

                    videoPlayer.Stop();

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }

                videoPlayer.Stop();
            }
            else if (onSkillButton == 2)
            {
                playerDigimon2.currentSP -= playerDigimon2.stats.skill2Cost;
                player2SPSlider.value = playerDigimon2.currentSP;

                Debug.Log($"{playerDigimon2.stats.digimonName} uses {playerDigimon2.stats.skill2Name}");

                if (spawnedEnemy1)
                {
                    attackingEnemy1 = true;
                }
                if (spawnedEnemy2)
                {
                    attackingEnemy2 = true;
                }
                if (spawnedEnemy1)
                {
                    attackingEnemy3 = true;
                }

                videoPlayer.clip = IceWolfClaw;
                videoPlayer.Play();

                yield return new WaitForSeconds(2f);

                videoPlayer.Stop();

                DamageCalculation();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }
            //else
            //{
            //    playerDigimon1.currentSP -= playerDigimon1.stats.skill3Cost;
            //}
        }

        yield return new WaitForSeconds(1f);

        damageToEnemy1Text.text = "";
        damageToEnemy2Text.text = "";
        damageToEnemy3Text.text = "";

        state = BattleState.PlayerEndTurn;
    }

    public void PlayerEndTurn()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / playerUiDuration);

        if (playerDigimon1Turn)
        {
            player1UI.transform.position = Vector3.Lerp(player1UI.transform.position, p1UiStartPosition, t);

            if (t >= 1f)
            {
                p1UiUp = false;
                elapsedTime = 0;

                // End Turn
                usingAttack = false;
                targetingAlly1 = false;
                targetingAlly2 = false;
                attackingEnemy1 = false;
                attackingEnemy2 = false;
                attackingEnemy3 = false;
                playerDigimon1Turn = false;
                playerTurnStarted = false;

                // Places Digimon to back of the turn que
                digimonOnField.RemoveAt(0);
            }
        }
        else if (playerDigimon2Turn)
        {
            player2UI.transform.position = Vector3.Lerp(player2UI.transform.position, p2UiStartPosition, t);

            if (t >= 1f)
            {
                p2UiUp = false;
                elapsedTime = 0;

                // End Turn
                usingAttack = false;
                targetingAlly1 = false;
                targetingAlly2 = false;
                attackingEnemy1 = false;
                attackingEnemy2 = false;
                attackingEnemy3 = false;
                playerDigimon2Turn = false;
                playerTurnStarted = false;

                // Places Digimon to back of the turn que
                digimonOnField.RemoveAt(0);
            }
        }

        enemy1HPBar.SetActive(false);
        enemy2HPBar.SetActive(false);
        enemy3HPBar.SetActive(false);

        if (enemyDigimonList.Count == 0)
        {
            state = BattleState.Won;
            StartCoroutine(EndBattle());
        }

        if (!p1UiUp && !p2UiUp && enemyDigimonList.Count > 0)
        {
            TurnCheck();
        }
    }

    IEnumerator EnemyTurn()
    {
        enemyTurn = true;

        int enemyActionIndex = Random.Range(0, 3);

        if (enemyActionIndex == 0)
        {
            enemyAttacking = true;
        }
        else if (enemyActionIndex == 1)
        {
            enemyUsingSkill = true;
        }
        else if (enemyActionIndex == 2)
        {
            enemyGuarding = true;
        }

        if (enemyAttacking)
        {
            StartCoroutine(EnemyAttack());
            enemyAttacking = false;
        }
        else if (enemyUsingSkill)
        {
            if (enemyUsingSkill)
            {
                StartCoroutine(EnemySkill());
                enemyUsingSkill = false;
            }
        }
        else if (enemyGuarding)
        {
            if (enemyDigimon1Turn)
            {
                enemyDigimon1.guarding = true;
                enemy1Shield.SetActive(true);
                Debug.Log($"{enemyDigimon1.stats.digimonName} is guarding.");

                yield return new WaitForSeconds(1f);

                // Places Digimon to back of the turn que
                digimonOnField.RemoveAt(0);
                enemyTurn = false;
                enemyDigimon1Turn = false;
                TurnCheck();
            }
            else if (enemyDigimon2Turn)
            {
                enemyDigimon2.guarding = true;
                enemy2Shield.SetActive(true);
                Debug.Log($"{enemyDigimon2.stats.digimonName} is guarding.");

                yield return new WaitForSeconds(1f);

                // Places Digimon to back of the turn que
                digimonOnField.RemoveAt(0);
                enemyTurn = false;
                enemyDigimon2Turn = false;
                TurnCheck();
            }
            else if (enemyDigimon3Turn)
            {
                enemyDigimon3.guarding = true;
                enemy3Shield.SetActive(true);
                Debug.Log($"{enemyDigimon3.stats.digimonName} is guarding.");

                yield return new WaitForSeconds(1f);

                // Places Digimon to back of the turn que
                digimonOnField.RemoveAt(0);
                enemyTurn = false;
                enemyDigimon3Turn = false;
                TurnCheck();
            }
        }
    }

    IEnumerator EnemyAttack()
    {
        if (enemyDigimon1Turn)
        {
            int randomTarget = Random.Range(1, allyDigimonAlive.Count + 1);

            if (randomTarget == 1)
            {
                if (playerDigimon1.alive)
                {
                    enemyTargetDigimon = 1;
                    enemyAttackingP1 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon1.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else
                {
                    enemyTargetDigimon = 2;
                    enemyAttackingP2 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon2.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
            }
            else if (randomTarget == 2)
            {
                if (playerDigimon2.alive)
                {
                    enemyTargetDigimon = 2;
                    enemyAttackingP2 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon2.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else
                {
                    enemyTargetDigimon = 1;
                    enemyAttackingP1 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon1.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }

            }
        }
        else if (enemyDigimon2Turn)
        {
            int randomTarget = Random.Range(1, allyDigimonList.Count + 1);

            if (randomTarget == 1)
            {
                if (playerDigimon1.alive)
                {
                    enemyTargetDigimon = 1;
                    enemyAttackingP1 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon1.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else
                {
                    enemyTargetDigimon = 2;
                    enemyAttackingP2 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon2.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
            }
            else if (randomTarget == 2)
            {
                if (playerDigimon2.alive)
                {
                    enemyTargetDigimon = 2;
                    enemyAttackingP2 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon2.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else
                {
                    enemyTargetDigimon = 1;
                    enemyAttackingP1 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon1.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
            }
        }
        else if (enemyDigimon3Turn)
        {
            int randomTarget = Random.Range(1, allyDigimonList.Count + 1);

            if (randomTarget == 1)
            {
                if (playerDigimon1.alive)
                {
                    enemyTargetDigimon = 1;
                    enemyAttackingP1 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon1.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else
                {
                    enemyTargetDigimon = 2;
                    enemyAttackingP2 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon2.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
            }
            else if (randomTarget == 2)
            {
                if (playerDigimon2.alive)
                {
                    enemyTargetDigimon = 2;
                    enemyAttackingP2 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon2.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
                else
                {
                    enemyTargetDigimon = 1;
                    enemyAttackingP1 = true;
                    Debug.Log($"{enemyDigimon1.stats.digimonName} attacks {playerDigimon1.stats.digimonName}!");
                    enemyUsingAttack = true;

                    yield return new WaitForSeconds(0.5f);

                    DamageCalculation();

                    audioSource.PlayOneShot(hit);
                    damageDealt = true;
                }
            }
        }

        yield return new WaitForSeconds(1f);

        damageToPlayer1Text.text = "";
        damageToPlayer2Text.text = "";

        enemyAttackingP1 = false;
        enemyAttackingP2 = false;

        enemyUsingAttack = false;

        // Places Digimon to back of the turn que
        digimonOnField.RemoveAt(0);
        enemyDigimon1Turn = false;
        enemyDigimon2Turn = false;
        enemyDigimon3Turn = false;
        enemyTurn = false;
        TurnCheck();
    }

    IEnumerator EnemySkill()
    {
        if (enemyDigimon1Turn)
        {
            if (enemyDigimon1.stats.digimonName == "Machinedramon")
            {
                Debug.Log("Machinedramon uses Infinity Cannon!");

                videoPlayer.clip = infinityCannon;
                videoPlayer.Play();

                yield return new WaitForSeconds(1.5f);

                videoPlayer.Stop();

                enemyDigimon1.InfinityCannon();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon1.stats.digimonName == "Myotismon")
            {
                Debug.Log("Myotismon uses Night Raid!");

                videoPlayer.clip = nightRaid;
                videoPlayer.Play();

                yield return new WaitForSeconds(1.5f);

                videoPlayer.Stop();

                enemyDigimon1.NightRaid();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon1.stats.digimonName == "Whamon")
            {
                Debug.Log("Whamon uses Tidal Wave!");

                videoPlayer.clip = tidalWave;
                videoPlayer.Play();

                yield return new WaitForSeconds(3f);

                videoPlayer.Stop();

                enemyDigimon1.TidalWave();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon1.stats.digimonName == "Dragomon")
            {
                int randomTarget = Random.Range(1, allyDigimonAlive.Count + 1);

                if (randomTarget == 1)
                {
                    if (playerDigimon1.alive)
                    {
                        enemyTargetDigimon = 1;
                        enemyAttackingP1 = true;

                    }
                    else
                    {
                        enemyTargetDigimon = 2;
                        enemyAttackingP2 = true;
                    }
                }
                else if (randomTarget == 2)
                {
                    if (playerDigimon2.alive)
                    {
                        enemyTargetDigimon = 2;
                        enemyAttackingP2 = true;
                    }
                    else
                    {
                        enemyTargetDigimon = 1;
                        enemyAttackingP1 = true;
                    }
                }

                Debug.Log("Dragomon uses Forbidden Trident!");

                videoPlayer.clip = forbiddenTrident;
                videoPlayer.Play();

                yield return new WaitForSeconds(2.5f);

                videoPlayer.Stop();

                enemyDigimon1.ForbiddenTrident();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            enemyDigimon1Turn = false;
        }
        else if (enemyDigimon2Turn)
        {
            if (enemyDigimon2.stats.digimonName == "Machinedramon")
            {
                Debug.Log("Machinedramon uses Infinity Cannon!");

                videoPlayer.clip = infinityCannon;
                videoPlayer.Play();

                yield return new WaitForSeconds(1.5f);

                videoPlayer.Stop();

                enemyDigimon2.InfinityCannon();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon2.stats.digimonName == "Myotismon")
            {
                Debug.Log("Myotismon uses Night Raid!");

                videoPlayer.clip = nightRaid;
                videoPlayer.Play();

                yield return new WaitForSeconds(1.5f);

                videoPlayer.Stop();

                enemyDigimon2.NightRaid();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon2.stats.digimonName == "Whamon")
            {
                Debug.Log("Whamon uses Tidal Wave!");

                videoPlayer.clip = tidalWave;
                videoPlayer.Play();

                yield return new WaitForSeconds(3f);

                videoPlayer.Stop();

                enemyDigimon2.TidalWave();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon2.stats.digimonName == "Dragomon")
            {
                int randomTarget = Random.Range(1, allyDigimonAlive.Count + 1);

                if (randomTarget == 1)
                {
                    if (playerDigimon1.alive)
                    {
                        enemyTargetDigimon = 1;
                        enemyAttackingP1 = true;

                    }
                    else
                    {
                        enemyTargetDigimon = 2;
                        enemyAttackingP2 = true;
                    }
                }
                else if (randomTarget == 2)
                {
                    if (playerDigimon2.alive)
                    {
                        enemyTargetDigimon = 2;
                        enemyAttackingP2 = true;
                    }
                    else
                    {
                        enemyTargetDigimon = 1;
                        enemyAttackingP1 = true;
                    }
                }

                Debug.Log("Dragomon uses Forbidden Trident!");

                videoPlayer.clip = forbiddenTrident;
                videoPlayer.Play();

                yield return new WaitForSeconds(2.5f);

                videoPlayer.Stop();

                enemyDigimon2.ForbiddenTrident();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            enemyDigimon2Turn = false;
        }
        else if (enemyDigimon3Turn)
        {
            if (enemyDigimon3.stats.digimonName == "Machinedramon")
            {
                Debug.Log("Machinedramon uses Infinity Cannon!");

                videoPlayer.clip = infinityCannon;
                videoPlayer.Play();

                yield return new WaitForSeconds(1.5f);

                videoPlayer.Stop();

                enemyDigimon3.InfinityCannon();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon3.stats.digimonName == "Myotismon")
            {
                Debug.Log("Myotismon uses Night Raid!");

                videoPlayer.clip = nightRaid;
                videoPlayer.Play();

                yield return new WaitForSeconds(1.5f);

                videoPlayer.Stop();

                enemyDigimon3.NightRaid();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon3.stats.digimonName == "Whamon")
            {
                Debug.Log("Whamon uses Tidal Wave!");

                videoPlayer.clip = tidalWave;
                videoPlayer.Play();

                yield return new WaitForSeconds(3f);

                videoPlayer.Stop();

                enemyDigimon3.TidalWave();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            if (enemyDigimon3.stats.digimonName == "Dragomon")
            {
                int randomTarget = Random.Range(1, allyDigimonAlive.Count + 1);

                if (randomTarget == 1)
                {
                    if (playerDigimon1.alive)
                    {
                        enemyTargetDigimon = 1;
                        enemyAttackingP1 = true;

                    }
                    else
                    {
                        enemyTargetDigimon = 2;
                        enemyAttackingP2 = true;
                    }
                }
                else if (randomTarget == 2)
                {
                    if (playerDigimon2.alive)
                    {
                        enemyTargetDigimon = 2;
                        enemyAttackingP2 = true;
                    }
                    else
                    {
                        enemyTargetDigimon = 1;
                        enemyAttackingP1 = true;
                    }
                }

                Debug.Log("Dragomon uses Forbidden Trident!");

                videoPlayer.clip = forbiddenTrident;
                videoPlayer.Play();

                yield return new WaitForSeconds(2.5f);

                videoPlayer.Stop();

                enemyDigimon3.ForbiddenTrident();

                audioSource.PlayOneShot(hit);
                damageDealt = true;
            }

            enemyDigimon3Turn = false;
        }

        if (playerDigimon1.currentHP < 0)
        {
            playerDigimon1.currentHP = 0;
            player1HPSlider.value = playerDigimon1.currentHP;
            spawnedAlly1.GetComponent<SpriteRenderer>().color = Color.gray;
            playerDigimon1.alive = false;
            allyDigimonAlive.Remove(spawnedAlly1);
        }
        if (playerDigimon2.currentHP < 0)
        {
            playerDigimon2.currentHP = 0;
            player2HPSlider.value = playerDigimon2.currentHP;
            spawnedAlly2.GetComponent<SpriteRenderer>().color = Color.gray;
            playerDigimon2.alive = false;
            allyDigimonAlive.Remove(spawnedAlly2);
        }

        player1HPSlider.value = playerDigimon1.currentHP;
        player2HPSlider.value = playerDigimon2.currentHP;

        yield return new WaitForSeconds(1f);

        damageToPlayer1Text.text = "";
        damageToPlayer2Text.text = "";

        enemyAttackingP1 = false;
        enemyAttackingP2 = false;

        // Places Digimon to back of the turn que
        digimonOnField.RemoveAt(0);
        enemyTurn = false;
        TurnCheck();
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
        // Player Turn
        if (state == BattleState.PlayerTurn)
        {
            if (playerDigimon1Turn)
            {
                if (usingAttack)
                {
                    if (attackingEnemy1)
                    {
                        int damageDone = (playerDigimon1.currentATK * 50) / enemyDigimon1.currentDEF;

                        if (enemyDigimon1.guarding)
                        {
                            damageDone /= 2;
                        }

                        Debug.Log($"{enemyDigimon1.stats.digimonName} 1 takes {damageDone} damage");

                        enemyDigimon1.currentHP -= damageDone;
                        //enemyDigimon1.currentHP -= 1000000000;
                        enemy1HPSlider.value = enemyDigimon1.currentHP;

                        damageToEnemy1Text.text = damageDone.ToString();
                    }
                    else if (attackingEnemy2)
                    {
                        int damageDone = (playerDigimon1.currentATK * 50) / enemyDigimon2.currentDEF;

                        if (enemyDigimon2.guarding)
                        {
                            damageDone /= 2;
                        }

                        Debug.Log($"{enemyDigimon2.stats.digimonName} 2 takes {damageDone} damage");

                        enemyDigimon2.currentHP -= damageDone;
                        //enemyDigimon2.currentHP -= 1000000000;
                        enemy2HPSlider.value = enemyDigimon2.currentHP;

                        damageToEnemy2Text.text = damageDone.ToString();
                    }
                    else if (attackingEnemy3)
                    {
                        int damageDone = (playerDigimon1.currentATK * 50) / enemyDigimon3.currentDEF;

                        if (enemyDigimon3.guarding)
                        {
                            damageDone /= 2;
                        }

                        Debug.Log($"{enemyDigimon3.stats.digimonName} takes {damageDone} damage");

                        enemyDigimon3.currentHP -= damageDone;
                        //enemyDigimon3.currentHP -= 1000000000;
                        enemy3HPSlider.value = enemyDigimon3.currentHP;

                        damageToEnemy3Text.text = damageDone.ToString();
                    }
                }
                else if (usingSkill)
                {
                    if (onSkillButton == 1)
                    {
                        playerDigimon1.TerraForce();
                    }
                    else if (onSkillButton == 2)
                    {
                        playerDigimon1.GreatTornado();
                    }
                    else
                    {
                        // Skill 3 Code
                    }
                }
            }
            else if (playerDigimon2Turn)
            {
                if (usingAttack)
                {
                    if (attackingEnemy1)
                    {
                        int damageDone = (playerDigimon2.currentATK * 50) / enemyDigimon1.currentDEF;

                        if (enemyDigimon1.guarding)
                        {
                            damageDone /= 2;
                        }

                        Debug.Log($"{enemyDigimon1.stats.digimonName} takes {damageDone} damage");

                        enemyDigimon1.currentHP -= damageDone;
                        //enemyDigimon1.currentHP -= 1000000000;
                        enemy1HPSlider.value = enemyDigimon1.currentHP;

                        damageToEnemy1Text.text = damageDone.ToString();
                    }
                    else if (attackingEnemy2)
                    {
                        int damageDone = (playerDigimon2.currentATK * 50) / enemyDigimon2.currentDEF;

                        if (enemyDigimon2.guarding)
                        {
                            damageDone /= 2;
                        }

                        Debug.Log($"{enemyDigimon2.stats.digimonName} takes {damageDone} damage");

                        enemyDigimon2.currentHP -= damageDone;
                        //enemyDigimon2.currentHP -= 1000000000;
                        enemy2HPSlider.value = enemyDigimon2.currentHP;
                        damageToEnemy2Text.text = damageDone.ToString();
                    }
                    else if (attackingEnemy3)
                    {
                        int damageDone = (playerDigimon2.currentATK * 50) / enemyDigimon3.stats.def;

                        if (enemyDigimon3.guarding)
                        {
                            damageDone /= 2;
                        }

                        Debug.Log($"{enemyDigimon3.stats.digimonName} takes {damageDone} damage");

                        enemyDigimon3.currentHP -= damageDone;
                        //enemyDigimon3.currentHP -= 1000000000;
                        enemy3HPSlider.value = enemyDigimon3.currentHP;
                        damageToEnemy3Text.text = damageDone.ToString();
                    }
                }
                else if (usingSkill)
                {
                    if (onSkillButton == 1)
                    {
                        playerDigimon2.FreezingBreath();
                    }
                    else if (onSkillButton == 2)
                    {
                        playerDigimon2.IceWolfClaw();
                    }
                    else
                    {
                        // Skill 3 Code
                    }
                }
            }

            if (enemyDigimon1)
            {
                if (enemyDigimon1.currentHP < 0)
                {
                    enemyDigimon1.currentHP = 0;
                    digimonOnField.Remove(spawnedEnemy1);
                    enemyDigimonList.Remove(spawnedEnemy1);
                    Destroy(spawnedEnemy1);
                }
            }
            if (enemyDigimon2)
            {
                if (enemyDigimon2.currentHP < 0)
                {
                    enemyDigimon2.currentHP = 0;
                    digimonOnField.Remove(spawnedEnemy2);
                    enemyDigimonList.Remove(spawnedEnemy2);
                    Destroy(spawnedEnemy2);
                }
            }
            if (enemyDigimon3)
            {
                if (enemyDigimon3.currentHP < 0)
                {
                    enemyDigimon3.currentHP = 0;
                    digimonOnField.Remove(spawnedEnemy3);
                    Destroy(spawnedEnemy3);
                }
            }
        }
        // Enemy Turn
        else
        {
            if (enemyDigimon1Turn)
            {
                if (enemyTargetDigimon == 1)
                {
                    int damageDone = (enemyDigimon1.currentATK * 50) / playerDigimon1.currentDEF;

                    if (playerDigimon1.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{playerDigimon1.stats.digimonName} takes {damageDone} damage");

                    playerDigimon1.currentHP -= damageDone;
                    //playerDigimon1.currentHP -= 1000000000;
                    player1HPSlider.value = playerDigimon1.currentHP;
                    damageToPlayer1Text.text = damageDone.ToString();

                    Debug.Log($"{playerDigimon1.stats.digimonName} has {playerDigimon1.currentHP} HP remaining!");
                    enemyDigimon1Turn = false;
                    //enemyAttacking = false;
                }
                else if (enemyTargetDigimon == 2)
                {
                    int damageDone = (enemyDigimon1.currentATK * 50) / playerDigimon2.currentDEF;

                    if (playerDigimon2.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{playerDigimon2.stats.digimonName} takes {damageDone} damage");

                    playerDigimon2.currentHP -= damageDone;
                    player2HPSlider.value = playerDigimon2.currentHP;
                    //playerDigimon2.currentHP -= 1000000000;
                    damageToPlayer2Text.text = damageDone.ToString();

                    Debug.Log($"{playerDigimon2.stats.digimonName} has {playerDigimon2.currentHP} HP remaining!");
                    enemyDigimon1Turn = false;
                    //enemyAttacking = false;
                }
            }
            else if (enemyDigimon2Turn)
            {
                if (enemyTargetDigimon == 1)
                {
                    int damageDone = (enemyDigimon2.currentATK * 50) / playerDigimon1.currentDEF;

                    if (playerDigimon1.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{playerDigimon1.stats.digimonName} takes {damageDone} damage");

                    playerDigimon1.currentHP -= damageDone;
                    player1HPSlider.value = playerDigimon1.currentHP;
                    //playerDigimon1.stats.currentHP -= 1000000000;
                    damageToPlayer1Text.text = damageDone.ToString();

                    Debug.Log($"{playerDigimon1.stats.digimonName} has {playerDigimon1.currentHP} HP remaining!");
                    enemyDigimon2Turn = false;
                    //enemyAttacking = false;
                }
                else if (enemyTargetDigimon == 2)
                {
                    int damageDone = (enemyDigimon2.currentATK * 50) / playerDigimon2.currentDEF;

                    if (playerDigimon2.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{playerDigimon2.stats.digimonName} takes {damageDone} damage");

                    playerDigimon2.currentHP -= damageDone;
                    player2HPSlider.value = playerDigimon2.currentHP;
                    //playerDigimon1.stats.currentHP -= 1000000000;
                    damageToPlayer2Text.text = damageDone.ToString();

                    Debug.Log($"{playerDigimon2.stats.digimonName} has {playerDigimon2.currentHP} HP remaining!");
                    enemyDigimon1Turn = false;
                    //enemyAttacking = false;
                }
            }
            else if (enemyDigimon3Turn)
            {
                if (enemyTargetDigimon == 1)
                {
                    int damageDone = (enemyDigimon3.currentATK * 50) / playerDigimon1.currentDEF;

                    if (playerDigimon1.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{playerDigimon1.stats.digimonName} takes {damageDone} damage");

                    playerDigimon1.currentHP -= damageDone;
                    player1HPSlider.value = playerDigimon1.currentHP;
                    damageToPlayer1Text.text = damageDone.ToString();
                    //playerDigimon1.stats.currentHP -= 1000000000;

                    Debug.Log($"{playerDigimon1.stats.digimonName} has {playerDigimon1.currentHP} HP remaining!");
                    enemyDigimon3Turn = false;
                    //enemyAttacking = false;
                }
                else if (enemyTargetDigimon == 2)
                {
                    int damageDone = (enemyDigimon3.currentATK * 50) / playerDigimon2.currentDEF;

                    if (playerDigimon2.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{playerDigimon2.stats.digimonName} takes {damageDone} damage");

                    playerDigimon2.currentHP -= damageDone;
                    player2HPSlider.value = playerDigimon2.currentHP;
                    damageToPlayer2Text.text = damageDone.ToString();
                    //playerDigimon1.stats.currentHP -= 1000000000;

                    Debug.Log($"{playerDigimon2.stats.digimonName} has {playerDigimon2.currentHP} HP remaining!");
                    enemyDigimon1Turn = false;
                    //enemyAttacking = false;
                }
            }

            if (playerDigimon1.currentHP < 0)
            {
                playerDigimon1.currentHP = 0;
                player1HPSlider.value = playerDigimon1.currentHP;
                spawnedAlly1.GetComponent<SpriteRenderer>().color = Color.gray;
                playerDigimon1.alive = false;
                allyDigimonAlive.Remove(spawnedAlly1);
            }
            if (playerDigimon2.currentHP < 0)
            {
                playerDigimon2.currentHP = 0;
                player2HPSlider.value = playerDigimon2.currentHP;
                spawnedAlly2.GetComponent<SpriteRenderer>().color = Color.gray;
                playerDigimon2.alive = false;
                allyDigimonAlive.Remove(spawnedAlly2);
            }

            player1HPSlider.value = playerDigimon1.currentHP;
            player2HPSlider.value = playerDigimon2.currentHP;
        }
    }

    void SpawnDigimon()
    {
        // Ally Digimon
        if (allyPrefabs.Length == 0) return;

        for (int i = 0; i < allyPrefabs.Length; i++)
        {
            GameObject playerDigimon = allyPrefabs[i];

            if (i == 0)
            {
                spawnedAlly1 = Instantiate(playerDigimon, playerDigimonSpawnPoint[i].position, Quaternion.identity);
                playerDigimon1 = spawnedAlly1.GetComponent<Ally>();
                playerDigimon1.currentHP = playerDigimon1.stats.hp;
                playerDigimon1.currentSP = playerDigimon1.stats.sp;
                playerDigimon1.currentSPD = playerDigimon1.stats.spd;
                player1HPSlider.maxValue = playerDigimon1.stats.hp;
                player1HPSlider.value = playerDigimon1.currentHP;
                player1SPSlider.maxValue = playerDigimon1.stats.sp;
                player1SPSlider.value = playerDigimon1.currentSP;
                spawnedAlly1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                spawnedAlly1.tag = "Player1";
                player1StartPos = spawnedAlly1.transform.position;

                digimonOnField.Add(spawnedAlly1);
                allyDigimonList.Add(spawnedAlly1);
                allyDigimonAlive.Add(spawnedAlly1);
            }
            else if (i == 1)
            {
                spawnedAlly2 = Instantiate(playerDigimon, playerDigimonSpawnPoint[i].position, Quaternion.identity);
                playerDigimon2 = spawnedAlly2.GetComponent<Ally>();
                playerDigimon2.currentHP = playerDigimon2.stats.hp;
                playerDigimon2.currentSP = playerDigimon2.stats.sp;
                playerDigimon2.currentSPD = playerDigimon2.stats.spd;
                player2HPSlider.maxValue = playerDigimon2.stats.hp;
                player2HPSlider.value = playerDigimon2.currentHP;
                player2SPSlider.maxValue = playerDigimon2.stats.sp;
                player2SPSlider.value = playerDigimon2.currentSP;
                spawnedAlly1.GetComponent<SpriteRenderer>().sortingOrder = 2;
                spawnedAlly2.tag = "Player2";
                player2StartPos = spawnedAlly2.transform.position;

                digimonOnField.Add(spawnedAlly2);
                allyDigimonList.Add(spawnedAlly2);
                allyDigimonAlive.Add(spawnedAlly2);
            }
        }

        // Enemy Digimon
        if (enemyPrefabs.Length == 0) return;

        enemiesSpawned = Random.Range(1, 4);
        //enemiesSpawned = 3;

        for (int i = 0; i < enemiesSpawned; i++)
        {
            // Grabs an enemy from random
            int index = Random.Range(0, enemyPrefabs.Length);
            //int index = 0;
            GameObject enemyDigimon = enemyPrefabs[index];

            if (i == 0)
            {
                // Spawns the enemy
                spawnedEnemy1 = Instantiate(enemyDigimon, enemySpawnPoint[i].position, Quaternion.identity);
                enemyDigimon1 = spawnedEnemy1.GetComponent<Enemy>();
                enemyDigimon1.currentHP = enemyDigimon1.stats.hp;
                enemyDigimon1.currentSPD = enemyDigimon1.stats.spd;
                enemy1HPSlider.maxValue = enemyDigimon1.stats.hp;
                enemy1HPSlider.value = enemyDigimon1.currentHP;
                spawnedEnemy1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                spawnedEnemy1.tag = "Enemy1";
                enemy1StartPos = spawnedEnemy1.transform.position;

                digimonOnField.Add(spawnedEnemy1);
                enemyDigimonList.Add(spawnedEnemy1);
            }
            else if (i == 1)
            {
                // Spawns the enemy
                spawnedEnemy2 = Instantiate(enemyDigimon, enemySpawnPoint[i].position, Quaternion.identity);
                enemyDigimon2 = spawnedEnemy2.GetComponent<Enemy>();
                enemyDigimon2.currentHP = enemyDigimon2.stats.hp;
                enemyDigimon2.currentSPD = enemyDigimon2.stats.spd;
                enemy2HPSlider.maxValue = enemyDigimon2.stats.hp;
                enemy2HPSlider.value = enemyDigimon2.currentHP;
                spawnedEnemy2.GetComponent<SpriteRenderer>().sortingOrder = 2;
                spawnedEnemy2.tag = "Enemy2";
                enemy2StartPos = spawnedEnemy2.transform.position;

                digimonOnField.Add(spawnedEnemy2);
                enemyDigimonList.Add(spawnedEnemy2);
            }
            if (i == 2)
            {
                // Spawns the enemy
                spawnedEnemy3 = Instantiate(enemyDigimon, enemySpawnPoint[i].position, Quaternion.identity);
                enemyDigimon3 = spawnedEnemy3.GetComponent<Enemy>();
                enemyDigimon3.currentHP = enemyDigimon3.stats.hp;
                enemyDigimon3.currentSPD = enemyDigimon3.stats.spd;
                enemy3HPSlider.maxValue = enemyDigimon3.stats.hp;
                enemy3HPSlider.value = enemyDigimon3.currentHP;
                spawnedEnemy3.GetComponent<SpriteRenderer>().sortingOrder = 3;
                spawnedEnemy3.tag = "Enemy3";
                enemy3StartPos = spawnedEnemy3.transform.position;

                digimonOnField.Add(spawnedEnemy3);
                enemyDigimonList.Add(spawnedEnemy3);
            }
        }
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
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 1;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 3;
            }

            // Changes to Target State
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(selectButton);
                image.color = Color.white;
                multiTarget = false;
                usingAttack = true;
                targetingEnemy = true;
                uiState = UIState.Target;
            }
        }
        // If on Skill Button
        else if (onButton == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 0;
            }

            // Changes to Skills State
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(selectButton);
                image.color = Color.white;
                uiState = UIState.Skills;
            } 
        }
        // If on Guard Button
        else if (onButton == 2)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 0;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 1;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 3;
            }

            // Digimon Guards
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(selectButton);
                image.color = Color.white;
                if (playerDigimon1Turn)
                {
                    playerDigimon1.guarding = true;
                    player1Shield.SetActive(true);
                    Debug.Log($"{playerDigimon1.stats.name} is guarding.");
                }
                else if (playerDigimon2Turn)
                {
                    playerDigimon2.guarding = true;
                    player2Shield.SetActive(true);
                    Debug.Log($"{playerDigimon2.stats.name} is guarding.");
                }
                
                uiState = UIState.Waiting;
                state = BattleState.PlayerEndTurn;
            }
        }
        // If on Item Button
        else if (onButton == 3)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 2;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onButton = 0;
            }

            // Changes to Items State
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(selectButton);
                image.color = Color.white;
                uiState = UIState.Items;
            }
        }
    }

    public void ItemsUI()
    {
        float offset = 0.3f;

        if (!itemMenuUp)
        {
            rootUI.SetActive(true);
            itemUI.SetActive(true);
            itemMenuUp = true;

            Vector2 currentPos = itemSelectorBox.transform.position;
            float yValue = itemUIButtons[onItemButton - 1].transform.position.y + offset;
            Vector2 newPos = new Vector2(currentPos.x, yValue);
            itemSelectorBox.transform.position = newPos;
        }

        // UI Navigation
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onItemButton > 1)
            {
                onItemButton--;
                audioSource.PlayOneShot(moveButtons);
            }

            Vector2 currentPos = itemSelectorBox.transform.position;
            float yValue = itemUIButtons[onItemButton - 1].transform.position.y + offset;
            Vector2 newPos = new Vector2(currentPos.x, yValue);
            itemSelectorBox.transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (onItemButton < itemUIButtons.Length)
            {
                onItemButton++;
                audioSource.PlayOneShot(moveButtons);
            }

            Vector2 currentPos = itemSelectorBox.transform.position;
            float yValue = itemUIButtons[onItemButton - 1].transform.position.y + offset;
            Vector2 newPos = new Vector2(currentPos.x, yValue);
            itemSelectorBox.transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
        {
            if (onItemButton == 1)
            {
                if (hpCapsuleAmount > 0)
                {
                    audioSource.PlayOneShot(selectButton);
                    onAlly = 1;
                    targetingAlly = true;
                    targetingForItem = true;
                    uiState = UIState.Target;
                    rootUI.SetActive(false);
                    itemUI.SetActive(false);
                    itemMenuUp = false;
                }
                else
                {
                    Debug.Log("You don't have any!");
                }
            }
            else if (onItemButton == 2)
            {
                if (spCapsuleAmount > 0)
                {
                    audioSource.PlayOneShot(selectButton);
                    onAlly = 1;
                    targetingAlly = true;
                    targetingForItem = true;
                    uiState = UIState.Target;
                    rootUI.SetActive(false);
                    itemUI.SetActive(false);
                    itemMenuUp = false;
                }
                else
                {
                    Debug.Log("You don't have any!");
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Backspace))
        {
            audioSource.PlayOneShot(backButton);
            itemUI.SetActive(false);
            itemMenuUp = false;
            uiState = UIState.Root;
        }

        if (onItemButton == 1)
        {
            itemDescriptionText.text = "Restores 750 HP for one ally.";
        }
        else if (onItemButton == 2)
        {
            itemDescriptionText.text = "Restores 90 SP for one ally.";
        }

        hpCapsuleAmountText.text = "x     " + hpCapsuleAmount.ToString();
        spCapsuleAmountText.text = "x     " + spCapsuleAmount.ToString();

    }

    IEnumerator Item()
    {
        if (onItemButton == 1)
        {
            if (targetingAlly1)
            {
                Debug.Log("Player used Hp Capsule on Wargreymon!");

                yield return new WaitForSeconds(1f);

                playerHealing = true;
                healtoPlayer1Text.text = "750";
                playerDigimon1.currentHP += 750;
                audioSource.PlayOneShot(heal);

                if (playerDigimon1.currentHP > playerDigimon1.stats.hp)
                {
                    playerDigimon1.currentHP = playerDigimon1.stats.hp;
                }

                player1HPSlider.value = playerDigimon1.currentHP;
                hpCapsuleAmount--;
            }
            else if (targetingAlly2)
            {
                Debug.Log("Player used Hp Capsule on Metalgarurumon!");

                yield return new WaitForSeconds(1f);

                playerHealing = true;
                healtoPlayer2Text.text = "750";
                playerDigimon2.currentHP += 750;
                audioSource.PlayOneShot(heal);

                if (playerDigimon2.currentHP > playerDigimon2.stats.hp)
                {
                    playerDigimon2.currentHP = playerDigimon2.stats.hp;
                }

                player2HPSlider.value = playerDigimon2.currentHP;
                hpCapsuleAmount--;
            }
        }
        else if (onItemButton == 2)
        {
            if (targetingAlly1)
            {
                Debug.Log("Player used Sp Capsule on Wargreymon!");

                yield return new WaitForSeconds(1f);

                playerSpGain = true;
                spToPlayer1Text.text = "90";
                playerDigimon1.currentSP += 90;
                audioSource.PlayOneShot(heal);

                if (playerDigimon1.currentSP > playerDigimon1.stats.sp)
                {
                    playerDigimon1.currentSP = playerDigimon1.stats.sp;
                }

                player1SPSlider.value = playerDigimon1.currentSP;
                spCapsuleAmount--;
            }
            else if (targetingAlly2)
            {
                Debug.Log("Player used Sp Capsule on MetalGarurumon!");

                yield return new WaitForSeconds(1f);

                playerSpGain = true;
                spToPlayer2Text.text = "90";
                playerDigimon2.currentSP += 90;
                audioSource.PlayOneShot(heal);

                if (playerDigimon2.currentSP > playerDigimon2.stats.sp)
                {
                    playerDigimon2.currentSP = playerDigimon2.stats.sp;
                }

                player2SPSlider.value = playerDigimon2.currentSP;
                spCapsuleAmount--;
            }

        }

        yield return new WaitForSeconds(1f);

        healtoPlayer1Text.text = "";
        healtoPlayer2Text.text = "";

        spToPlayer1Text.text = "";
        spToPlayer2Text.text = "";

        state = BattleState.PlayerEndTurn;
    }

    void SkillsUI()
    {
        if (playerDigimon1Turn)
        {
            skill1Name.text = playerDigimon1.stats.skill1Name;
            skill1Cost.text = playerDigimon1.stats.skill1Cost.ToString();

            skill2Name.text = playerDigimon1.stats.skill2Name;
            skill2Cost.text = playerDigimon1.stats.skill2Cost.ToString();

            //skill3Name.text = playerDigimon1.stats.skill3Name;
            //skill3Cost.text = playerDigimon1.stats.skill3Cost.ToString();

            if (onSkillButton == 1)
            {
                skillDescriptionText.text = playerDigimon1.stats.skill1Description;
            }
            else if (onSkillButton == 2)
            {
                skillDescriptionText.text = playerDigimon1.stats.skill2Description;
            }
            //else
            //{
            //    skillDescriptionText.text = playerDigimon1.stats.skill3Description;
            //}
        }
        else if (playerDigimon2Turn)
        {
            skill1Name.text = playerDigimon2.stats.skill1Name;
            skill1Cost.text = playerDigimon2.stats.skill1Cost.ToString();

            skill2Name.text = playerDigimon2.stats.skill2Name;
            skill2Cost.text = playerDigimon2.stats.skill2Cost.ToString();

            //skill3Name.text = playerDigimon1.stats.skill3Name;
            //skill3Cost.text = playerDigimon1.stats.skill3Cost.ToString();

            if (onSkillButton == 1)
            {
                skillDescriptionText.text = playerDigimon2.stats.skill1Description;
            }
            else if (onSkillButton == 2)
            {
                skillDescriptionText.text = playerDigimon2.stats.skill2Description;
            }
            //else
            //{
            //    skillDescriptionText.text = playerDigimon1.stats.skill3Description;
            //}
        }

        if (!skillMenuUp)
        {
            rootUI.SetActive(true);
            skillsUI.SetActive(true);
            skillMenuUp = true;
        }

        Image image = skillsUIButtons[onSkillButton - 1].GetComponent<Image>();

        image.color = Color.gray;

        // UI Navigation
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onSkillButton > 1)
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onSkillButton--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (onSkillButton < skillsUIButtons.Length)
            {
                audioSource.PlayOneShot(moveButtons);
                image.color = Color.white;
                onSkillButton++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
        {
            if (playerDigimon1Turn)
            {
                if (onSkillButton == 1)
                {
                    if (playerDigimon1.currentSP > playerDigimon1.stats.skill1Cost)
                    {
                        audioSource.PlayOneShot(selectButton);
                        image.color = Color.white;
                        multiTarget = playerDigimon1.stats.skill1MultiTarget;
                        targetingEnemy = true;
                        usingSkill = true;
                        uiState = UIState.Target;
                        rootUI.SetActive(false);
                        skillsUI.SetActive(false);
                        skillMenuUp = false;
                    }
                    else
                    {
                        Debug.Log("Not Enough SP!");
                    }

                }
                if (onSkillButton == 2)
                {
                    if (playerDigimon1.currentSP > playerDigimon1.stats.skill2Cost)
                    {
                        audioSource.PlayOneShot(selectButton);
                        image.color = Color.white;
                        multiTarget = playerDigimon1.stats.skill2MultiTarget;
                        targetingEnemy = true;
                        usingSkill = true;
                        uiState = UIState.Target;
                        rootUI.SetActive(false);
                        skillsUI.SetActive(false);
                        skillMenuUp = false;
                    }
                    else
                    {
                        Debug.Log("Not Enough SP!");
                    }
                }
                //else if (onSkillButton == 3)
                //{
                //    if (playerDigimon1.currentSP > playerDigimon1.stats.skill3Cost)
                //    {
                //        multiTarget = playerDigimon1.stats.skill3MultiTarget;
                //        targetingEnemy = false;
                //        usingSkill = true;
                //        uiState = UIState.Target;
                //        skillsUI.SetActive(false);
                //        skillMenuUp = false;
                //    }
                //    else
                //    {
                //        Debug.Log("Not Enough SP!");
                //    }
                //}
            }
            else if (playerDigimon2Turn)
            {
                if (onSkillButton == 1)
                {
                    if (playerDigimon2.currentSP > playerDigimon2.stats.skill1Cost)
                    {
                        audioSource.PlayOneShot(selectButton);
                        image.color = Color.white;
                        multiTarget = playerDigimon2.stats.skill1MultiTarget;
                        targetingEnemy = true;
                        usingSkill = true;
                        uiState = UIState.Target;
                        rootUI.SetActive(false);
                        skillsUI.SetActive(false);
                        skillMenuUp = false;
                    }
                    else
                    {
                        Debug.Log("Not Enough SP!");
                    }

                }
                if (onSkillButton == 2)
                {
                    if (playerDigimon2.currentSP > playerDigimon2.stats.skill2Cost)
                    {
                        audioSource.PlayOneShot(selectButton);
                        image.color = Color.white;
                        multiTarget = playerDigimon2.stats.skill2MultiTarget;
                        targetingEnemy = true;
                        usingSkill = true;
                        uiState = UIState.Target;
                        rootUI.SetActive(false);
                        skillsUI.SetActive(false);
                        skillMenuUp = false;
                    }
                    else
                    {
                        Debug.Log("Not Enough SP!");
                    }
                }
                //else if (onSkillButton == 3)
                //{
                //    if (playerDigimon1.currentSP > playerDigimon1.stats.skill3Cost)
                //    {
                //        multiTarget = playerDigimon1.stats.skill3MultiTarget;
                //        targetingEnemy = false;
                //        usingSkill = true;
                //        uiState = UIState.Target;
                //        skillsUI.SetActive(false);
                //        skillMenuUp = false;
                //    }
                //    else
                //    {
                //        Debug.Log("Not Enough SP!");
                //    }
                //}
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Backspace))
        {
            audioSource.PlayOneShot(backButton);
            image.color = Color.white;
            skillsUI.SetActive(false);
            skillMenuUp = false;
            uiState = UIState.Root;
        }
    }

    void Selector()
    {
        float t = Mathf.PingPong(Time.time * indicatorScaleSpeed, 1f);

        if (targetingEnemy)
        {
            if (!multiTarget)
            {
                enemyIndicator1.SetActive(true);

                enemyIndicator1.transform.position = enemyDigimonList[onEnemy - 1].transform.position;
                enemyIndicator1.transform.Rotate(0f, 0f, indicatorRotateSpeed * Time.deltaTime);
                enemyIndicator1.transform.localScale = Vector3.Lerp(indicatorMinScale, indicatorMaxScale, t);

                // For navigating enemies
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (onEnemy > 1)
                    {
                        audioSource.PlayOneShot(moveButtons);
                        onEnemy--;
                    }
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (onEnemy < enemyDigimonList.Count)
                    {
                        audioSource.PlayOneShot(moveButtons);
                        onEnemy++;
                    }
                }


                if (usingAttack)
                {
                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                    {
                        if (enemyDigimonList[onEnemy - 1].tag == "Enemy1")
                        {
                            attackingEnemy1 = true;
                            enemy2HPBar.SetActive(false);
                            enemy3HPBar.SetActive(false);
                        }
                        else if (enemyDigimonList[onEnemy - 1].tag == "Enemy2")
                        {
                            attackingEnemy2 = true;
                            enemy1HPBar.SetActive(false);
                            enemy3HPBar.SetActive(false);
                        }
                        else if (enemyDigimonList[onEnemy - 1].tag == "Enemy3")
                        {
                            attackingEnemy3 = true;
                            enemy1HPBar.SetActive(false);
                            enemy2HPBar.SetActive(false);
                        }

                        audioSource.PlayOneShot(selectButton);
                        enemyIndicator1.SetActive(false);
                        rootUI.SetActive(false);

                        attacking = true;
                        targetingEnemy = false;
                        uiState = UIState.Waiting;


                    }

                    if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Backspace))
                    {
                        enemyIndicator1.SetActive(false);

                        audioSource.PlayOneShot(backButton);
                        usingAttack = false;
                        targetingEnemy = false;
                        uiState = UIState.Root;
                    }
                }
                else if (usingSkill)
                {
                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                    {
                        if (enemyDigimonList[onEnemy - 1].tag == "Enemy1")
                        {
                            attackingEnemy1 = true;
                            enemy2HPBar.SetActive(false);
                            enemy3HPBar.SetActive(false);
                        }
                        else if (enemyDigimonList[onEnemy - 1].tag == "Enemy2")
                        {
                            attackingEnemy2 = true;
                            enemy1HPBar.SetActive(false);
                            enemy3HPBar.SetActive(false);
                        }
                        else if (enemyDigimonList[onEnemy - 1].tag == "Enemy3")
                        {
                            attackingEnemy3 = true;
                            enemy1HPBar.SetActive(false);
                            enemy2HPBar.SetActive(false);
                        }
                        enemyIndicator1.SetActive(false);
                        rootUI.SetActive(false);

                        audioSource.PlayOneShot(selectButton);
                        attacking = true;
                        targetingEnemy = false;
                        uiState = UIState.Waiting;
                    }

                    if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Backspace))
                    {
                        enemyIndicator1.SetActive(false);

                        audioSource.PlayOneShot(backButton);
                        usingSkill = false;
                        targetingEnemy = false;
                        uiState = UIState.Skills;
                    }
                }
            }
            else
            {
                if (enemyDigimon1)
                {
                    enemyIndicator1.SetActive(true);

                    enemyIndicator1.transform.position = enemySpawnPoint[0].position;
                    enemyIndicator1.transform.Rotate(0f, 0f, indicatorRotateSpeed * Time.deltaTime);
                    enemyIndicator1.transform.localScale = Vector3.Lerp(indicatorMinScale, indicatorMaxScale, t);
                }

                if (enemyDigimon2)
                {
                    enemyIndicator2.SetActive(true);

                    enemyIndicator2.transform.position = enemySpawnPoint[1].position;
                    enemyIndicator2.transform.Rotate(0f, 0f, indicatorRotateSpeed * Time.deltaTime);
                    enemyIndicator2.transform.localScale = Vector3.Lerp(indicatorMinScale, indicatorMaxScale, t);
                }

                if (enemyDigimon3)
                {
                    enemyIndicator3.SetActive(true);

                    enemyIndicator3.transform.position = enemySpawnPoint[2].position;
                    enemyIndicator3.transform.Rotate(0f, 0f, indicatorRotateSpeed * Time.deltaTime);
                    enemyIndicator3.transform.localScale = Vector3.Lerp(indicatorMinScale, indicatorMaxScale, t);
                }

                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    enemyIndicator1.SetActive(false);
                    enemyIndicator2.SetActive(false);
                    enemyIndicator3.SetActive(false);
                    rootUI.SetActive(false);

                    audioSource.PlayOneShot(selectButton);
                    attacking = true;
                    targetingEnemy = false;
                    uiState = UIState.Waiting;
                }
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    enemyIndicator1.SetActive(false);
                    enemyIndicator2.SetActive(false);
                    enemyIndicator3.SetActive(false);

                    audioSource.PlayOneShot(backButton);
                    usingSkill = false;
                    targetingEnemy = false;
                    uiState = UIState.Skills;
                }

            }
        }
        else
        {
            if (targetingForItem)
            {
                allyIndicator1.SetActive(true);

                allyIndicator1.transform.position = playerDigimonSpawnPoint[onAlly - 1].position;
                allyIndicator1.transform.Rotate(0f, 0f, indicatorRotateSpeed * Time.deltaTime);
                allyIndicator1.transform.localScale = Vector3.Lerp(indicatorMinScale, indicatorMaxScale, t);

                // For navigating allies
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (onAlly > 1)
                    {
                        audioSource.PlayOneShot(moveButtons);
                        onAlly--;
                    }
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (onAlly < allyDigimonList.Count)
                    {
                        audioSource.PlayOneShot(moveButtons);
                        onAlly++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    if (allyDigimonList[onAlly - 1].tag == "Player1")
                    {
                        targetingAlly1 = true;
                    }
                    else if (allyDigimonList[onAlly - 1].tag == "Player2")
                    {
                        targetingAlly2 = true;
                    }

                    allyIndicator1.SetActive(false);
                    rootUI.SetActive(false);

                    audioSource.PlayOneShot(selectButton);
                    targetingForItem = false;
                    usingItem = true;
                    targetingAlly = false;
                    uiState = UIState.Waiting;
                }
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    allyIndicator1.SetActive(false);
                    rootUI.SetActive(true);
                    itemUI.SetActive(true);

                    audioSource.PlayOneShot(backButton);
                    targetingForItem = false;
                    targetingAlly = false;
                    uiState = UIState.Items;
                }
            }
        }
    }
}
