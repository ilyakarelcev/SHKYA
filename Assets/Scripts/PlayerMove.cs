using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum MoveDirection {
    Left,
    Right
}

public class PlayerMove : MonoBehaviour {

    public Rigidbody2D Rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _runVelocity;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] Transform _bodyTransform;

    public bool Grounded;

    public MoveDirection MoveDirection;
    public Throwing Throwing;

    public LineMove CurrentLineMove;

    private bool _jumpFlag;
    private int _notGroundedFrames;

    public PlayerHealth PlayerHealth;

    private bool _controlled = true;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SetJumpFlag();
        }
    }

    public void SetJumpFlag() {
        if (Grounded) {
            _jumpFlag = true;
        }
    }

    void FixedUpdate() {
        
        if (_controlled == false) return;

        float joystickThreshold = 0.05f;
        
        float joystickX = 0f;
        if (_joystick.Value.x > joystickThreshold) {
            joystickX = 1f;
        } else if (_joystick.Value.x < -joystickThreshold) {
            joystickX = -1f;
        }

        // ввод с клавиатуры для тестов на PC
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0) {
            joystickX = horizontal;
        }

        _animator.SetFloat("VelocityX", Mathf.Abs(joystickX));

        Vector2 velocity = Rigidbody2D.velocity;
        if (CurrentLineMove) {
            velocity = CurrentLineMove.Velocity;
            velocity.x += joystickX * _runVelocity;
        } else {
            velocity.x = joystickX * _runVelocity;
        }

        Rigidbody2D.velocity = velocity;

        //if (Throwing.IsReadyToThrow == false) {
        if (joystickX > 0) {
            SetMoveDirection(MoveDirection.Right);
        } else if (joystickX < 0) {
            SetMoveDirection(MoveDirection.Left);
        }
        //}

        if (Grounded) {

            _animator.SetBool("Jump", false);
        } else {
            _animator.SetBool("Jump", true);
            _notGroundedFrames++;
        }

        if (_jumpFlag) {
            Jump();
            _jumpFlag = false;
            if (CurrentLineMove) {
                CurrentLineMove = null;
            }
        }

    }

    public void SetVelocity(Vector3 velocityValue) {
        Rigidbody2D.velocity = velocityValue;
        StartCoroutine(LoseControl(0.5f));
    }

    public IEnumerator LoseControl(float time) {
        _controlled = false;
        yield return new WaitForSeconds(time);
        _controlled = true;
    }

    public void SetMoveDirection(MoveDirection moveDirection) {
        MoveDirection = moveDirection;
        if (moveDirection == MoveDirection.Left) {
            _bodyTransform.localScale = new Vector3(1f, 1f, 1f);
        } else {
            _bodyTransform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void JumpOnEnemy() {
        PlayerHealth.MakeInvulnerable(0.1f);
        Jump();
    }

    public void Jump() {
        //if (!Grounded) return;
        SoundManager.Instance.Play("Jump");
        MMVibrationManager.Haptic(HapticTypes.LightImpact, false, true, this);
        _notGroundedFrames = 0;
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, _jumpVelocity);
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.relativeVelocity.y > 0) {

            LineMove lineMove = collision.gameObject.GetComponent<LineMove>();
            if (lineMove) {

                foreach (var item in collision.contacts) {
                    Debug.DrawRay(item.point, item.normal, Color.yellow);
                }
                //Debug.Log(collision.contacts.Length + "  " + collision.contacts[0].normal);
                if (collision.contacts[0].normal.y > 0.5) {
                    CurrentLineMove = lineMove;
                }

            }

        }

    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (_notGroundedFrames < 2) return;
        float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
        if (angle < 60f) {
            if (Grounded == false) {
                Grounded = true;
                SoundManager.Instance.Play("Grounded");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Grounded = false;

        LineMove lineMove = collision.gameObject.GetComponent<LineMove>();
        if (lineMove) {
            if (lineMove == CurrentLineMove) {
                CurrentLineMove = null;
            }
        }

    }

}
