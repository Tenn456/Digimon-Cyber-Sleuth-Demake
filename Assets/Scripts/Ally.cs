using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Stats stats;

    protected virtual void AllyIntro()
    {
        stats.currentHP = stats.hp;
    }
}
