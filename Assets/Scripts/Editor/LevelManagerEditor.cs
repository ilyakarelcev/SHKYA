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

        GUILayout.Space(8);

        if (GUILayout.Button("Level_1")) {
            levelManager.ShowLevel("Level_1");
        }
        if (GUILayout.Button("Level_1_Back")) {
            levelManager.ShowLevel("Level_1_Back");
        }

        if (GUILayout.Button("Level_X")) {
            levelManager.ShowLevel("Level_X");
        }
        if (GUILayout.Button("Level_X_Back")) {
            levelManager.ShowLevel("Level_X_Back");
        }

    }

}
