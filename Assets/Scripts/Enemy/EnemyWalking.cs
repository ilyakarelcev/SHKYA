using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyWalking : Enemy {

    public Vector3 LeftPoint;
    public Vector3 RightPoint;

    [SerializeField] private float _speed;

    private bool _isMoveingRight;

    protected override void Update() {
        if (!Application.isPlaying) return;

        if (_isMoveingRight) {
            transform.position += Vector3.right * _speed * Time.deltaTime;
            if (transform.position.x > RightPoint.x) {
                _isMoveingRight = false;
            }
        } else {
            transform.position -= Vector3.right * _speed * Time.deltaTime;
            if (transform.position.x < LeftPoint.x) {
                _isMoveingRight = true;
            }
        }
    }

    public void MoveTargetsToDafault() {
        LeftPoint = transform.position + new Vector3(-3f, 0, 0);
        RightPoint = transform.position + new Vector3(3f, 0, 0);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(LeftPoint - new Vector3(0f, 1f, 0f), LeftPoint + new Vector3(0f, 1f, 0f));
        Gizmos.DrawLine(RightPoint - new Vector3(0f, 1f, 0f), RightPoint + new Vector3(0f, 1f, 0f));
        Gizmos.DrawLine(LeftPoint, RightPoint);
        Gizmos.DrawSphere(LeftPoint, 0.1f);
        Gizmos.DrawSphere(RightPoint, 0.1f);
    }

}
