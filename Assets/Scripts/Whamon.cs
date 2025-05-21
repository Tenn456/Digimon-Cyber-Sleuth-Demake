using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whamon : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyIntro();
    }
    protected override void EnemyIntro()
    {
        base.EnemyIntro();
        Debug.Log($"{stats.digimonName} enters battle with {currentHP} HP.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
