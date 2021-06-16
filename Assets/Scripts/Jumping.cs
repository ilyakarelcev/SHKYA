using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    [SerializeField] private PlayerMove _playerMove;    
    [SerializeField] private Joystick _joystick;

    private bool _joystickDown;

    private void Start() {
        _joystick.EventOnDown.AddListener(OnDown);
        _joystick.EventOnUp.AddListener(OnUp);
    }

    private void Update() {
        if (_joystickDown) {
            if (_joystick.Value.y > 0.1f) {
                _playerMove.SetJumpFlag();
                _joystickDown = false;
            } else if (_joystick.Value.y < -0.1f) {
                _playerMove.SetSitFlag(true);
                _joystickDown = false;
            }
        }
    }

    void OnDown(Vector2 point) {
        _joystickDown = true;
    }

    void OnUp(Vector2 point) {
        _joystickDown = false;
        _playerMove.SetSitFlag(false);
    }

}
