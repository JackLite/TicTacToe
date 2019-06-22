using UnityEngine;
using Game;

namespace Game.Field
{
    [RequireComponent(typeof(TextMoveController), typeof(WinnerChecker))]
    public class FieldManager : MonoBehaviour
    {
        private int horCellsCount;
        private int vertCellsCount;
        private RectTransform rectTransform;
        private FieldRectSize fieldRectSize;
        private TextMoveController textMoveController;
        private WinnerChecker winnerChecker;
        
        [SerializeField]
        public SceneManager sceneManager;

        public CellState CurrentState { get; set; }
        public CellState[,] fieldState;

        private void Awake()
        {
            horCellsCount = GameData.Instance.fieldSettings.width;
            vertCellsCount = GameData.Instance.fieldSettings.height;
            rectTransform = GetComponent<RectTransform>();
            textMoveController = GetComponent<TextMoveController>();
            winnerChecker = GetComponent<WinnerChecker>();
        }

        private void Start()
        {
            InitState();
            InitFieldSize();
        }

        private void InitFieldSize()
        {
            var cellSize = CellsInitializer.CalculateCellSize(GetFieldSize(), GameData.Instance.fieldSettings);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horCellsCount * cellSize);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vertCellsCount * cellSize);
        }

        private void InitState()
        {
            if (GameManager.GetInstance().isResumeGame)
            {
                CurrentState = GameData.Instance.lastState;
                fieldState = GameData.Instance.fieldState;
            }
            else
            {
                CurrentState = CellState.Cross;
                fieldState = new CellState[horCellsCount, vertCellsCount];
            }
            textMoveController.ChangeWhoMove(CurrentState);
        }

        public FieldRectSize GetFieldSize()
        {
            var rect = rectTransform.rect;
            if ((int) fieldRectSize.Width == 0)
            {
                fieldRectSize = new FieldRectSize(rect);
            }
            return fieldRectSize;
        }

        public void UpdateFieldState(int hor, int vert, CellState state)
        {
            fieldState[hor, vert] = state;
            GameData.Instance.fieldState = fieldState;
            DataManager.SaveGameData();
        }

        public bool IsExistEmptyCells()
        {
            var hor = horCellsCount - 1;
            var vert = vertCellsCount - 1;
            for (; hor >= 0; hor--)
            {
                for (; vert >= 0; vert--)
                {
                    if (fieldState[hor, vert] == CellState.Empty)
                    {
                        return true;
                    }
                }

                vert = vertCellsCount - 1;
            }

            return false;
        }

        public void SwitchState(CellState current)
        {
            CurrentState = current == CellState.Cross ? CellState.Zero : CellState.Cross;
            textMoveController.ChangeWhoMove(CurrentState);
        }

        public CellController.CellChangeHandler GetWinnerCheckerCellChangeHandler()
        {
            return winnerChecker.OnCellChange;
        }
    }
}