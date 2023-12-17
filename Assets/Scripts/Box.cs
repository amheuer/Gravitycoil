using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject boxDestroyEffect;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject effect = Instantiate(boxDestroyEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }
}
