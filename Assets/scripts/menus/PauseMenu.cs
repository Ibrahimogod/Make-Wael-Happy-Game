using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Play(AudioClipName.MenuLoad);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        Instantiate(Resources.Load("MoveCounter"));
    }

    public void HandleResumeButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Destroy(gameObject);
    }

    public void HandleQuitButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene(Menus.MainMenu.ToString());
        Destroy(gameObject);    
    }
}
