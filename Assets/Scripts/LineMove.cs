using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Direction {
    ToA,
    ToB
}

public class LineMove : MonoBehaviour {

    [SerializeField] private float _speed;
    //[SerializeField] private Rigidbody2D _rigidbody2D;

    public Vector3 ALocal;
    public Vector3 BLocal;

    private Vector3 _aWorld;
    private Vector3 _bWorld;

    private Vector3 _pos;

    [Range(0f, 1f)]
    [SerializeField] private float _t;

    [SerializeField] private Direction _moveDirection;

    private void Start() {
        _aWorld = transform.TransformPoint(ALocal);
        _bWorld = transform.TransformPoint(BLocal);
        _pos = transform.position;
    }

    public void MoveTargetsToDafault() {
        ALocal = new Vector3(-3f, 0, 0);
        BLocal = new Vector3(3f, 0, 0);
    }

    private void Update() {

        if (!Application.isPlaying) return;

        Vector3 toA = (_aWorld - _bWorld).normalized;

        if (_moveDirection == Direction.ToA) {
            _pos = Vector3.MoveTowards(_pos, _aWorld, Time.deltaTime * _speed);
            if (Vector3.Distance(_pos, _aWorld) < 0.01f) {
                _moveDirection = Direction.ToB;
            }
            //_rigidbody2D.velocity = toA * _speed;
        } else {
            _pos = Vector3.MoveTowards(_pos, _bWorld, Time.deltaTime * _speed);
            if (Vector3.Distance(_pos, _bWorld) < 0.01f) {
                _moveDirection = Direction.ToA;
            }
            //_rigidbody2D.velocity = -toA * _speed;
        }
        //_rigidbody2D.MovePosition(_pos);
        transform.position = _pos;

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;

        Vector3 a = transform.TransformPoint(ALocal);
        Vector3 b = transform.TransformPoint(BLocal);
        if (Application.isPlaying) {
            a = _aWorld;
            b = _bWorld;
        }

        Gizmos.DrawLine(a, b);
        Gizmos.DrawSphere(a, 0.1f);
        Gizmos.DrawSphere(b, 0.1f);
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 36;
        Handles.Label(a, "A", guiStyle);
        Handles.Label(b, "B", guiStyle);
    }

}
