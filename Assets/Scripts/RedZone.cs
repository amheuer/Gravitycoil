using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    public GameObject greenZone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet") == false)
        {
            Instantiate(greenZone, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }

    }
}
