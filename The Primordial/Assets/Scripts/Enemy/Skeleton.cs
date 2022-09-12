using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : PatrolEnemy, IDamageable
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
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && animator.GetBool("InCombat") == true)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Damage()
    {
        Health -= 2;

        animator.SetTrigger("Hit");
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }
}
