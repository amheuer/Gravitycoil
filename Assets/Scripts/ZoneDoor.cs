using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDoor : MonoBehaviour
{
    public GameObject[] redZone;
    public bool doorOpen = false;
    public bool doorCheck = false;
    public bool doorIsTop = false;
    public bool doorIsBot = true;

    public GameObject topPoint;
    public GameObject botPoint;

    public SpriteRenderer spriteRenderer;
    public Sprite greenSprite;
    public Sprite redSprite;

    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;

    void FixedUpdate()
    {
        redZone = GameObject.FindGameObjectsWithTag("RedZone");

        if(redZone.Length == 0f)
        {
            doorOpen = true;
        }

        if (redZone.Length > 0f)
        {
            doorOpen = false;
        }


        if (doorOpen == true && doorIsTop == false)
        {
            transform.Translate(Vector2.up * 5 * Time.deltaTime);
            doorIsBot = false;
        }

        if (doorOpen == false && doorIsBot == false)
        {
            transform.Translate(-Vector2.up * 5 * Time.deltaTime);
            doorIsTop = false;

        }

    }

    private void Update()
    {

        if (gameObject.transform.position.y >= topPoint.transform.position.y)
        {
            doorIsTop = true;
            doorIsBot = false;
        }

        if (gameObject.transform.position.y <= botPoint.transform.position.y)
        {
            doorIsBot = true;
            doorIsTop = false;
        }

        if (doorOpen == true)
        {
            spriteRenderer.sprite = greenSprite;
            if (doorCheck != doorOpen)
            {
                doorOpenSound.Play();
                doorCheck = doorOpen;
            }
        }

        if (doorOpen == false)
        {
            spriteRenderer.sprite = redSprite;
            if (doorCheck != doorOpen)
            {
                doorCloseSound.Play();
                doorCheck = doorOpen;
            }
        }


    }
}
