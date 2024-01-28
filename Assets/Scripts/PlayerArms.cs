using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArms : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (player.IsPunching()) {
            Debug.Log("Hi");
            GameManager.Singleton.update_hits(1, "juggle");
        }
    }
}
