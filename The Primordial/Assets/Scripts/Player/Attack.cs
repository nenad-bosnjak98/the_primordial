using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        // Debug.Log("I hit you!");

        IDamageable hit = hitObject.GetComponent<IDamageable>();

        if(hit != null)
        {
            if(canDamage == true)
            {
                hit.Damage();
                canDamage = false;
                StartCoroutine(ResetDamage());
            }

            
            
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }
}
