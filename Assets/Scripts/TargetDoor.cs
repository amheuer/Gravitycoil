using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoor : MonoBehaviour
{
    public GameObject[] targets;
    public bool doorOpen = false;
    public bool doorCheck = false;
    public bool doorIsTop = false;
    public bool doorIsBot = true;

    public GameObject topPoint;
    public GameObject botPoint;

    public SpriteRenderer spriteRenderer;
    public Sprite blackSprite;
    public Sprite blueSprite;

    public AudioSource doorOpenSound;

    void FixedUpdate()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");

        if (targets.Length == 0f)
        {
            doorOpen = true;
        }

        if (targets.Length > 0f)
        {
            doorOpen = false;
        }

        if (gameObject.transform.position.y >= topPoint.transform.position.y)
        {
            doorIsTop = true;
            doorIsBot= false;
        }

        if (gameObject.transform.position.y <= botPoint.transform.position.y)
        {
            doorIsBot = true;
            doorIsTop= false;
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
        if (doorOpen == true)
        {
            spriteRenderer.sprite = blackSprite;
            if (doorCheck != doorOpen)
            {
                doorOpenSound.Play();
                doorCheck = doorOpen;
            }
        }

        if (doorOpen == false)
        {
            spriteRenderer.sprite = blueSprite;
        }
    }
}
