using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 playerPosition;

    // Example encounter data
    public bool isInBattle = false;
    public string returnSceneName = "Overworld"; // Where to return after battle

    void Awake()
    {
        // Singleton pattern: if one already exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist between scenes
    }

    public void StartBattle(string battleSceneName)
    {
        isInBattle = true;
        playerPosition = GameObject.FindWithTag("Player").transform.position; // Save position
        SceneManager.LoadScene(battleSceneName);
    }

    public void EndBattle()
    {
        isInBattle = false;
        SceneManager.LoadScene(returnSceneName);
    }
}
