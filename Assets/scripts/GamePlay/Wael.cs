using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wael : MonoBehaviour
{
    float yPosition;
    bool CanMove = false;

    private void Awake()
    {
        EventManager.AddStartCountListener(DenyMove);
        EventManager.AddStopCountListener(AllowMove);
    }

    // Start is called before the first frame update
    void Start()
    {
        yPosition = ScreenUtils.ScreenBottom + 1.5f;
        transform.position = new Vector2(0, yPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0 && CanMove)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z));
            transform.position = new Vector2(CalculateClampedX(mouse.x), yPosition);
        }
    }

    float CalculateClampedX(float x)
    {
        // clamp left and right edges
        if (x - 1 < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + 1;
        }
        else if (x + 1 > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - 1;
        }
        return x;
    }

    void AllowMove()
    {
        CanMove = true;
    }

    void DenyMove()
    {
        CanMove = false;
    }
}
