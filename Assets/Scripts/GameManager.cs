﻿using Game.Field;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string GameName = "Game";
    private const string MenuName = "Menu";

    private static GameManager _instance;

    public bool isResumeGame;
        
    private void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public static string MenuSceneName
    {
        get { return MenuName; }
    }

    public static string GameSceneName
    {
        get { return GameName; }
    }

    public static GameManager GetInstance()
    {
        return _instance;
    }
    
    public static string GetWinnerName(CellState state)
    {
        switch (state)
        {
            case CellState.cross:
                return GameData.Instance.playersName.first;
            case CellState.zero:
                return GameData.Instance.playersName.second;
            case CellState.empty:
                throw new System.Exception("Передано неверное состояние");
            default:
                throw new System.Exception("Передано неверное состояние");
        }
    }
}
