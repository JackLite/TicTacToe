using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string GameName = "Game";
    private const string MenuName = "Menu";

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
    }

    public static GameManager Instance { get; private set; }

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
