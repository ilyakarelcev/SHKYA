using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraMove : MonoBehaviour {

    [SerializeField] private Transform _target;
    [SerializeField] private float _xFollowSpeed;
    [SerializeField] private float _yFollowSpeed;

    float _x;
    float _y;

    void LateUpdate() {
        if (!Application.isPlaying) {
            transform.position = _target.position;
        } else {
            _x = Mathf.Lerp(_x, _target.position.x, Time.deltaTime * _xFollowSpeed);
            _y = Mathf.Lerp(_y, _target.position.y, Time.deltaTime * _yFollowSpeed);
            transform.position = new Vector3(_x, _y, _target.position.z);
        }
        
    }
}
