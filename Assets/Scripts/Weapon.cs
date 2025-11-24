using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public enum DAMAGE_TYPE { PHYSICAL, MAGICAL }

    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    public string Getname() => name;
    public DAMAGE_TYPE GetdmgType() => dmgType;
    public ELEMENT Getelem() => elem;
    public Stats GetbonusStats() => bonusStats;
    public void Setname(string name)
    {
        this.name = name;
    }
    public void SetdmgType(DAMAGE_TYPE dmgType)
    {
        this.dmgType = dmgType;
    }
    public void Setelem(ELEMENT elem)
    {
        this.elem = elem;
    }
    public void SetbonusStats(Stats bonusStats)
    {
        this.bonusStats = bonusStats;
    }

}
