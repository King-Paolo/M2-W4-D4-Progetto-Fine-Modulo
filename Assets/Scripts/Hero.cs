using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }
    public string Getname() => name;
    public int Gethp() => hp;
    public Stats GetbaseStats() => baseStats;
    public ELEMENT Getresistance() => resistance;
    public ELEMENT Getweakness() => weakness;
    public Weapon Getweapon() => weapon;
    public void Setname(string name)
    {
        this.name = name;
    }
    public void Sethp(int hp)
    {
        this.hp = hp;
    }
    public void SetbaseStats(Stats baseStats)
    {
        this.baseStats = baseStats;
    }
    public void Setresistance(ELEMENT resistance)
    {
        this.resistance = resistance;
    }
    public void Setweakness(ELEMENT weakness)
    {
        this.weakness = weakness;
    }
    public void Setweapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public void AddHP(int amount)
    {
        Sethp(hp + amount);
    }
    public void TakeDamage(int damage)
    {
        AddHP(-damage);
    }
    public bool IsAlive(int hp)
    {
        if (hp > 0)
        {
            return true;
        }
        return false;

    }
}
