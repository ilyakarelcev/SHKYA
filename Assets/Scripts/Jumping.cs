using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    [SerializeField] private PlayerMove _playerMove;    
    [SerializeField] private Joystick _joystick;

    private bool _down;

    private void Start() {
        _joystick.EventOnDown.AddListener(OnDown);
        _joystick.EventOnUp.AddListener(OnUp);
    }

    private void Update() {
        if (_down) {
            if (_joystick.Value.y > 0.1f) {
                _playerMove.SetJumpFlag();
                _down = false;
            }
        }
    }

    void OnDown(Vector2 point) {
        _down = true;
    }

    void OnUp(Vector2 point) {
        _down = false;
    }

}
