using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text playerName;

    [SerializeField]
    Text missedFood;
    
    float score;
    int missedFoodCounter;
    bool instantiated = false;
    UnityEvent GameOverEvent = new UnityEvent();

    private void Awake()
    {
        EventManager.AddFoodEatenListener(UpdateScore);
        EventManager.AddMissedFoodListener(MissedOne);
        EventManager.AddGameOverInvoker(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = $"{PlayerPrefs.GetString("tempName")}\'s score" + ':' + ' '+ score;
        missedFoodCounter = 0;
        missedFood.text = "You Missed: " + missedFoodCounter;
        instantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.missedFoodCounter > 5 && !instantiated)
        {
            GameOverEvent.Invoke();
            instantiated = true;
        }  
    }

    void UpdateScore(float score)
    {
        this.score += score;
        playerName.text = playerName.text.Substring(0, playerName.text.LastIndexOf(' ')) + $" {this.score}";
    }

    void MissedOne()
    {
        this.missedFoodCounter++;
        missedFood.text = $"You Missed: {this.missedFoodCounter}";
    }

    public void AddListener(UnityAction listener)
    {
        GameOverEvent.AddListener(listener);
    }
}