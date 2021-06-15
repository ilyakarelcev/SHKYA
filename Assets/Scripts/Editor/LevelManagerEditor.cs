using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        LevelManager levelManager = target as LevelManager;

        if (GUILayout.Button("Home")) {
            levelManager.ShowHome();
        }
        if (GUILayout.Button("Office")) {
            levelManager.ShowOffice();
        }

        if (GUILayout.Button("Work")) {
            levelManager.ShowLevel("Work");
        }

        if (GUILayout.Button("Level1")) {
            levelManager.ShowLevel("Level1");
        }
        if (GUILayout.Button("Level2")) {
            levelManager.ShowLevel("Level2");
        }
        
    }

}
