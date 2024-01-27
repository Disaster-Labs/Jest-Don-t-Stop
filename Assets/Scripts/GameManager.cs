using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameState {
    PreRound,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public TextMeshProUGUI messageOverlayObject;
    public GameObject yourPanelObject;
    public GameState current_state;

    public int item_hits;

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
        // king_script = king.GetComponent<KingBehavior>();
        start_new_game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void start_new_game()
    {
        // Set current_state to PreRound
        current_state = GameState.PreRound;

        // Reset hits
        item_hits = 0;
        
        // Call get_ready function
        get_ready();
    }

    void get_ready()
    {
        // telling player game is about to start
        
    
        //  Countdown and Call start_game
        StartCoroutine(CountdownToStart());

    
        
    }
    IEnumerator CountdownToStart()
    {
        Image panelImage = yourPanelObject.GetComponent<Image>();
        panelImage.color = Color.black;
        float currentTime = 3.0f;
        messageOverlayObject.text = "Get Ready!";
        yield return new WaitForSeconds(2.0f);

        while (currentTime > 0)
        {
            messageOverlayObject.text = currentTime.ToString("F0"); 
            yield return new WaitForSeconds(1.0f); 
            currentTime--;
        }


        messageOverlayObject.text = "";
        panelImage.color = Color.clear;
        start_game();
    }

    void start_game()
    {
        // Set current_state to Playing
        Debug.Log("about to start!!!!!!!!!");
        current_state = GameState.Playing;
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
            Image panelImage = yourPanelObject.GetComponent<Image>();
            panelImage.color = Color.black;
            messageOverlayObject.text = "YOU WON!";

            Debug.Log("YOU WON");
        } else
        {
            Image panelImage = yourPanelObject.GetComponent<Image>();
            panelImage.color = Color.black;
            messageOverlayObject.text = "YOU WON!";
            Debug.Log("YOU LOST");
        }

        // Have button to go back to menu
    }
    

}
