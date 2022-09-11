using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBandit : PatrolEnemy, IDamageable
{
    public int Health { get; set; }

    

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public void Damage()
    {
        Health -= 2;

        if(Health < 1)
        {
            Destroy(gameObject);
        }
    }



}
