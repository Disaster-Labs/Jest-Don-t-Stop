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
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        current_emotion = KingEmotion.Frustrated;
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

    void update_king_emotion(string emotion)
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
            // Probably broadcast game over  message to GameManager here;
            Debug.Log("GAME OVER");
        } else if (current_emotion == KingEmotion.Joy &&
                   emotion == "happier")
        {
            // Broadcase win message to GameManager
            Debug.Log("YOU WIN");
        } else
        {
            current_emotion = (KingEmotion)i;
            Debug.Log("Current emotion: " + current_emotion);
        }

        // Update animations?

    }
}
