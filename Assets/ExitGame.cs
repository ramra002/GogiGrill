using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitGame : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;

    private int origin_x;
    private int origin_y;
    // Start is called before the first frame update
    void Start()
    {   
       buttonWidth = 200;
       buttonHeight = 50; 
       origin_x = Screen.width / 2 - buttonWidth / 2;
       origin_y = Screen.height / 2 - buttonHeight * 2;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if(GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Main Menu")){
            SceneManager.LoadScene("StartMenu");
        }

        if(GUI.Button(new Rect(origin_x, origin_y + buttonWidth + 20, buttonWidth, buttonHeight), "Quit")){
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
