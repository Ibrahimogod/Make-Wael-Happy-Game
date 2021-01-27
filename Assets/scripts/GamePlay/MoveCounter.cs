using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveCounter : MonoBehaviour
{
    #region Fields
    [SerializeField]
    Text counterTxt;

    Timer stopWatch;
    Timer destroyTimer;
    UnityEvent startCount = new UnityEvent();
    UnityEvent stopCount = new UnityEvent();
    #endregion

    private void Awake()
    {
        EventManager.AddStartCountInvoker(this);
        EventManager.AddStopCountInvoker(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        counterTxt.color = Color.white;
        counterTxt.text = "3";
        stopWatch = gameObject.AddComponent<Timer>();
        stopWatch.Duration = 3;
        destroyTimer = gameObject.AddComponent<Timer>();
        destroyTimer.Duration = 3.5f;
        stopWatch.Run();
        destroyTimer.Run();
        startCount.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatch.TimeLeft <= 1)
        {
            counterTxt.text = "1";
        }else if(stopWatch.TimeLeft <= 2)
        {
            counterTxt.text = "2";
        }

        if (stopWatch.Finished)
        {
            counterTxt.text = "GO!";
            counterTxt.color = Color.green;
        }


        if (destroyTimer.Finished)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }

    public void AddStartCountListener(UnityAction listener)
    {
        startCount.AddListener(listener);
    }

    public void AddStopCountListener(UnityAction listener)
    {
        stopCount.AddListener(listener);
    }

    private void OnDestroy()
    {
        stopCount.Invoke();
        Cursor.visible = false;
    }
}
