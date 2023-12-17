using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBullet : MonoBehaviour
{
    public GameObject playerHitEffect;
    public GameObject hitLight;
    public Sprite wrench;
    public Sprite can;
    public Sprite baseball;
    public Sprite basketball;
    public Sprite bottle;
    public Sprite[] bulletSprites;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        bulletSprites = new Sprite[] {can, baseball, basketball, bottle };
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprites[Random.Range(0, 4)];
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(playerHitEffect, transform.position, Quaternion.identity);
        GameObject light = Instantiate(hitLight, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(effect, 1f);
        Destroy(light,.03f);
        Destroy(gameObject);

    }
}
