using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{

    public void ShowHome() {
        LevelManager levelManager = target as LevelManager;
        levelManager.ShowHome(false);
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        LevelManager levelManager = target as LevelManager;

        if (GUILayout.Button("Home")) {
            levelManager.ShowHome(false);
        }
        if (GUILayout.Button("Office")) {
            levelManager.ShowOffice();
        }
        if (GUILayout.Button("Work")) {
            levelManager.ShowWork();
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
