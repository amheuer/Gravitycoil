using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject deadTarget;
    public GameObject destroyEffect;
    public GameObject destroyLight;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(deadTarget, transform.position, Quaternion.identity);
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            GameObject light = Instantiate(destroyLight, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(effect, 1f);
            Destroy(light, .03f);
            Destroy(gameObject);
        }

    }
}
