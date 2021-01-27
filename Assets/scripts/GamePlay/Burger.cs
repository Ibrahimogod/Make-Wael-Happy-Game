using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Burger : Food
{
    UnityEvent missedOneEvent = new UnityEvent();

    private void Awake()
    {
        EventManager.AddMissedFoodInvoker(this);
        base.Awake();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnBecameInvisible()
    {
        if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            AudioManager.Play(AudioClipName.FoodPopping);
            missedOneEvent.Invoke();
        }
        base.OnBecameInvisible();   
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public void AddListener(UnityAction listener)
    {
        missedOneEvent.AddListener(listener);
    }
}
