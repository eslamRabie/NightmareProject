using UnityEditor;
using UnityEngine;

namespace GameManager
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GameManager myGameManager = (GameManager) target;
            if (GUILayout.Button("Create Level"))
            {
                myGameManager.CreateLevel();
            }
        }
    }
}