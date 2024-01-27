using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Players players;
    [SerializeField] bool isPlayer1;

    private float moveSpeed = 7;
    private float playerDistLimit = 7;

    private bool isWalking = false;
    public bool IsWalking() { return isWalking; }

    private void Update()
    {
        if (isPlayer1) HandlePlayerMovement(gameInput.GetPlayer1MoveDir());
        else HandlePlayerMovement(gameInput.GetPlayer2MoveDir());
    }

    private void HandlePlayerMovement(float moveDir) 
    {
        float playerDistance = players.GetPlayersDistance();

        if (Math.Abs(playerDistance) < playerDistLimit) 
        {
            if (moveDir != 0) isWalking = true;
            Move(moveDir); 
        } else  // players distance limit reached
        {
            // player 1 on the left, player 2 on the right
            if (playerDistance < 0)
            {
                // player 1 moving right or player 2 moving left
                if (isPlayer1 && moveDir > 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir); 
                }
                else if (!isPlayer1 && moveDir < 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir); 
                } else isWalking = false;
            } else // player 1 on the right, player 2 on the left
            {
                // player 1 moving left
                if (isPlayer1 && moveDir < 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir); 
                } else if (!isPlayer1 && moveDir > 0) 
                { 
                    if (moveDir != 0) isWalking = true;
                    Move(moveDir);  
                } else isWalking = false;
            }
        }

        if (moveDir == 0) isWalking = false;
    }

    private void Move(float moveDir) 
    {
        transform.position += new Vector3(moveDir * Time.deltaTime * moveSpeed, 0); 
    }
}
