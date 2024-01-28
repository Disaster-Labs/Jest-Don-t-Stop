using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject visual;

    private int health = 3; 

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "PlayerArms") 
        {
            health = health - 1;
            GetComponent<AudioSource>().PlayOneShot(audioClip);
        }

        if (health == 0) 
        {
            Debug.Log("No More Health :(");
            visual.SetActive(false);
            particles.GetComponent<ParticleSystem>().Play();
            StartCoroutine(ExecuteAfterTime(0.3f));
        }
    }

    private IEnumerator ExecuteAfterTime(float time) 
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
