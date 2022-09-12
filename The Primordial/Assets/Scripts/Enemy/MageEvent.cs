using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEvent : MonoBehaviour
{
    
    private Mage mage;

    private void Start()
    {
        mage = transform.parent.GetComponent<Mage>();
    }

    public void Fireball()
    {
        Debug.Log("Fireball!");
        mage.Attack();
    }
}
