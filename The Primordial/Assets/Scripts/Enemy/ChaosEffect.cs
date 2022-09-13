using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosEffect : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.left * 4 * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(this.gameObject, 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
