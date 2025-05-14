using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Stats stats;

    protected virtual void EnemyIntro()
    {
        stats.currentHP = stats.hp;
    }
}
