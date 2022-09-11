using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBandit : Enemy
{
    private Vector3 currentTargetPosition;
    private Animator anim;
    private SpriteRenderer heavyBanditSprite;

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        heavyBanditSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Combat Idle"))
        {
            return;
        }

        FlipWhenStopped();
        Movement();

    }


    void Movement()
    {
        if (transform.position == pointOne.position)
        {
            currentTargetPosition = pointTwo.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointTwo.position)
        {
            currentTargetPosition = pointOne.position;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTargetPosition, speed * Time.deltaTime);
    }

    void FlipWhenStopped()
    {
        if (currentTargetPosition == pointOne.position)
        {
            heavyBanditSprite.flipX = true;
        }
        else
        {
            heavyBanditSprite.flipX = false;
        }
    }
}
