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
    public static GameManager S;
    public GameState current_state;

    public int item_hits;

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
    }

    public void game_over(bool won)
    {
        // Set current_state to GameOver

        // Determine if won or lost and tell players through text

        // Have button to go back to menu
    }

}
