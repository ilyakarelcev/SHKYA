using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Home))]
public class HomeEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Home home = target as Home;

        if (GUILayout.Button("Home")) {
            home.ShowHome();
        }
        if (GUILayout.Button("Level 1")) {
            home.ShowLevel(0);
        }
        if (GUILayout.Button("Level 2")) {
            home.ShowLevel(1);
        }
        if (GUILayout.Button("Level 3")) {
            home.ShowLevel(2);
        }


    }

}
