using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using TrueGames;

public class FieldManger : MonoBehaviour
{
    #region newPublic
    [SerializeField] GameObject cellPrefab;
    #endregion


    private GameObject[] cells;

    [SerializeField] public GameObject sceneManager;
    [SerializeField] public GameObject winPanel;
    private int horCellsCount;
    private int vertCellsCount;
    public int cellSize = 100;
    public CellController.State lastState { get; set; }
    public CellController.State[,] fieldState
    {
        get;
        private set;
    }
    private void Awake()
    {
        horCellsCount = GameManager.Instance.FieldWidth;
        vertCellsCount = GameManager.Instance.FieldHeight;
    }
    public List<CellController> getFreeCells()
    {
        int count = 0;
        List<CellController> freeCells = new List<CellController>();
        foreach(Transform cell in transform)
        {
            CellController cellController = cell.gameObject.GetComponent<CellController>();
            if (cellController.currentState == CellController.State.empty)
            {
                freeCells.Add(cellController);
                count++;
            }
        }
        return freeCells;
    }

    void Start()
    {
        lastState = CellController.State.zero;
        fieldState = new CellController.State[horCellsCount, vertCellsCount];
        RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horCellsCount * cellSize);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vertCellsCount * cellSize);
        rect.localPosition = new Vector2(0, 0);
        initCells();
    }

    public void initCells()
    {
        addCells();
        addCellOnclick();
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
                fieldState[hor, vert] = CellController.State.empty;
            }
            vert = vertCellsCount - 1;
        }
    }
    private void addCellOnclick()
    {
        foreach (Transform child in transform)
        {
            EventTrigger eventTrigger = child.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry eventEntry = new EventTrigger.Entry();
            eventEntry.eventID = EventTriggerType.PointerClick;
            eventEntry.callback.AddListener(new UnityAction<BaseEventData>(child.gameObject.GetComponent<CellController>().clickHandler));
            eventTrigger.triggers.Add(eventEntry);
        }
    }
    public void updateFieldState(int hor, int vert, CellController cellController)
    {
        fieldState[hor, vert] = cellController.currentState;
    }
}
