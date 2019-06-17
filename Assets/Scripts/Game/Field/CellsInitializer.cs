using System;
using TrueGames;
using TrueGames.Cell;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Field
{
    [RequireComponent(typeof(FieldManager))]
    public class CellsInitializer : MonoBehaviour
    {
        [SerializeField]
        private SceneManager sceneManager;
        
        [SerializeField] 
        private GameObject cellPrefab;
        
        [SerializeField]
        private float cellSize;
        
        private int horCellsCount;
        private int vertCellsCount;
        private FieldManager fieldManager;

        public static float CalculateCellSize(FieldRectSize rectSize, FieldSettings fieldSettings)
        {
            return Math.Min(rectSize.Width / fieldSettings.width, rectSize.Height / fieldSettings.height);
        }
        
        private void Awake()
        {
            horCellsCount = GameData.Instance.fieldSettings.width;
            vertCellsCount = GameData.Instance.fieldSettings.height;
            fieldManager = GetComponent<FieldManager>();
        }
        private void Start()
        {
            cellSize = CalculateCellSize(fieldManager.GetFieldSize(), GameData.Instance.fieldSettings);
            var hor = horCellsCount - 1;
            var vert = vertCellsCount - 1;
            for (; hor >= 0; hor--)
            {
                for (var tmp = vert; tmp >= 0; tmp--)
                {
                    InitCell(hor, tmp);
                }
            }
            GameData.Instance.SaveFieldState(fieldManager.fieldState);
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
                fieldManager.fieldState[hor, tmp] = CellState.Empty;
            }
        }
        
        private void InitSavedCell(int hor, int vert, CellController cellController)
        {
            fieldManager.fieldState[hor, vert] = GameData.Instance.fieldState[hor, vert];
            if (fieldManager.fieldState[hor, vert] == CellState.Empty) return;
            InitCellImage(hor, vert, cellController);
        }

        private void InitCellImage(int hor, int vert, CellController cellController)
        {
            var innerImage = cellController.GetInnerImage();
            innerImage.color = new Color(0, 0, 0, 255);
            innerImage.sprite = sceneManager.getSprite(fieldManager.fieldState[hor, vert]);
            cellController.currentState = fieldManager.fieldState[hor, vert];
        }

        private void InitCellController(CellController cellController, int hor, int vert)
        {
            cellController.SetFieldManager(fieldManager);
            cellController.SetSceneManager(sceneManager);
            cellController.SetPosition(new CellPosition(hor, vert));
        }

        private void CalculateCellSize(GameObject cell, int hor, int vert)
        {
            var rect = cell.GetComponent<RectTransform>();
            rect.offsetMin = new Vector3(cellSize * hor, -cellSize * (vert + 1));
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cellSize);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cellSize);
        }
    }
}