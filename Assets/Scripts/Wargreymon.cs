using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wargreymon : MonoBehaviour
{
    public WargreymonStats stats;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<WargreymonStats>();
        currentHP = stats.hp;
        Debug.Log($"{stats.digimonName} enters battle with {currentHP} HP.");
    }


    public void TakeDamage(int amount)
    {
        int damage = Mathf.Max(amount - stats.def, 1);
        currentHP -= damage;
        Debug.Log($"{stats.digimonName} takes {damage} damage. HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{stats.digimonName} is defeated!");
        Destroy(gameObject); // Or trigger defeat UI
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
