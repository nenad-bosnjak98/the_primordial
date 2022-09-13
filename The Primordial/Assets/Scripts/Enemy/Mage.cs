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

    public void Attack()
    {
        Instantiate(firePrefab, transform.position, Quaternion.identity);
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health -= 2;
        

        if (Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
            GameObject coin = Instantiate(midasPrefab, transform.position, Quaternion.identity) as GameObject;
            coin.GetComponent<MidasCoins>().coins = base.midasCoins;
        }
        else
        {
            animator.SetTrigger("Hit");
        }
        
    }

    private void Update()
    {
        
    }
    
}
