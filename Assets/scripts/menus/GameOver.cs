using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Play(AudioClipName.GameOver);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void HandlePlayAgainButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("GamePlay");
        Destroy(gameObject);
    }

    public void HandleMainMenuButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);
    }


}
