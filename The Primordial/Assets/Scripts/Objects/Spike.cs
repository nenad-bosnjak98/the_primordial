using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if(otherObj.tag == "Player")
        {
            Player player = otherObj.GetComponent<Player>();

            if(player != null)
            {
                player.DamageBySpikes();
            }
        }
    }
}
