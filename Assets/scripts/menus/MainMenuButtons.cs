using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleStartButton()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("UserInput");
    }

    public void HandleHelpButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Instantiate(Resources.Load(Menus.HelpMenu.ToString()));
    }

    public void HandleQuitButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Application.Quit();
    }
}
