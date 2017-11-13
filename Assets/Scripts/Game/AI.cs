using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AI : MonoBehaviour
{
    private FieldManger fieldManager;
    private WinnerChecker winChecker;

    public CellController.State side;
    [SerializeField]
    public GameObject GameField;

    public void Start()
    {
        fieldManager = GameField.GetComponent<FieldManger>();
        winChecker = fieldManager.GetComponent<WinnerChecker>();
    }
    public void nextMove()
    {
        List<CellController> freeCells = fieldManager.getFreeCells();
        List<CellController> useCells = fieldManager.getFreeCells();
        CellController.State[,] fieldState;
        bool moved = false;
        for(; useCells.Count > 0;)
        {
            int index = useCells.Count - 1;
            Debug.Log(index);
            CellController randomCell = useCells[index].GetComponent<CellController>();
            useCells.RemoveAt(index);
            fieldState = fieldManager.fieldState;
            fieldState[randomCell.hor_number, randomCell.vert_number] = side;
            if (winChecker.checkWinner(randomCell.hor_number, randomCell.vert_number, fieldState))
            {
                randomCell.setState(side);
                moved = true;
            }
            fieldState = fieldManager.fieldState;
        }
        if(!moved)
        {
            int random = Random.Range(0, freeCells.Count - 1);
            CellController randomCell = freeCells[random].GetComponent<CellController>();
            randomCell.setState(side);
        }
        
        // setFreeCells(); // получаем все свободные клетки
        // начинаем цикл перебора начального хода по кол-ву клеток
        // doMove(); делаем ход в одну из клеток, вынимаем её из массива и кладем в массив ходов
        // checkWinner(); проверяем нет победный ли это ход, если победный то тут же ходим
        // начинаем цикл с определенной глубиной
        // doOpponentMove(); ход делает соперник, также вынимаем свободную клетку и кладем в другой массив
        // checkWinner(); проверяем нет ли победителя
        // doMove(); делаем ход в одну из клеток, вынимаем её из массива и кладем в массив ходов
        // checkWinner(); проверяем нет победный ли это ход, если победный то кладем вариант первого хода в массив победных ходов
        // конец цикла
        // если победы не было то кладем массив ходов в массив вариантов хода
        // конец перебора начального хода
        // если есть массив победных ходов то случайно выбираем из него, иначе выбираем из нейтрального массива
    }
}

