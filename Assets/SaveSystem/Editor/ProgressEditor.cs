using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Progress))]
public class ProgressEditor : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        Progress progress = target as Progress;

        if (GUILayout.Button("Save")) {
            progress.Save();
        }

        if (GUILayout.Button("Load")) {
            progress.Load();
        }

    }

}
