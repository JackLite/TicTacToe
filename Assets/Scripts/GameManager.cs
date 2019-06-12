using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region private var
    private Side cross;
    private Side zero;
    #endregion

    public const string startSceneName = "Menu";

    public string gameSceneName = "Game";
    public string menuSceneName = "Menu";


    public bool isResumeGame = false;
    public bool isExistGame;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        cross.code = "cross";
        cross.name = "крестики";
        zero.code = "zero";
        zero.name = "нолики";
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static GameManager instance = null;

    public static GameManager getInstance()
    {
        return instance;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
        GameData.Instance.isExistGame = true;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public string getWinnerName(CellController.State state)
    {
        if (state == CellController.State.cross)
        {
            return GameData.Instance.playersName.first;
        }
        else if (state == CellController.State.zero)
        {
            return GameData.Instance.playersName.second;
        }
        else
        {
            throw new System.Exception("Передано неверное состояние");
        }
    }
}
