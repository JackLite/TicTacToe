using UnityEngine;
using UnityEngine.UI;
using TrueGames; 

public class WinnerChecker : MonoBehaviour
{
    private int horCellsCount;
    private int vertCellsCount;
    private int lineCount = 0;
    private FieldManager fieldManager;
    private int winLine;

    // Use this for initialization
    void Start()
    {
        fieldManager = GetComponent<FieldManager>();
        horCellsCount = GameManager.Instance.FieldWidth;
        vertCellsCount = GameManager.Instance.FieldHeight;
        winLine = GameManager.Instance.WinLine;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool checkWinner(int last_hor, int last_vert, CellController.State[,] fieldState)
    {
        
        if (checkHorizontal(last_hor, last_vert, fieldState))
        {
            showWinner(fieldState[last_hor, last_vert]);
            return true;
        }
        else if (checkVertical(last_hor, last_vert, fieldState))
        {
            showWinner(fieldState[last_hor, last_vert]);
            return true;
        }
        else if (checkDiagonal(last_hor, last_vert, fieldState))
        {
            showWinner(fieldState[last_hor, last_vert]);
            return true;
        }
        else if(!fieldManager.isExistEmptyCells())
        {
            showWinner(CellController.State.empty);
            return true;
        }
        return false;
    }
    private void showWinner(CellController.State state)
    {
        SceneManager sceneManager = fieldManager.sceneManager.GetComponent<SceneManager>();
        if(state == CellController.State.empty)
        {
            sceneManager.WinText.GetComponent<Text>().text = "Ничья!";
        } else
        {
            sceneManager.WinText.GetComponent<Text>().text = "Победили " + GameManager.getInstance().getWinnerName(state);
        }
        sceneManager.ShowWinner();
    }
    private bool checkHorizontal(int last_hor, int last_vert, CellController.State[,] fieldState)
    {
        int hor_pos = last_hor;
        while (hor_pos < horCellsCount - 1)
        {
            hor_pos++;
            CellController.State state = fieldState[hor_pos, last_vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        hor_pos = last_hor;
        while (hor_pos > 0)
        {
            hor_pos--;
            CellController.State state = fieldState[hor_pos, last_vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        if (lineCount == winLine - 1)
        {
            return true;
        }
        else
        {
            lineCount = 0;
            return false;
        }
    }
    private bool checkVertical(int hor_pos, int vert_pos, CellController.State[,] fieldState)
    {
        int vert = vert_pos;
        while (vert < vertCellsCount - 1)
        {
            vert++;
            CellController.State state = fieldState[hor_pos, vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        vert = vert_pos;
        while (vert > 0)
        {
            vert--;
            CellController.State state = fieldState[hor_pos, vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        if (lineCount == winLine - 1)
        {
            return true;
        }
        else
        {
            lineCount = 0;
            return false;
        }
    }
    private bool checkDiagonal(int hor_pos, int vert_pos, CellController.State[,] fieldState)
    {
        if (checkDiagonalFromTop(hor_pos, vert_pos, fieldState))
        {
            return true;
        }
        else if (checkDiagonalFromBottom(hor_pos, vert_pos, fieldState))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool checkDiagonalFromTop(int hor_pos, int vert_pos, CellController.State[,] fieldState)
    {
        int hor = hor_pos;
        int vert = vert_pos;
        while (hor < horCellsCount - 1 && vert < vertCellsCount - 1)
        {
            hor++;
            vert++;
            CellController.State state = fieldState[hor, vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        hor = hor_pos;
        vert = vert_pos;
        while (hor > 0 && vert > 0)
        {
            hor--;
            vert--;
            CellController.State state = fieldState[hor, vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        if (lineCount == winLine - 1)
        {
            return true;
        }
        else
        {
            lineCount = 0;
            return false;
        }
    }
    private bool checkDiagonalFromBottom(int hor_pos, int vert_pos, CellController.State[,] fieldState)
    {
        int hor = hor_pos;
        int vert = vert_pos;
        while (hor < horCellsCount - 1 && vert > 0)
        {
            hor++;
            vert--;
            CellController.State state = fieldState[hor, vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        hor = hor_pos;
        vert = vert_pos;
        while (hor > 0 && vert < vertCellsCount - 1)
        {
            hor--;
            vert++;
            CellController.State state = fieldState[hor, vert];
            if (state == fieldManager.lastState)
            {
                lineCount++;
            }
        }
        if (lineCount == winLine - 1)
        {
            return true;
        }
        else
        {
            lineCount = 0;
            return false;
        }
    }
}
