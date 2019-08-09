using Game.Field;
using Game;
using Game.Cell;
using Game.Online;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class CellController : MonoBehaviour
{
    public CellState currentState = CellState.Empty;

    private FieldManager fieldManager;
    private FieldSettings fieldSettings;

    [SerializeField]
    private Image innerImage;

    private CellPosition position;
    private SceneManager sceneManager;

    public delegate void CellChangeHandler(CellPosition position);

    public event CellChangeHandler CellChange; 

    public void SetPosition(CellPosition pos)
    {
        position = pos;
    }

    public CellPosition GetPosition()
    {
        return position;
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
        if (!IsAllowToStep()) return;
        GameManager gameManager = GameManager.GetInstance();
        CellState state;
        if(gameManager.gameMode == GameMode.Online)
        {
            state = gameManager.player.playerType == Core.PlayerType.cross ? CellState.Cross : CellState.Zero;
            Core.Step step = new Core.Step { cellPosition = position, player = gameManager.player };
            OnlineStepManager.MakeStep(step);
        }
        else
        {
            state = fieldManager.CurrentState == CellState.Cross ? CellState.Cross : CellState.Zero;
            fieldManager.SwitchState(state);
        }
        SetState(state);
        
        
    }

    private bool IsAllowToStep()
    {
        if (GameManager.GetInstance().gameMode == GameMode.TwoPlayers) return true;

        return OnlineStepManager.IsCurrentPlayerStep();
    }

    public void SetState(CellState state)
    {
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = sceneManager.GetSprite(state);
        currentState = state;
        fieldManager.CurrentState = state;
        GameData.Instance.lastState = state;
        fieldManager.UpdateFieldState(position.X, position.Y, state);
        OnCellChange();
    }

    public Image GetInnerImage()
    {
        return innerImage;
    }

    private void OnCellChange()
    {
        CellChange?.Invoke(position);
    }
}