using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PatrolEnemy : Enemy
{
    [SerializeField]
    protected Transform pointOne, pointTwo;

    protected Vector3 currentTargetPosition;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        FlipWhenStopped();
        Movement();

    }

    public virtual void Movement()
    {
        if (transform.position == pointOne.position)
        {
            currentTargetPosition = pointTwo.position;
            animator.SetTrigger("Idle");
        }
        else if (transform.position == pointTwo.position)
        {
            currentTargetPosition = pointOne.position;
            animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTargetPosition, speed * Time.deltaTime);
    }

    public virtual void FlipWhenStopped()
    {
        if (currentTargetPosition == pointOne.position)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

}
