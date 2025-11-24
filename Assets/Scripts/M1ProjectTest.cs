using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero a;
    [SerializeField] private Hero b;
    void Update()
    {
        if (a.Gethp() == 0)
            return;
        else if (b.Gethp() == 0)
            return;
        else if (a.GetbaseStats().spd + a.Getweapon().GetbonusStats().spd > (b.GetbaseStats().spd + b.Getweapon().GetbonusStats().spd))
        {
            Duel(a, b);
        }
        else
        {
            Duel(b, a);
        }
    }
    public void Duel(Hero a, Hero b)
    {
        Debug.Log(a.Getname() + " attacca " + b.Getname() + " difende ");

        if (GameFormulas.HasHit(a.GetbaseStats(), b.GetbaseStats()) == true)
        {
            if (GameFormulas.HasElementDisadvantage(a.Getweapon().Getelem(), b) == true)
            {
                Debug.Log(" RESIST ");
            }
            else if (GameFormulas.HasElementAdvantage(a.Getweapon().Getelem(), b) == true)
            {
                Debug.Log(" WEAKNESS ");
            }
            Debug.Log(" Danno Attacco = " + GameFormulas.CalculateDamageHero(a, b));

            b.TakeDamage(GameFormulas.CalculateDamageHero(a, b));
            if (b.Gethp() < 0)
            {
                b.Sethp(0);
            }
        }

        if (!b.IsAlive(b.Gethp()))
        {
            Debug.Log(a.Getname() + " è il vincitore ");
        }
        else
        {
            Debug.Log(b.Getname() + " attacca " + a.Getname() + " difende ");

            if (GameFormulas.HasHit(b.GetbaseStats(), a.GetbaseStats()) == true)
            {
                if (GameFormulas.HasElementDisadvantage(b.Getweapon().Getelem(), a) == true)
                {
                    Debug.Log(" RESIST ");
                }
                else if (GameFormulas.HasElementAdvantage(b.Getweapon().Getelem(), a) == true)
                {
                    Debug.Log(" WEAKNESS ");
                }

                Debug.Log(" Danno Attacco = " + GameFormulas.CalculateDamageHero(b, a));

                a.TakeDamage(GameFormulas.CalculateDamageHero(b, a));
                if (a.Gethp() < 0)
                {
                    a.Sethp(0);
                }

                if (!a.IsAlive(a.Gethp()))
                {
                    Debug.Log(b.Getname() + " è il vincitore ");
                }
            }
        }
    }
}





