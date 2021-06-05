using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyWalking)), CanEditMultipleObjects]
public class EnemyWalkingEditor : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        EnemyWalking enemyWalking = (EnemyWalking)target;
        if (GUILayout.Button("Targets To Dafault")) {
            enemyWalking.MoveTargetsToDafault();
            SceneView.RepaintAll();
        }
    }

    protected virtual void OnSceneGUI() {

        EnemyWalking enemyWalking = (EnemyWalking)target;
        EditorGUI.BeginChangeCheck();

        Vector3 positionA = Handles.PositionHandle(enemyWalking.LeftPoint, Quaternion.identity);
        Vector3 positionB = Handles.PositionHandle(enemyWalking.RightPoint, Quaternion.identity);

        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(enemyWalking, "bom bom");
            positionA.y = enemyWalking.transform.position.y;
            positionA.z = 0f;
            positionB.y = enemyWalking.transform.position.y;
            positionB.z = 0f;
            enemyWalking.LeftPoint = positionA;
            enemyWalking.RightPoint = positionB;
        }

    }

}
