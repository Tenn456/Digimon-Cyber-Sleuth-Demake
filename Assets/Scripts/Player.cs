using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float encounterCheckInterval = 1.0f; // How often to check (in seconds)
    [Range(0f, 1f)] public float encounterChance = 0.4f; // 40% chance per check

    private Rigidbody2D rb;
    private Vector2 movement;

    private float encounterTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isInBattle)
        {
            Movement();
            RandomEncounter();

        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                GameManager.Instance.EndBattle();
                //this.transform.position = GameManager.Instance.playerPosition;
            }
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Movement()
    {
        // Get input from WASD or arrow keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void RandomEncounter()
    {
        // Only check for encounters if player is moving
        if (movement != Vector2.zero)
        {
            encounterTimer += Time.deltaTime;

            if (encounterTimer >= encounterCheckInterval)
            {
                if (Random.value < encounterChance)
                {
                    Debug.Log("Random Encounter!");

                    GameManager.Instance.StartBattle("Battle");
                }
                else
                {
                    encounterTimer = 0f; // Reset timer
                }
            }
        }
        else
        {
            encounterTimer = 0f;
        }
    }
}
