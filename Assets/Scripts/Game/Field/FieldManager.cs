using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using TrueGames;
using UnityEngine.Serialization;

namespace Game.Field
{
    public class FieldManager : MonoBehaviour
    {
        private int horCellsCount;
        private int vertCellsCount;
        private RectTransform rectTransform;
        private FieldRectSize fieldRectSize;


        [SerializeField]
        public SceneManager sceneManager;

        public CellState LastState { get; set; }
        public CellState[,] fieldState;

        private void Awake()
        {
            horCellsCount = GameData.Instance.fieldSettings.width;
            vertCellsCount = GameData.Instance.fieldSettings.height;
            rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            
            if (GameManager.GetInstance().isResumeGame)
            {
                LastState = GameData.Instance.lastState;
                fieldState = GameData.Instance.fieldState;
            }
            else
            {
                LastState = CellState.cross;
                fieldState = new CellState[horCellsCount, vertCellsCount];
            }
            
            var cellSize = CellsInitializer.CalculateCellSize(GetFieldSize(), GameData.Instance.fieldSettings);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horCellsCount * cellSize);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vertCellsCount * cellSize);
            rectTransform.localPosition = new Vector2(0, 0);
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

        public bool isExistEmptyCells()
        {
            int hor = horCellsCount - 1;
            int vert = vertCellsCount - 1;
            for (; hor >= 0; hor--)
            {
                for (; vert >= 0; vert--)
                {
                    if (fieldState[hor, vert] == CellState.empty)
                    {
                        return true;
                    }
                }

                vert = vertCellsCount - 1;
            }

            return false;
        }
    }
}