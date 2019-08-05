using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string GameName = "Game";
    private const string MenuName = "Menu";

    private static GameManager _instance;

    public bool isResumeGame;
    public GameMode gameMode;
        
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
}
