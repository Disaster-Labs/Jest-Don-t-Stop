using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    PreRound,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public GameState current_state;

    public int item_hits;

    public GameObject king;
    public KingBehavior king_script;

    private void Awake()
    {
        if (GameManager.Singleton)
        {
            Destroy(this.gameObject);
        } else 
        {
            Singleton = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        king_script = king.GetComponent<KingBehavior>();
        start_new_game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void start_new_game()
    {
        // Set current_state to PreRound

        // Reset hits

        // Call get_ready function
    }

    void get_ready()
    {
        // Countdown telling player game is about to start
        
        // Call start_game
    }

    void start_game()
    {
        // Set current_state to Playing

        // Call function to start dropping items
    }

    public void update_hits(int points)
    {
        // Update item_hits
        item_hits += points;

        // Update King's Emotion
        if (points < 0)
        {
            king_script.update_king_emotion("angrier");
        } else
        {
            king_script.update_king_emotion("happier");
        }
    }

    public void game_over(bool won)
    {
        // Set current_state to GameOver
        current_state = GameState.GameOver;

        // Determine if won or lost and tell players through text
        if (won)
        {
            Debug.Log("YOU WON");
        } else
        {
            Debug.Log("YOU LOST");
        }

        // Have button to go back to menu
    }

}
