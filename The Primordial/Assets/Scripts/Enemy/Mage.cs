using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy, IDamageable
{
    public GameObject firePrefab;
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public void Damage()
    {
        Health -= 3;
        if(Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }

    private void Update()
    {
        
    }



    public void Attack()
    {
        Instantiate(firePrefab, transform.position, Quaternion.identity);
    }
}
