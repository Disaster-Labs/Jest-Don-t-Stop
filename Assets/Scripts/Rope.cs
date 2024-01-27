using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Players players;
    private float ropeWidth =  0.25f;

    private void Update() 
    {
        transform.localScale = new Vector3(Math.Abs(players.GetPlayersDistance()), ropeWidth, 1);
        transform.position = players.GetPlayersMidPoint();
    }
}
