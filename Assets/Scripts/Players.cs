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
        gameInput.OnPlayer2Interaction += BothPlayersInteraction;
    }

    private void Update() 
    {
        playerDistance = player1.transform.position.x - player2.transform.position.x;
    }

    private void BothPlayersInteraction(object sender, System.EventArgs e) 
    {
        if (!gameInput.BothPlayersInteracted()) return;
        Debug.Log("Both Players Punched");
    }
}
