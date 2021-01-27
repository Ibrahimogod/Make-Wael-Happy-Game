using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    Timer spawnTimer;
    Timer moreFoodTimer;
    float minSpawnX;
    float maxSpawnX;

    private void Awake()
    {
        EventManager.AddMoreFoodListener(MoreFood);
        EventManager.AddStartCountListener(StopSpawning);
        EventManager.AddStopCountListener(Iniitialize);
        EventManager.AddGameOverListener(GameOver);
    }

    // Start is called before the first frame update
    void Start()
    {
        Iniitialize();
        Instantiate(Resources.Load("MoveCounter"));
    }

    void Iniitialize()
    {
        spawnTimer = GetComponent<Timer>();
        spawnTimer.Duration = 1.5f;
        if (moreFoodTimer == null)
            moreFoodTimer = gameObject.AddComponent<Timer>();
        moreFoodTimer.Duration = 7;
        spawnTimer.Run();
        minSpawnX = ScreenUtils.ScreenLeft + 1;
        maxSpawnX = ScreenUtils.ScreenRight - 1.5f;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            spawnFood();
            spawnTimer.Run();
        }

        if (moreFoodTimer.Finished)
        {
            Food.NormalFood();
            spawnTimer.Stop();
            spawnTimer.Duration = 1.5f;
            spawnTimer.Run();
            moreFoodTimer.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0)
        {
            Instantiate(Resources.Load(Menus.PauseMenu.ToString()));
        }   
    }

    void spawnFood()
    {
        int probability = Random.Range(1, 101);
        if(probability < 90)
        {
            Vector2 position = new Vector2(Random.Range(minSpawnX, maxSpawnX + 1), ScreenUtils.ScreenTop);
            Instantiate(Resources.Load(FoodType.Burger.ToString()), position, Quaternion.identity);
        }else 
        {
            int badfood = Random.Range(1, 101);
            if (badfood < 70)
            {
                Vector2 position = new Vector2(Random.Range(minSpawnX, maxSpawnX + 1), ScreenUtils.ScreenTop);
                Instantiate(Resources.Load(FoodType.Broccoli.ToString()), position, Quaternion.identity);
            }
            else
            {
                Vector2 position = new Vector2(Random.Range(minSpawnX, maxSpawnX + 1), ScreenUtils.ScreenTop);
                Instantiate(Resources.Load(FoodType.ChineseFood.ToString()), position, Quaternion.identity);
            }
        }
    }

    void MoreFood()
    {
        moreFoodTimer.Run();
        spawnTimer.Stop();
        spawnTimer.Duration = 0.75f;
        spawnTimer.Run();
        Food.MoreFood();
    }

    void StopSpawning()
    {
        spawnTimer.Stop();
    }

    void GameOver()
    {
        Instantiate(Resources.Load(Menus.GameOver.ToString()));
    }
}
