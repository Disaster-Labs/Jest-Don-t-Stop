using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void btn_QuitGame()
    {
        Application.Quit();
    }

    public void btn_StartNewGame()
    {
        
        SceneManager.LoadScene("objDrop");
        // GameManager.Singleton.start_new_game();
    }

}
