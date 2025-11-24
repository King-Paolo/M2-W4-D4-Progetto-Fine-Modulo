using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.Getweakness())
        {
            return true;
        }
        return false;
    }
    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.Getresistance())
        {
            return true;
        }
        return false;
    }
    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
            return 1.5f;

        else if (HasElementDisadvantage(attackElement, defender))
            return 0.5f;

        else
            return 1;
    }
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int miss = Random.Range(0, 99);
        int hitChance = attacker.aim - defender.eva;
        if (miss > hitChance)
        {
            Debug.Log(" MISS ");
            return false;
        }
        return true;
    }
    public static bool IsCrit(int critValue)
    {
        int crit = Random.Range(0, 99);
        if (crit < critValue)
        {
            Debug.Log(" CRIT ");
            return true;
        }
        return false;
    }
    public static int CalculateDamageHero(Hero attacker, Hero defender)
    {
        int damage = attacker.GetbaseStats().atk + attacker.Getweapon().GetbonusStats().atk;

        Stats baseStats = attacker.GetbaseStats();
        Stats bonusStats = attacker.Getweapon().GetbonusStats();
        Stats.Sum(attacker.GetbaseStats(), attacker.Getweapon().GetbonusStats());
        Stats.Sum(defender.GetbaseStats(), defender.Getweapon().GetbonusStats());

        damage = (int)(EvaluateElementalModifier(attacker.Getweapon().Getelem(), defender) * damage);

        if (IsCrit(attacker.GetbaseStats().crt + attacker.Getweapon().GetbonusStats().crt))
        {
            damage *= 2;
        }

        if (damage < 0)
        {
            damage = 0;
        }
        if (attacker.Getweapon().GetdmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            int baseDmg = damage - (defender.GetbaseStats().def + defender.Getweapon().GetbonusStats().def);
            damage = baseDmg;
        }
        else
        {
            int baseDmg = damage - (defender.GetbaseStats().res + defender.Getweapon().GetbonusStats().res);
            damage = baseDmg;
        }
        return damage;
    }







}
