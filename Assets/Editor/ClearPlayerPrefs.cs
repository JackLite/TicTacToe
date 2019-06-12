using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(DataManager))]
    public class ClearPlayerPrefs : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var isClicked = GUILayout.Button("Удалить сохранения", GUILayout.ExpandWidth(true));

            if (!isClicked) return;

            DataManager.ClearGameData();
        }
    }
}