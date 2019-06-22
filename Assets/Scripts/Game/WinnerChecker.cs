using Game.Cell;
using Game.Field;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FieldManager))]
public class WinnerChecker : MonoBehaviour
{
    private int horCellsCount;
    private int verticalCellsCount;
    private int lineCount;
    private int winLine;
    private FieldManager fieldManager;

    [SerializeField]
    private GameObject winTitleText;

    [SerializeField]
    private GameObject winText;

    private void Awake()
    {
        horCellsCount = GameData.Instance.fieldSettings.width;
        verticalCellsCount = GameData.Instance.fieldSettings.height;
        winLine = GameData.Instance.fieldSettings.winLine;
        fieldManager = GetComponent<FieldManager>();
    }

    public void OnCellChange(CellPosition position)
    {
        var isEndGame = CheckWinner(position.X, position.Y, fieldManager.fieldState);
        if (!isEndGame) return;
        GameData.Instance.isExistGame = false;
        DataManager.SaveGameData();
    }

    private bool CheckWinner(int lastHor, int lastVertical, CellState[,] fieldState)
    {
        if (CheckHorizontal(lastHor, lastVertical, fieldState))
        {
            ShowWinner(fieldState[lastHor, lastVertical]);
            return true;
        }

        if (CheckVertical(lastHor, lastVertical, fieldState))
        {
            ShowWinner(fieldState[lastHor, lastVertical]);
            return true;
        }

        if (CheckDiagonal(lastHor, lastVertical, fieldState))
        {
            ShowWinner(fieldState[lastHor, lastVertical]);
            return true;
        }

        if (fieldManager.IsExistEmptyCells()) return false;

        ShowWinner(CellState.Empty);
        return true;
    }

    private void ShowWinner(CellState state)
    {
        var sceneManager = fieldManager.sceneManager;
        if (state == CellState.Empty)
        {
            winTitleText.SetActive(false);
            winText.GetComponent<Text>().text = "Ничья!";
        }
        else
        {
            winText.GetComponent<Text>().text = PlayersManager.GetWinnerName(state);
        }

        sceneManager.ShowWinner();
    }

    private bool CheckHorizontal(int lastHor, int lastVertical, CellState[,] fieldState)
    {
        var horPos = lastHor;
        while (horPos < horCellsCount - 1)
        {
            horPos++;
            var state = fieldState[horPos, lastVertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        horPos = lastHor;
        while (horPos > 0)
        {
            horPos--;
            var state = fieldState[horPos, lastVertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        if (lineCount >= winLine - 1)
        {
            return true;
        }

        lineCount = 0;
        return false;
    }

    private bool CheckVertical(int horPos, int verticalPos, CellState[,] fieldState)
    {
        var vertical = verticalPos;
        while (vertical < verticalCellsCount - 1)
        {
            vertical++;
            var state = fieldState[horPos, vertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        vertical = verticalPos;
        while (vertical > 0)
        {
            vertical--;
            var state = fieldState[horPos, vertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        if (lineCount >= winLine - 1)
        {
            return true;
        }

        lineCount = 0;
        return false;
    }

    private bool CheckDiagonal(int horPos, int verticalPos, CellState[,] fieldState)
    {
        return CheckDiagonalFromTop(horPos, verticalPos, fieldState) ||
               CheckDiagonalFromBottom(horPos, verticalPos, fieldState);
    }

    private bool CheckDiagonalFromTop(int horPos, int verticalPos, CellState[,] fieldState)
    {
        var hor = horPos;
        var vertical = verticalPos;
        while (hor < horCellsCount - 1 && vertical < verticalCellsCount - 1)
        {
            hor++;
            vertical++;
            var state = fieldState[hor, vertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        hor = horPos;
        vertical = verticalPos;
        while (hor > 0 && vertical > 0)
        {
            hor--;
            vertical--;
            var state = fieldState[hor, vertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        if (lineCount >= winLine - 1)
        {
            return true;
        }

        lineCount = 0;
        return false;
    }

    private bool CheckDiagonalFromBottom(int horPos, int verticalPos, CellState[,] fieldState)
    {
        var hor = horPos;
        var vertical = verticalPos;
        while (hor < horCellsCount - 1 && vertical > 0)
        {
            hor++;
            vertical--;
            var state = fieldState[hor, vertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        hor = horPos;
        vertical = verticalPos;
        while (hor > 0 && vertical < verticalCellsCount - 1)
        {
            hor--;
            vertical++;
            var state = fieldState[hor, vertical];
            if (state == fieldManager.CurrentState)
            {
                lineCount++;
            }
            else
            {
                break;
            }
        }

        if (lineCount >= winLine - 1)
        {
            return true;
        }

        lineCount = 0;
        return false;
    }
}