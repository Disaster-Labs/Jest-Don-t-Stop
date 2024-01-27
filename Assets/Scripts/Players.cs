using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;  
    
    private float moveSpeed = 7;
    private float playerDistLimit = 7;

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
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement() 
    {
        playerDistance = player1.transform.position.x - player2.transform.position.x;
        float player1MoveDir = gameInput.GetPlayer1MoveDir();
        float player2MoveDir = gameInput.GetPlayer2MoveDir();

        if (Math.Abs(playerDistance) < playerDistLimit) 
        {
            player1.transform.position += new Vector3(player1MoveDir * Time.deltaTime * moveSpeed, 0);
            player2.transform.position += new Vector3(player2MoveDir * Time.deltaTime * moveSpeed, 0);
        } else  // players distance limit reached
        {
            // player 1 on the left, player 2 on the right
            if (playerDistance < 0)
            {
                // player 1 moving right
                if (player1MoveDir > 0) { player1.transform.position += new Vector3(player1MoveDir * Time.deltaTime * moveSpeed, 0); }
                // player 2 moving left
                if (player2MoveDir < 0) { player2.transform.position += new Vector3(player2MoveDir * Time.deltaTime * moveSpeed, 0); }
            } else // player 1 on the right, player 2 on the left
            {
                // player 1 moving left
                if (player1MoveDir < 0) { player1.transform.position += new Vector3(player1MoveDir * Time.deltaTime * moveSpeed, 0); }
                // player 2 moving right
                if (player2MoveDir > 0) { player2.transform.position += new Vector3(player2MoveDir * Time.deltaTime * moveSpeed, 0); }
            }
        }
    }
}
