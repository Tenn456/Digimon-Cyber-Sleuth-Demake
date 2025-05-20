using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Stats stats;
    public int currentHP;
    public int currentSP;
    public int currentATK;
    public int currentIntel;
    public int currentDEF;
    public int currentSPD;

    public bool guarding;

    protected virtual void EnemyIntro()
    {
        currentHP = stats.hp;
        currentSP = stats.sp;
        currentATK = stats.atk;
        currentIntel = stats.intel;
        currentDEF = stats.def;
        currentSPD = stats.spd;
    }

    public void InfinityCannon()
    {
        int damageDone;

        if (BattleManager.Instance.playerDigimon1)
        {
            if (Random.value < 0.8f)
            {
                damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.playerDigimon1.currentDEF;

                Debug.Log($"{BattleManager.Instance.playerDigimon1.stats.digimonName} takes {damageDone} damage");
                BattleManager.Instance.playerDigimon1.currentHP -= damageDone;
            }
            else
            {
                Debug.Log($"Missed {BattleManager.Instance.playerDigimon1.stats.digimonName}!");
            }

        }
        if (BattleManager.Instance.playerDigimon2)
        {
            if (Random.value < 0.8f)
            {
                damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.playerDigimon2.currentDEF;

                Debug.Log($"{BattleManager.Instance.playerDigimon2.stats.digimonName} takes {damageDone} damage");
                BattleManager.Instance.playerDigimon2.currentHP -= damageDone;
            }
            else
            {
                Debug.Log($"Missed {BattleManager.Instance.playerDigimon2.stats.digimonName}!");
            }
        }
    }
}
