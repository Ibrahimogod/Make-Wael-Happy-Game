using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Feilds
    static List<Food> foodEatenInvokers = new List<Food>();
    static List<UnityAction<float>> foodeatenListener = new List<UnityAction<float>>();

    static List<ChineseFood> moreFoodInvokers = new List<ChineseFood>();
    static List<UnityAction> moreFoodListeners = new List<UnityAction>();

    static List<MoveCounter> startCountInvokers = new List<MoveCounter>();
    static List<MoveCounter> stopCountInvokers = new List<MoveCounter>();
    static List<UnityAction> startCountListeners = new List<UnityAction>();
    static List<UnityAction> stopCountListeners = new List<UnityAction>();

    static List<Burger> missedFoodInvokers = new List<Burger>();
    static List<UnityAction> missedFoodListeners = new List<UnityAction>();

    static List<HUD> GameOverInvokers = new List<HUD>();
    static List<UnityAction> GameOverListener = new List<UnityAction>();
    #endregion


    public static void AddFoodEatenListener(UnityAction<float> listener)
    {
        foodeatenListener.Add(listener);
        foreach(Food invoker in foodEatenInvokers)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddFoodEatenInvoker(Food invoker)
    {
        foodEatenInvokers.Add(invoker);
        foreach (UnityAction<float> listener in foodeatenListener)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddMoreFoodInvoker(ChineseFood invoker)
    {
        moreFoodInvokers.Add(invoker);
        foreach(UnityAction listener in moreFoodListeners)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddMoreFoodListener(UnityAction listener)
    {
        moreFoodListeners.Add(listener);
        foreach(ChineseFood invoker in moreFoodInvokers)
        {
            invoker.AddListener(listener);
        }
    }


    public static void AddStartCountInvoker(MoveCounter invoker)
    {
        startCountInvokers.Add(invoker);
        foreach(UnityAction listener in startCountListeners)
        {
            invoker.AddStartCountListener(listener);
        }
    }

    public static void AddStartCountListener(UnityAction listener)
    {
        startCountListeners.Add(listener);
        foreach(MoveCounter invoker in startCountInvokers)
        {
            invoker.AddStartCountListener(listener);
        }
    }

    public static void AddStopCountInvoker(MoveCounter invoker)
    {
        stopCountInvokers.Add(invoker);
        foreach(UnityAction listener in stopCountListeners)
        {
            invoker.AddStopCountListener(listener);
        }
    }

    public static void AddStopCountListener(UnityAction listener)
    {
        stopCountListeners.Add(listener);
        foreach(MoveCounter invoker in stopCountInvokers)
        {
            invoker.AddStopCountListener(listener);
        }
    }

    public static void AddMissedFoodInvoker(Burger invoker)
    {
        missedFoodInvokers.Add(invoker);
        foreach(UnityAction listener in missedFoodListeners)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddMissedFoodListener(UnityAction listener)
    {
        missedFoodListeners.Add(listener);
        foreach(Burger invoker in missedFoodInvokers)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddGameOverInvoker(HUD invoker)
    {
        GameOverInvokers.Add(invoker);
        foreach(UnityAction listener in GameOverListener)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddGameOverListener(UnityAction listener)
    {
        GameOverListener.Add(listener);
        foreach(HUD invoker in GameOverInvokers)
        {
            invoker.AddListener(listener);
        }
    }
}
