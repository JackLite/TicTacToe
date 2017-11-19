using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region private var
    private int _fieldWidth = 3;
    private int _fieldHeight = 3;
    private int _winLine = 3;
    #endregion

    
    
    #region props
    public int FieldWidth
    {
        get
        {
            return _fieldWidth;
        }
        set
        {
            _fieldWidth = Mathf.Clamp(value, 3, 10);
        }
    }
    public int FieldHeight
    {
        get
        {
            return _fieldHeight;
        }
        set
        {
            _fieldHeight = Mathf.Clamp(value, 3, 10);
        }
    }
    public int WinLine
    {
        get
        {
            return _winLine;
        }
        set
        {
            _winLine = Mathf.Clamp(value, Mathf.Min(_fieldWidth, _fieldHeight), Mathf.Max(_fieldWidth, _fieldHeight));
        }
    }
    #endregion

    public string gameSceneName = "Game";
    public string menuSceneName = "Menu";
    public enum Side
    {
        cross,
        zero
    }

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
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
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
