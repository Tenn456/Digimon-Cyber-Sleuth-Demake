using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{
    public string digimonName;
    public int hp;
    public int sp;
    public int atk;
    public int intel;
    public int def;
    public int spd;

    public string skill1Name;
    public string skill1Type;
    public string skill1Description;
    public int skill1Power;
    public int skill1Cost;
    public bool skill1MultiTarget;

    public string skill2Name;
    public string skill2Type;
    public string skill2Description;
    public int skill2Power;
    public int skill2Cost;
    public bool skill2MultiTarget;

    public string skill3Name;
    public string skill3Type;
    public string skill3Description;
    public int skill3Power;
    public int skill3Cost;
    public bool skill3MultiTarget;
}
