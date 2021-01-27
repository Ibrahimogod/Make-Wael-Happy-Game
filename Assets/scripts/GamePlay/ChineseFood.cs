using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChineseFood : Food
{
    UnityEvent moreFoodEvent = new UnityEvent();
    private void Awake()
    {
        EventManager.AddMoreFoodInvoker(this);
        base.Awake();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        score = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wael")
        {
            moreFoodEvent.Invoke();
        }
        base.OnTriggerEnter2D(collision);
    }

    public void AddListener(UnityAction listener)
    {
        moreFoodEvent.AddListener(listener);
    }
}
