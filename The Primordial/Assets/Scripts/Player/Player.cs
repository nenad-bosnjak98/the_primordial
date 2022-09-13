using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private LayerMask groundLayer;
    

    private float jumpForce = 6.5f;
    private bool resetJump = false;
    private bool grounded = false;

    public int scene;
    private float speed = 2.7f;

    private PlayerAnimation playerAnim;
    private SpriteRenderer spriteRenderer;

    public int coins;
    private bool dead = false;


    public int Health { get; set; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Rigidbody reference in current game object
        playerAnim = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Health = 16;
    }

    
    void Update()
    {
        if(DialogueManager.isActive == true)
        {
            playerAnim.Idle();
        }
        else if(dead == true)
        {
            StartCoroutine(WaitALittle());
            SceneManager.LoadScene(1);
        }
        else
        {
            Movement();
            Jump();
            Attack();
        }
        

    }

    void Movement()
    {
        float moving = Input.GetAxisRaw("Horizontal"); // Raw values instead of increasing and decreasing ones

        grounded = isGrounded();

        Flip(moving);

        rigidBody.velocity = new Vector2(moving * speed, rigidBody.velocity.y);
        playerAnim.Move(moving);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnim.Jump(true);
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && isGrounded() == true)
        {
            playerAnim.Attack();
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value); // For detecting the ground layer underneath character

        Debug.DrawRay(transform.position, Vector2.down * 0.65f, Color.green);

        if (hit.collider != null)
        {
            if(resetJump == false)
            {
                playerAnim.Jump(false);
                return true;
            }
            
        }
        return false;
    }

    void Flip(float move)
    {
        if (move > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    public void Damage()
    {
        if(dead == true)
        {
            return;
        }

        Debug.Log("Hit!");
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if(Health < 1)
        {
            playerAnim.Death();
            dead = true;
        }
        else
        {
            playerAnim.Hurt();
        }
    }

    public void DamageBySpikes()
    {
        playerAnim.Death();
        dead = true;
        
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UIManager.Instance.UpdateCoinCount(coins);
    }

    IEnumerator WaitALittle()
    {
        yield return new WaitForSecondsRealtime(3.0f);
    }

    


}
