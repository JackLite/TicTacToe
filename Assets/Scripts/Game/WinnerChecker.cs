using Game.Field;
using UnityEngine;
using UnityEngine.UI;

public class WinnerChecker : MonoBehaviour
{
    private int horCellsCount;
    private int vertCellsCount;
    private int lineCount = 0;
    private FieldManager fieldManager;
    private int winLine;

    void Start()
    {
        fieldManager = GetComponent<FieldManager>();
        horCellsCount = GameData.Instance.fieldSettings.width;
        vertCellsCount = GameData.Instance.fieldSettings.height;
        winLine = GameData.Instance.fieldSettings.winLine;
    }

    public bool checkWinner(int last_hor, int last_vert, CellState[,] fieldState)
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
        else if (!fieldManager.IsExistEmptyCells())
        {
            showWinner(CellState.Empty);
            return true;
        }
        return false;
    }
    private void showWinner(CellState state)
    {
        var sceneManager = fieldManager.sceneManager;
        if (state == CellState.Empty)
        {
            sceneManager.WinTitleText.SetActive(false);
            sceneManager.WinText.GetComponent<Text>().text = "Ничья!";
        }
        else
        {
            sceneManager.WinText.GetComponent<Text>().text = GameManager.GetWinnerName(state);
        }
        sceneManager.ShowWinner();
    }
    private bool checkHorizontal(int last_hor, int last_vert, CellState[,] fieldState)
    {
        int hor_pos = last_hor;
        while (hor_pos < horCellsCount - 1)
        {
            hor_pos++;
            CellState state = fieldState[hor_pos, last_vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }
        hor_pos = last_hor;
        while (hor_pos > 0)
        {
            hor_pos--;
            CellState state = fieldState[hor_pos, last_vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
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
    private bool checkVertical(int hor_pos, int vert_pos, CellState[,] fieldState)
    {
        int vert = vert_pos;
        while (vert < vertCellsCount - 1)
        {
            vert++;
            CellState state = fieldState[hor_pos, vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }
        vert = vert_pos;
        while (vert > 0)
        {
            vert--;
            CellState state = fieldState[hor_pos, vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
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
    private bool checkDiagonal(int hor_pos, int vert_pos, CellState[,] fieldState)
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
    private bool checkDiagonalFromTop(int hor_pos, int vert_pos, CellState[,] fieldState)
    {
        int hor = hor_pos;
        int vert = vert_pos;
        while (hor < horCellsCount - 1 && vert < vertCellsCount - 1)
        {
            hor++;
            vert++;
            CellState state = fieldState[hor, vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }
        hor = hor_pos;
        vert = vert_pos;
        while (hor > 0 && vert > 0)
        {
            hor--;
            vert--;
            CellState state = fieldState[hor, vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
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
    private bool checkDiagonalFromBottom(int hor_pos, int vert_pos, CellState[,] fieldState)
    {
        int hor = hor_pos;
        int vert = vert_pos;
        while (hor < horCellsCount - 1 && vert > 0)
        {
            hor++;
            vert--;
            CellState state = fieldState[hor, vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }
        hor = hor_pos;
        vert = vert_pos;
        while (hor > 0 && vert < vertCellsCount - 1)
        {
            hor--;
            vert++;
            CellState state = fieldState[hor, vert];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
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
