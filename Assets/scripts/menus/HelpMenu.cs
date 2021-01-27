using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Play(AudioClipName.MenuLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCloseButtonClick()
    {
        Destroy(gameObject);
    }
}
