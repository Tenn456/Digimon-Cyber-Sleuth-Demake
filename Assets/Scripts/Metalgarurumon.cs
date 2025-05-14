using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metalgarurumon : MonoBehaviour
{
    public MetalGarurumonStats stats;
    public int currentHP;
    public int currentSP;

    public void InitializeStats()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<MetalGarurumonStats>();
        currentHP = stats.hp;
        currentSP = stats.sp;
        Debug.Log($"{stats.digimonName} enters battle with {currentHP} HP.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
