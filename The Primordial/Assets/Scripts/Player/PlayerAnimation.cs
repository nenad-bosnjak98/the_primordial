using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }

    public void Move(float move)
    {
        animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        animator.SetBool("Jump", jump);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hit");
    }

}
