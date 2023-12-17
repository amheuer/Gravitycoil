using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExstinguisher : MonoBehaviour
{
    public float propulsionForce = 10f;
    public float propulsionTime = 5f;
    public ParticleSystem smokeParticleSystem;
    public ParticleSystem explosionParticleSystem;
    private Rigidbody2D rb;
    private ParticleSystem smoke;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (smoke != null)
        {
            smoke.transform.position = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 direction = transform.position - collision.transform.position;
            StartCoroutine(PropelFireExtinguisher(direction.normalized));
            EmitSmoke(collision.contacts[0].point);
        }
    }

    IEnumerator PropelFireExtinguisher(Vector3 direction)
    {
        float elapsedTime = 0f;
        while (elapsedTime < propulsionTime)
        {
            rb.AddForce(direction * propulsionForce);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        EmitExplosion(transform.position);
        Destroy(gameObject);
    }

    void EmitSmoke(Vector3 position)
    {
        smoke = Instantiate(smokeParticleSystem, position, Quaternion.identity);
        smoke.Play();
    }

    void EmitExplosion(Vector3 position)
    {
        ParticleSystem explosion = Instantiate(explosionParticleSystem, position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, explosion.main.duration);
        Destroy(smoke, explosion.main.duration);
    }
}
