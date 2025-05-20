using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Stats stats;

    public int currentHP;
    public int currentSP;
    public int currentATK;
    public int currentIntel;
    public int currentDEF;
    public int currentSPD;
    public int turnsAtkBuffed;

    public bool atkBuffed;
    public bool guarding;

    protected virtual void AllyIntro()
    {
        currentHP = stats.hp;
        currentSP = stats.sp;
        currentATK = stats.atk;
        currentIntel = stats.intel;
        currentDEF = stats.def;
        currentSPD = stats.spd;
    }

    public void TerraForce()
    {
        int damageDone;

        if (BattleManager.Instance.enemyDigimon1)
        {
            damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.enemyDigimon1.currentDEF;

            if (BattleManager.Instance.enemyDigimon1.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon1.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon1.currentHP -= damageDone;
            BattleManager.Instance.enemy1HPSlider.value = BattleManager.Instance.enemyDigimon1.currentHP;

            BattleManager.Instance.damageToEnemy1Text.text = damageDone.ToString();
        }
        if (BattleManager.Instance.enemyDigimon2)
        {
            damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.enemyDigimon2.currentDEF;

            if (BattleManager.Instance.enemyDigimon2.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon2.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon2.currentHP -= damageDone;
            BattleManager.Instance.enemy2HPSlider.value = BattleManager.Instance.enemyDigimon2.currentHP;

            BattleManager.Instance.damageToEnemy2Text.text = damageDone.ToString();
        }
        if (BattleManager.Instance.enemyDigimon3)
        {
            damageDone = (currentATK * stats.skill1Power) / BattleManager.Instance.enemyDigimon3.currentDEF;

            if (BattleManager.Instance.enemyDigimon3.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon3.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon3.currentHP -= damageDone;
            BattleManager.Instance.enemy3HPSlider.value = BattleManager.Instance.enemyDigimon3.currentHP;

            BattleManager.Instance.damageToEnemy3Text.text = damageDone.ToString();

        }

        // 30 % chance to increase atk by 20 %
        if (Random.value <= 0.3f)
        {
            int atkIncrease = Mathf.RoundToInt(currentATK * 0.2f);
            currentATK += atkIncrease;
            Debug.Log($"{stats.digimonName}'s ATK increased!");
            Debug.Log($"{currentATK}");

            turnsAtkBuffed = 0;
        }

        //int atkIncrease = Mathf.RoundToInt(currentATK * 0.2f);
        //currentATK += atkIncrease;
        //Debug.Log($"{stats.digimonName}'s ATK increased!");
        //Debug.Log($"{currentATK}");

        //turnsAtkBuffed = 0;
        //atkBuffed = true;
    }

    public void GreatTornado()
    {
        int damageDone = Mathf.RoundToInt(currentATK * BattleManager.Instance.pierceMultiplier);

        if (BattleManager.Instance.attackingEnemy1)
        {
            Debug.Log($"{BattleManager.Instance.enemyDigimon1.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon1.currentHP -= damageDone;
            BattleManager.Instance.enemy1HPSlider.value = BattleManager.Instance.enemyDigimon1.currentHP;
            BattleManager.Instance.damageToEnemy1Text.text = damageDone.ToString();
        }
        else if (BattleManager.Instance.attackingEnemy2)
        {
            Debug.Log($"{BattleManager.Instance.enemyDigimon2.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon2.currentHP -= damageDone;
            BattleManager.Instance.enemy2HPSlider.value = BattleManager.Instance.enemyDigimon2.currentHP;
            BattleManager.Instance.damageToEnemy2Text.text = damageDone.ToString();
        }
        else if (BattleManager.Instance.attackingEnemy3)
        {
            Debug.Log($"{BattleManager.Instance.enemyDigimon3.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon3.currentHP -= damageDone;
            BattleManager.Instance.enemy3HPSlider.value = BattleManager.Instance.enemyDigimon3.currentHP;
            BattleManager.Instance.damageToEnemy3Text.text = damageDone.ToString();
        }
    }

    public void FreezingBreath()
    {
        int damageDone;

        if (BattleManager.Instance.attackingEnemy1)
        {
            damageDone = (currentIntel * stats.skill1Power) / BattleManager.Instance.enemyDigimon1.currentIntel;

            if (BattleManager.Instance.enemyDigimon1.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon1.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon1.currentHP -= damageDone;
            BattleManager.Instance.enemy1HPSlider.value = BattleManager.Instance.enemyDigimon1.currentHP;
            BattleManager.Instance.damageToEnemy1Text.text = damageDone.ToString();
        }
        else if (BattleManager.Instance.attackingEnemy2)
        {
            damageDone = (stats.intel * stats.skill1Power) / BattleManager.Instance.enemyDigimon2.currentIntel;

            if (BattleManager.Instance.enemyDigimon2.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon2.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon2.currentHP -= damageDone;
            BattleManager.Instance.enemy2HPSlider.value = BattleManager.Instance.enemyDigimon2.currentHP;
            BattleManager.Instance.damageToEnemy2Text.text = damageDone.ToString();
        }
        else if (BattleManager.Instance.attackingEnemy3)
        {
            damageDone = (stats.intel * stats.skill1Power) / BattleManager.Instance.enemyDigimon3.currentIntel;

            if (BattleManager.Instance.enemyDigimon3.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon3.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon3.currentHP -= damageDone;
            BattleManager.Instance.enemy3HPSlider.value = BattleManager.Instance.enemyDigimon3.currentHP;
            BattleManager.Instance.damageToEnemy3Text.text = damageDone.ToString();
        }
    }

    public void IceWolfClaw()
    {
        int damageDone;

        if (BattleManager.Instance.enemyDigimon1)
        {
            damageDone = ((currentATK * (stats.skill2Power)) / BattleManager.Instance.enemyDigimon1.currentDEF) * 2;

            if (BattleManager.Instance.enemyDigimon1.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon1.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon1.currentHP -= damageDone;
            BattleManager.Instance.enemy1HPSlider.value = BattleManager.Instance.enemyDigimon1.currentHP;
            BattleManager.Instance.damageToEnemy1Text.text = damageDone.ToString();
        }
        if (BattleManager.Instance.enemyDigimon2)
        {
            damageDone = ((currentATK * (stats.skill2Power)) / BattleManager.Instance.enemyDigimon2.currentDEF) * 2;

            if (BattleManager.Instance.enemyDigimon2.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon2.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon2.currentHP -= damageDone;
            BattleManager.Instance.enemy2HPSlider.value = BattleManager.Instance.enemyDigimon2.currentHP;
            BattleManager.Instance.damageToEnemy2Text.text = damageDone.ToString();
        }
        if (BattleManager.Instance.enemyDigimon3)
        {
            damageDone = ((currentATK * (stats.skill2Power)) / BattleManager.Instance.enemyDigimon3.currentDEF) * 2;

            if (BattleManager.Instance.enemyDigimon3.guarding)
            {
                damageDone /= 2;
            }

            Debug.Log($"{BattleManager.Instance.enemyDigimon3.stats.digimonName} takes {damageDone} damage");
            BattleManager.Instance.enemyDigimon3.currentHP -= damageDone;
            BattleManager.Instance.enemy3HPSlider.value = BattleManager.Instance.enemyDigimon3.currentHP;
            BattleManager.Instance.damageToEnemy3Text.text = damageDone.ToString();
        }
    }
}
