using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBandit : Enemy
{

    private Vector3 currentTargetPosition;
    private Animator anim;
    private SpriteRenderer lightBanditSprite;

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        lightBanditSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("LightBandit_Idle"))
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
            lightBanditSprite.flipX = false;
        }
        else
        {
            lightBanditSprite.flipX = true;
        }
    }
}
