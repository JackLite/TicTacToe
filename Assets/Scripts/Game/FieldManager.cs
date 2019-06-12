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

    [SerializeField] public GameObject sceneManager;
    private int horCellsCount;
    private int vertCellsCount;
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
        if(GameManager.Instance.isResumeGame)
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
        addCells();
    }
    private void addCells()
    {
        int hor = horCellsCount - 1;
        int vert = vertCellsCount - 1;
        for (; hor >= 0; hor--)
        {
            for (; vert >= 0; vert--)
            {
                GameObject cell = GameObject.Instantiate(cellPrefab);
               
                cell.transform.SetParent(transform, false);

                RectTransform rect = cell.GetComponent<RectTransform>();
                rect.offsetMin = new Vector3(cellSize * hor, -cellSize * (vert + 1));
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cellSize);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cellSize);

                CellController cellController = cell.GetComponent<CellController>();
                cellController.sceneManager = sceneManager.GetComponent<SceneManager>();
                cellController.fieldManager = this;
                cellController.hor_number = hor;
                cellController.vert_number = vert;
                if(GameManager.Instance.isResumeGame)
                {
                    fieldState[hor, vert] = GameData.Instance.fieldState[hor, vert];
                    if(fieldState[hor, vert] != CellController.State.empty)
                    {
                        Image innerImage = cellController.transform.Find(CellController.childName).GetComponent<Image>();
                        innerImage.color = new Color(0, 0, 0, 255);
                        innerImage.sprite = sceneManager.GetComponent<SceneManager>().getSprite(fieldState[hor, vert]);
                        cellController.currentState = fieldState[hor, vert];
                    }
                }
                else
                {
                    fieldState[hor, vert] = CellController.State.empty;
                }
            }
            GameData.Instance.fieldState = fieldState;
            vert = vertCellsCount - 1;
        }
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
