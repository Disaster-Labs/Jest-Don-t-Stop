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
            messageOverlayObject.text = currentTime.ToString("F0"); // 将时间显示为整数
            yield return new WaitForSeconds(1.0f); // 等待一秒钟
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
    }

    public void game_over(bool won)
    {
        // Set current_state to GameOver

        // Determine if won or lost and tell players through text

        // Have button to go back to menu
    }
    

}
