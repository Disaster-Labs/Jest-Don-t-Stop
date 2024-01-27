using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;  
    
    private float playerDistance;
    public float GetPlayersDistance() { return playerDistance; }

    public Vector3 GetPlayersMidPoint() { return new Vector3((player1.transform.position.x  + player2.transform.position.x) / 2f, 0, 0.01f); }

    private void Start()
    {
        gameInput.OnPlayer1Interaction += OnPlayer1Interaction;
        gameInput.OnPlayer2Interaction += OnPlayer2Interaction;
    }

    private void OnPlayer1Interaction(object sender, System.EventArgs e) 
    { 
       // Punch Object
       Debug.Log("Player 1 Interacted");
    }

    private void OnPlayer2Interaction(object sender, System.EventArgs e) 
    { 
       // Punch
       Debug.Log("Player 2 Interacted");

       // Double Punch
       if (gameInput.BothPlayersInteracted()) { Debug.Log("Both Players Punched"); }
    }

    private void Update() 
    {
        playerDistance = player1.transform.position.x - player2.transform.position.x;
    }
}
