using Game.Field;
using Game;
using Game.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    public CellState currentState = CellState.Empty;

    private FieldManager fieldManager;
    private FieldSettings fieldSettings;

    [SerializeField]
    private Image innerImage;

    private CellPosition position;
    private SceneManager sceneManager;

    public void SetPosition(CellPosition pos)
    {
        position = pos;
    }

    public void SetSceneManager(SceneManager manager)
    {
        sceneManager = manager;
    }

    public void SetFieldManager(FieldManager manager)
    {
        fieldManager = manager;
    }

    private void Start()
    {
        InitClickHandler();
    }

    private void InitClickHandler()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        var eventEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerClick};
        eventEntry.callback.AddListener(ClickHandler);
        eventTrigger.triggers.Add(eventEntry);
    }

    private void ClickHandler(BaseEventData eventData)
    {
        if (currentState != CellState.Empty) return;

        var state = fieldManager.CurrentState == CellState.Cross ? CellState.Cross : CellState.Zero;
        SetState(state);
        fieldManager.SwitchState(state);
    }

    private void SetState(CellState state)
    {
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = sceneManager.GetSprite(state);
        currentState = state;
        fieldManager.CurrentState = state;
        GameData.Instance.lastState = state;
        fieldManager.UpdateFieldState(position.X, position.Y, state);
        //todo после рефакторинга WinnerChecker вынести последние 4 строки в делегат и повесить на событие обновления поля
        var isEndGame = fieldManager.GetComponent<WinnerChecker>().checkWinner(position.X, position.Y, fieldManager.fieldState);
        if (!isEndGame) return;
        GameData.Instance.isExistGame = false;
        DataManager.SaveGameData();
    }

    public Image GetInnerImage()
    {
        return innerImage;
    }
}