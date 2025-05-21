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
            if (BattleManager.Instance.playerDigimon1.alive)
            {

                if (Random.value < 0.8f)
                {
                    BattleManager.Instance.enemyAttackingP1 = true;

                    damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.playerDigimon1.currentDEF;

                    if (BattleManager.Instance.playerDigimon1.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{BattleManager.Instance.playerDigimon1.stats.digimonName} takes {damageDone} damage");
                    BattleManager.Instance.playerDigimon1.currentHP -= damageDone;
                    BattleManager.Instance.damageToPlayer1Text.text = damageDone.ToString();

                }
                else
                {
                    Debug.Log($"Missed {BattleManager.Instance.playerDigimon1.stats.digimonName}!");
                    BattleManager.Instance.damageToPlayer1Text.text = "Miss";
                }
            }
        }
        if (BattleManager.Instance.playerDigimon2)
        {
            if (BattleManager.Instance.playerDigimon2.alive)
            {
                if (Random.value < 0.8f)
                {
                    BattleManager.Instance.enemyAttackingP2 = true;

                    damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.playerDigimon2.currentDEF;

                    if (BattleManager.Instance.playerDigimon2.guarding)
                    {
                        damageDone /= 2;
                    }

                    Debug.Log($"{BattleManager.Instance.playerDigimon2.stats.digimonName} takes {damageDone} damage");
                    BattleManager.Instance.playerDigimon2.currentHP -= damageDone;
                    BattleManager.Instance.damageToPlayer2Text.text = damageDone.ToString();
                }
                else
                {
                    Debug.Log($"Missed {BattleManager.Instance.playerDigimon2.stats.digimonName}!");
                    BattleManager.Instance.damageToPlayer2Text.text = "Miss";
                }
            }
        }
    }

    public void NightRaid()
    {
        int damageDone;

        if (BattleManager.Instance.playerDigimon1)
        {
            if (BattleManager.Instance.playerDigimon1.alive)
            {
                BattleManager.Instance.enemyAttackingP1 = true;
            
                damageDone = (currentIntel * stats.skill1Power) / BattleManager.Instance.playerDigimon1.currentIntel;

                if (BattleManager.Instance.playerDigimon1.guarding)
                {
                    damageDone /= 2;
                }

                Debug.Log($"{BattleManager.Instance.playerDigimon1.stats.digimonName} takes {damageDone} damage");
                BattleManager.Instance.playerDigimon1.currentHP -= damageDone;
                BattleManager.Instance.damageToPlayer1Text.text = damageDone.ToString();
            }
        }
        if (BattleManager.Instance.playerDigimon2)
        {
            if (BattleManager.Instance.playerDigimon2.alive)
            {
                BattleManager.Instance.enemyAttackingP2 = true;

                damageDone = (currentIntel * stats.skill1Power) / BattleManager.Instance.playerDigimon2.currentIntel;

                if (BattleManager.Instance.playerDigimon2.guarding)
                {
                    damageDone /= 2;
                }

                Debug.Log($"{BattleManager.Instance.playerDigimon2.stats.digimonName} takes {damageDone} damage");
                BattleManager.Instance.playerDigimon2.currentHP -= damageDone;
                BattleManager.Instance.damageToPlayer2Text.text = damageDone.ToString();
            }
        }
    }

    public void TidalWave()
    {
        int damageDone;

        if (BattleManager.Instance.playerDigimon1)
        {
            if (BattleManager.Instance.playerDigimon1.alive)
            {
                BattleManager.Instance.enemyAttackingP1 = true;

                damageDone = (currentIntel * stats.skill1Power) / BattleManager.Instance.playerDigimon1.currentIntel;

                if (BattleManager.Instance.playerDigimon1.guarding)
                {
                    damageDone /= 2;
                }

                Debug.Log($"{BattleManager.Instance.playerDigimon1.stats.digimonName} takes {damageDone} damage");
                BattleManager.Instance.playerDigimon1.currentHP -= damageDone;
                BattleManager.Instance.damageToPlayer1Text.text = damageDone.ToString();
            }
        }
        if (BattleManager.Instance.playerDigimon2)
        {
            if (BattleManager.Instance.playerDigimon2.alive)
            {
                BattleManager.Instance.enemyAttackingP2 = true;

                damageDone = (currentIntel * stats.skill1Power) / BattleManager.Instance.playerDigimon2.currentIntel;

                if (BattleManager.Instance.playerDigimon2.guarding)
                {
                    damageDone /= 2;
                }

                Debug.Log($"{BattleManager.Instance.playerDigimon2.stats.digimonName} takes {damageDone} damage");
                BattleManager.Instance.playerDigimon2.currentHP -= damageDone;
                BattleManager.Instance.damageToPlayer2Text.text = damageDone.ToString();
            }
        }
    }

    public void ForbiddenTrident()
    {
        int damageDone;

        if (BattleManager.Instance.enemyTargetDigimon == 1)
        {
            damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.playerDigimon1.currentDEF;

            if (BattleManager.Instance.playerDigimon1.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.playerDigimon1.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.playerDigimon1.currentHP -= damageDone;
            BattleManager.Instance.damageToPlayer1Text.text = damageDone.ToString();
        }
        else if (BattleManager.Instance.enemyTargetDigimon == 2)
        {
            damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.playerDigimon2.currentDEF;

            if (BattleManager.Instance.playerDigimon2.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.playerDigimon2.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.playerDigimon2.currentHP -= damageDone;
            BattleManager.Instance.damageToPlayer2Text.text = damageDone.ToString();
        }
    }
}
