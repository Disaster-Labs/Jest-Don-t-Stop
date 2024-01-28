using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Players players;
    [SerializeField] private GameObject ropeVisual;

    private float ropeMinWidth =  0.3f;
    private float ropeMaxWidth =  0.05f;
    private float playerDistLimit = 7;
    private float yOffset = -0.3f;
    private float zOffset = 0.01f;

    private void Update() 
    {
        transform.localScale = new Vector3(Math.Abs(players.GetPlayersDistance()), map(Math.Abs(players.GetPlayersDistance()), 0, playerDistLimit, ropeMinWidth, ropeMaxWidth), 1);
        transform.localPosition = new Vector3(players.GetPlayersMidPointX(), yOffset, zOffset);
        if (Math.Abs(players.GetPlayersDistance()) >= playerDistLimit) ropeVisual.GetComponent<SpriteRenderer>().color = new Color(1, 0,0, 1);
        else ropeVisual.GetComponent<SpriteRenderer>().color = new Color(160/255f, 82/255f, 45/255f, 1f);
    }

    private float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
