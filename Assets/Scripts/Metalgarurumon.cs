using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metalgarurumon : Ally
{

    // Start is called before the first frame update
    void Start()
    {
        AllyIntro();
    }

    protected override void AllyIntro()
    {
        base.AllyIntro();
        Debug.Log($"{stats.digimonName} enters battle with {currentHP} HP.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
