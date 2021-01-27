using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    #region Feilds
    
    static float gravity = 9.8f;
    protected float score;
    Rigidbody2D rb2d;
    FoodEatenEvent foodEaten = new FoodEatenEvent();

    #endregion

    #region Properties

    public float Score
    {
        get => score;
    
    }

    #endregion

    protected void Awake()
    {
        EventManager.AddFoodEatenInvoker(this);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.down*gravity,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public static void MoreFood()
    {

        if (gravity == 9.8f)
        {
            gravity = 20;
        }
    }

    public static void NormalFood()
    {
        gravity = 9.8f;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wael")
        {
            foodEaten.Invoke(score);
            AudioManager.Play(AudioClipName.Eat);
            Destroy(gameObject);
        }
    }

    public void AddListener(UnityAction<float> listener)
    {
        foodEaten.AddListener(listener);
    }
}
