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
    protected Player player;

    protected bool isHit;

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("InCombat") == false)
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

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTargetPosition, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if(distance > 3.0f)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

        

        
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
