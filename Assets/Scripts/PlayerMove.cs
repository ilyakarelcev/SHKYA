using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection { 
    Left,
    Right
}

public class PlayerMove : MonoBehaviour {

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _runVelocity;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] Transform _bodyTransform;

    public bool Grounded;

    public MoveDirection MoveDirection;
    public Throwing Throwing;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void FixedUpdate() {

        _animator.SetFloat("VelocityX", Mathf.Abs(_rigidbody2D.velocity.x));

        float joystickX = 0f;
        if (_joystick.Value.x > 0) {
            joystickX = 1f;
        } else if (_joystick.Value.x < 0) {
            joystickX = -1f;
        }

        Vector2 velocity = _rigidbody2D.velocity;
        velocity.x = joystickX * _runVelocity;
        _rigidbody2D.velocity = velocity;

        if (Throwing.IsReadyToThrow == false) {
            if (velocity.x > 0) {
                SetMoveDirection(MoveDirection.Right);
            } else if (velocity.x < 0) {
                SetMoveDirection(MoveDirection.Left);
            }
        }
        
        if (Grounded) {
            _animator.SetBool("Jump", false);
        } else {
            _animator.SetBool("Jump", true);
        }

    }

    public void SetMoveDirection(MoveDirection moveDirection) {
        MoveDirection = moveDirection;
        if (moveDirection == MoveDirection.Left) {
            _bodyTransform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            _bodyTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void Jump() {
        if (Grounded) {
            _rigidbody2D.velocity += Vector2.up * _jumpVelocity;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
        if (angle < 60f) {
            Grounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Grounded = false;
    }

}
