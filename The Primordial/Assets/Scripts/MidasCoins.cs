using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidasCoins : MonoBehaviour
{
    public int coins = 1;

    private void OnTriggerEnter2D(Collider2D objectC)
    {
        if(objectC.tag == "Player")
        {
            Player player = objectC.GetComponent<Player>();

            if(player != null)
            {
                player.AddCoins(coins);
                Destroy(this.gameObject);
            }
            
        }
    }
}
