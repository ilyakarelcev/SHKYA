using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _runVelocity;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] Transform _bodyTransform;

    private bool _grounded;

    void FixedUpdate() {

        _animator.SetFloat("VelocityX", Mathf.Abs(_rigidbody2D.velocity.x));

        float joystickX = 0;
        if (_joystick.Value.x > 0) {
            joystickX = 1;
        } else if (_joystick.Value.x < 0) {
            joystickX = -1;
        }

        Vector2 velocity = _rigidbody2D.velocity;
        velocity.x = joystickX * _runVelocity;
        _rigidbody2D.velocity = velocity;

        if (velocity.x > 0) {
            _bodyTransform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (velocity.x < 0) {
            _bodyTransform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }

    public void Jump() {
        if (_grounded) {
            _rigidbody2D.velocity += Vector2.up * _jumpVelocity;
            _animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        _grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        _grounded = false;
    }

}
