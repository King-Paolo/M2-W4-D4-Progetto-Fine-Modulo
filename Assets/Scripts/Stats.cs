using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int atk, def, res, spd, crt, aim, eva;
    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }


    public static Stats Sum(Stats baseStats, Stats bonusStats)
    {
        Stats finalStats = new Stats();
        finalStats.atk = baseStats.atk + bonusStats.atk;
        finalStats.def = baseStats.def + bonusStats.def;
        finalStats.res = baseStats.res + bonusStats.res;
        finalStats.spd = baseStats.spd + bonusStats.spd;
        finalStats.crt = baseStats.crt + bonusStats.crt;
        finalStats.aim = baseStats.aim + bonusStats.aim;
        finalStats.eva = baseStats.eva + bonusStats.eva;
        return finalStats;
    }
}
public enum ELEMENT
{
    NONE,
    FIRE,
    ICE,
    LIGHTNING
}
