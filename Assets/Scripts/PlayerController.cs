using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void StartLevelEvent(int level);

    public GameObject player;
    public Rigidbody2D playerRB;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject shootLight;

    private int levelNum;

    public Camera cam;

    private Vector2 mousePos;
    private Vector2 lookDir;

    public AudioSource pistolSound;
    public AudioSource wallHitSound;
    public AudioSource bounceSound;
    public AudioSource spikeSound;
    public AudioSource hitSound;

    public int clip;
    public float bulletForce = 900;
    public float playerSpeed;
    public int shots = 0;
    public float maxVol;

    public TMP_Text clipNum;

    private void Start()
    {
        int.TryParse(SceneManager.GetActiveScene().name, out levelNum);
        StartLevelEvent(levelNum);

    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            if (clip > 0)
            {
                playerRB.AddForce(-player.transform.up * playerSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                Shoot();
                pistolSound.Play();
                clip = clip - 1;
                shots = shots + 1;
            }
        }

        clipNum.text = clip.ToString();
    }
    void FixedUpdate()
    {
        lookDir = mousePos - playerRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        playerRB.rotation = angle;
        playerRB.velocity = Vector2.ClampMagnitude(playerRB.velocity, maxVol);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            wallHitSound.Play();
        }

        if (other.gameObject.CompareTag("Bounce"))
        {
            bounceSound.Play();
        }

        if (other.gameObject.CompareTag("Stab"))
        {
            spikeSound.Play();
        }
    }

    void Shoot()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); ;
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        GameObject light = Instantiate(shootLight, firePoint.transform.position, firePoint.transform.rotation);
        rb1.AddForce(firePoint.up * bulletForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Destroy(light, .03f);
    }
}
