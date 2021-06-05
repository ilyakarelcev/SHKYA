using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraMove : MonoBehaviour {

    [SerializeField] private Transform _target;
    [SerializeField] private float _xFollowSpeed;
    [SerializeField] private float _yFollowSpeed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private PlayerMove _playerMove;

    float _x;
    float _y;

    private float _currentCameraLocalX;
    private float _targetCameraLocalX;

    void LateUpdate() {
        if (!Application.isPlaying) {
            transform.position = _target.position;
        } else {
            _x = Mathf.Lerp(_x, _target.position.x, Time.deltaTime * _xFollowSpeed);
            _y = Mathf.Lerp(_y, _target.position.y, Time.deltaTime * _yFollowSpeed);
            transform.position = new Vector3(_x, _y, _target.position.z);
        }

        //float interpolant = _joystick.Value.x * 0.5f + 0.5f;
        if (_playerMove.MoveDirection == MoveDirection.Left) {
            _targetCameraLocalX = -2f;
        } else {
            _targetCameraLocalX = 2f;
        }

        _currentCameraLocalX = Mathf.Lerp(_currentCameraLocalX, _targetCameraLocalX, Time.deltaTime * 1f);
        _cameraTransform.localPosition = new Vector3(_currentCameraLocalX, _cameraTransform.localPosition.y, _cameraTransform.localPosition.z);

    }
}
