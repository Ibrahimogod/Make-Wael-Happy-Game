using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserNameInput : MonoBehaviour
{
    [SerializeField]
    Text PlayerName;

    [SerializeField]
    Text error;

    // Start is called before the first frame update
    void Start()
    {
        error.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleSubmitButton()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        if (PlayerName.text != "Player Name" && !string.IsNullOrWhiteSpace(PlayerName.text))
        {
            PlayerPrefs.SetString("tempName", PlayerName.text);
            SceneManager.LoadScene("GamePlay");
        }
        else
        {
            error.gameObject.SetActive(true);
        }
    }
}
