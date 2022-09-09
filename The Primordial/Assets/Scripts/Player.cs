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

    private bool onGround = false;
    
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Rigidbody reference in current game object
    }

    
    void Update()
    {
        float moving = Input.GetAxisRaw("Horizontal"); // Raw values instead of increasing and decreasing ones
        

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            onGround = false;
            resetJump = true;
            StartCoroutine(ResetJumpRoutine());
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.65f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.65f, Color.green);
        if(hit.collider != null)
        {
            if(resetJump == false)
            {
                onGround = true;
            }
            
        }

        rigidBody.velocity = new Vector2(moving, rigidBody.velocity.y);
    }

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
