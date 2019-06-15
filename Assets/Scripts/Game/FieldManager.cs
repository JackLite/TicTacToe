using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using TrueGames;

public class FieldManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject cellPrefab;
    private GameObject[] cells;
    private int horCellsCount;
    private int vertCellsCount;

    [SerializeField] 
    public SceneManager sceneManager;
    
    public float cellSize = 100f;
    public CellController.State lastState { get; set; }
    public CellController.State[,] fieldState
    {
        get;
        private set;
    }
    private void Awake()
    {
        horCellsCount = GameData.Instance.fieldSettings.width;
        vertCellsCount = GameData.Instance.fieldSettings.height;
    }

    private void Start()
    {
        if(GameManager.GetInstance().isResumeGame)
        {
            lastState = GameData.Instance.lastState;
            fieldState = GameData.Instance.fieldState;
        }
        else
        {
            lastState = CellController.State.zero;
            fieldState = new CellController.State[horCellsCount, vertCellsCount];
        }
        
        RectTransform rect = GetComponent<RectTransform>();
        cellSize = Math.Min(rect.rect.width / horCellsCount, rect.rect.height / vertCellsCount);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horCellsCount * cellSize);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vertCellsCount * cellSize);
        rect.localPosition = new Vector2(0, 0);
        initCells();
    }

    public void initCells()
    {
        AddCells();
    }
    private void AddCells()
    {
        var hor = horCellsCount - 1;
        var vert = vertCellsCount - 1;
        for (; hor >= 0; hor--)
        {
            for (var tmp = vert; tmp >= 0; tmp--)
            {
                InitCell(hor, tmp);
            }
        }
        GameData.Instance.SaveFieldState(fieldState);
    }

    private void InitCell(int hor, int tmp)
    {
        var cell = Instantiate(cellPrefab, transform, false);

        CalculateCellSize(cell, hor, tmp);

        var cellController = cell.GetComponent<CellController>();
        InitCellController(cellController, hor, tmp);

        if (GameManager.GetInstance().isResumeGame)
        {
            InitSavedCell(hor, tmp, cellController);
        }
        else
        {
            fieldState[hor, tmp] = CellController.State.empty;
        }
    }

    private void InitSavedCell(int hor, int vert, CellController cellController)
    {
        fieldState[hor, vert] = GameData.Instance.fieldState[hor, vert];
        if (fieldState[hor, vert] == CellController.State.empty) return;
        InitCellImage(hor, vert, cellController);
    }

    private void InitCellImage(int hor, int vert, CellController cellController)
    {
        var innerImage = cellController.transform.Find(CellController.childName).GetComponent<Image>();
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = sceneManager.getSprite(fieldState[hor, vert]);
        cellController.currentState = fieldState[hor, vert];
    }

    private void InitCellController(CellController cellController, int hor, int vert)
    {
        cellController.sceneManager = sceneManager;
        cellController.fieldManager = this;
        cellController.hor_number = hor;
        cellController.vert_number = vert;
    }

    private void CalculateCellSize(GameObject cell, int hor, int vert)
    {
        var rect = cell.GetComponent<RectTransform>();
        rect.offsetMin = new Vector3(cellSize * hor, -cellSize * (vert + 1));
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cellSize);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cellSize);
    }

    public void updateFieldState(int hor, int vert, CellController cellController)
    {
        fieldState[hor, vert] = cellController.currentState;
        GameData.Instance.fieldState = fieldState;
        DataManager.SaveGameData();
    }

    public bool isExistEmptyCells()
    {
        int hor = horCellsCount - 1;
        int vert = vertCellsCount - 1;
        for (; hor >= 0; hor--)
        {
            for (; vert >= 0; vert--)
            {
                if(fieldState[hor, vert] == CellController.State.empty)
                {
                    return true;
                }
            }
            vert = vertCellsCount - 1;
        }
        return false;
    }
}
