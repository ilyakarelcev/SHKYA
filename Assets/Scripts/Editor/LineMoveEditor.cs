using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LineMove)), CanEditMultipleObjects]
public class LineMoveEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        LineMove moveFromAtoB = (LineMove)target;
        if (GUILayout.Button("Targets To Dafault")) {
            moveFromAtoB.MoveTargetsToDafault();
            SceneView.RepaintAll();
        }
    }

    private Vector3 _oldPosition;

    protected virtual void OnSceneGUI() {
        if (Application.isPlaying) {
            return;
        }
        LineMove lineMove = (LineMove)target;
        EditorGUI.BeginChangeCheck();

        Vector3 positionA = Handles.PositionHandle(lineMove.transform.TransformPoint(lineMove.ALocal), Quaternion.identity);
        Vector3 positionB = Handles.PositionHandle(lineMove.transform.TransformPoint(lineMove.BLocal), Quaternion.identity);
        
        if (EditorGUI.EndChangeCheck()) {

            Undo.RecordObject(lineMove, "bom bom");

            positionA.z = 0f;
            positionB.z = 0f;
            lineMove.ALocal = lineMove.transform.InverseTransformPoint(positionA);
            lineMove.BLocal = lineMove.transform.InverseTransformPoint(positionB);
        }

    }
}
