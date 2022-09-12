using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBandit : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Movement()
    {
        base.Movement();

        Vector3 direction = player.transform.position - transform.position;

        if (direction.x > 0 && animator.GetBool("InCombat") == true)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0 && animator.GetBool("InCombat") == true)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health -= 4;

        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
            GameObject coin = Instantiate(midasPrefab, transform.position, Quaternion.identity) as GameObject;
            coin.GetComponent<MidasCoins>().coins = base.midasCoins;
        }
    }

}
