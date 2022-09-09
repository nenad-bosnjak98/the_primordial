using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Rigidbody reference in current game object
    }

    
    void Update()
    {
        float moving = Input.GetAxisRaw("Horizontal"); // Raw values instead of increasing and decreasing ones

        rigidBody.velocity = new Vector2(moving, rigidBody.velocity.y);
    }
}
