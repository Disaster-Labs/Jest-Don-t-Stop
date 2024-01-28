using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KingEmotion {
    //Angry, 
    Frustrated, 
    Discontent, 
    Neutral, 
    Satisfactory,
    Joy, 
    //Happinness
}

public class KingBehavior : MonoBehaviour
{
    private KingEmotion current_emotion;
    private SpriteRenderer spriteRenderer;

    public GameObject KingBubble;
    public GameObject KingReaction;
    public Sprite[] emotion_sprites;

    // Start is called before the first frame update
    void Start()
    {
        current_emotion = KingEmotion.Discontent;
        spriteRenderer = KingReaction.GetComponent<SpriteRenderer>();
        Debug.Log("Current Emotion: " + current_emotion);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            update_king_emotion("angrier");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            update_king_emotion("happier");
        }
    }

    public void update_king_emotion(string emotion)
    {
        int i = (int)current_emotion;

        // Calculate index
        switch(emotion)
        {
            case "angrier":
                Debug.Log("Made King angrier");            
                i--;
                break;
            case "happier":
                Debug.Log("Made King happier");
                i++;
                break;
            default:
                Debug.Log("Wrong input");
                break;
        }

        // Check for win/loss
        if (current_emotion == KingEmotion.Frustrated &&
            emotion == "angrier")
        {
            GameManager.Singleton.game_over(false);
            Debug.Log("GAME OVER");
        } else if (current_emotion == KingEmotion.Joy &&
                   emotion == "happier")
        {
            GameManager.Singleton.game_over(true);
            Debug.Log("YOU WIN");
        } else
        {
            current_emotion = (KingEmotion)i;
            Debug.Log("Current emotion: " + current_emotion);
        }

        // Toggle reactions
        StartCoroutine(king_react());

    }

    private IEnumerator king_react()
    {
        KingBubble.SetActive(true);

        spriteRenderer.sprite = emotion_sprites[(int)current_emotion];

        KingReaction.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        KingBubble.SetActive(false);
        KingReaction.SetActive(false);
    }
}
