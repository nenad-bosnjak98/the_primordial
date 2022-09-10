using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private LayerMask groundLayer;

    private float jumpForce = 5.0f;
    private bool resetJump = false;
    
    private float speed = 2.7f;

    private PlayerAnimation playerAnim;
    private SpriteRenderer spriteRenderer;
    
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Rigidbody reference in current game object
        playerAnim = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    
    void Update()
    {

        Movement();
        Jump();
        
    }

    void Movement()
    {
        float moving = Input.GetAxisRaw("Horizontal"); // Raw values instead of increasing and decreasing ones

        Flip(moving);

        rigidBody.velocity = new Vector2(moving * speed, rigidBody.velocity.y);
        playerAnim.Run(moving);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value); // For detecting the ground layer underneath character

        // Debug.DrawRay(transform.position, Vector2.down * 0.65f, Color.green);

        if (hit.collider != null)
        {
            if(resetJump == false)
            {
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
}
