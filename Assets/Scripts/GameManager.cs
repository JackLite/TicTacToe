using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Side cross;
    private Side zero;

    private string gameSceneName = "Game";
    private string menuSceneName = "Menu";


    public bool isResumeGame;
        
    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        cross.code = "cross";
        cross.name = "крестики";
        zero.code = "zero";
        zero.name = "нолики";
    }

    public static GameManager Instance { get; private set; }

    public string MenuSceneName
    {
        get { return menuSceneName; }
    }

    public string GameSceneName
    {
        get { return gameSceneName; }
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }
    
    public static string GetWinnerName(CellController.State state)
    {
        switch (state)
        {
            case CellController.State.cross:
                return GameData.Instance.playersName.first;
            case CellController.State.zero:
                return GameData.Instance.playersName.second;
            case CellController.State.empty:
                throw new System.Exception("Передано неверное состояние");
            default:
                throw new System.Exception("Передано неверное состояние");
        }
    }
}
