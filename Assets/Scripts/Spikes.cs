using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public Animator transition;
    public GameObject player;
    public GameObject playerDeathEffect;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        Instantiate(playerDeathEffect, player.transform.position, Quaternion.identity);

        Destroy(player);

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(levelIndex);

    }
}
