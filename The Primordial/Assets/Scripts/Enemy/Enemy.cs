using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    [SerializeField]
    protected int speed;
    protected int gems;
    [SerializeField]
    protected Transform pointOne, pointTwo;

    public virtual void Attack()
    {

    }

    public abstract void Update();
}
