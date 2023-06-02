using System.Collections;
using UnityEngine;

public enum MoveDirection
{
  Left,
  Right
}

public class PlayerMove : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  [SerializeField] private Joystick _joystick;
  [SerializeField] private float _runVelocity;
  [SerializeField] private float _jumpVelocity;
  [SerializeField] Transform _bodyTransform;
  [SerializeField] private Collider2D _defaultCollider;
  [SerializeField] private Collider2D _sitCollider;

  public Rigidbody2D Rigidbody2D;
  public bool Grounded;
  public MoveDirection MoveDirection;
  public Throwing Throwing;
  public float _speedMultiplier = 1f;

  public LineMove CurrentLineMove;
  private bool _jumpFlag;
  private int _notGroundedFrames;
  public PlayerHealth PlayerHealth;
  private bool _controlled = true;
  private bool _isSitting;
  private Vector3 _startScale;
  private int _groundedFrames;


  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
      SetJumpFlag();

    if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S))
    {
      _defaultCollider.enabled = false;
      _sitCollider.enabled = true;
      _isSitting = true;
      _animator.SetFloat("Sit", 1f);
    }

    if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S))
    {
      _defaultCollider.enabled = true;
      _sitCollider.enabled = false;

      _isSitting = false;
      _animator.SetFloat("Sit", 0f);
    }
  }

  private void Start()
  {
    _startScale = _bodyTransform.localScale;
  }

  public void SetJumpFlag()
  {
    if (Grounded)
      _jumpFlag = true;
  }

  public void DeactivateMoveState()
  {
    _defaultCollider.enabled = false;
    
    _animator.SetFloat("VelocityX", 0);
    _animator.SetBool("Jump", false);
    _animator.SetBool("Fly", true);
  }

  public void JumpOnJumper(Vector2 force)
  {
    Rigidbody2D.velocity = Vector2.zero;
    Rigidbody2D.AddForce(force);
  }

  public void SetSitFlag(bool value)
  {
    _isSitting = value;
    if (_isSitting)
      _animator.SetFloat("Sit", 1f);
    else
      _animator.SetFloat("Sit", 0f);
  }

  void FixedUpdate()
  {
    if (_controlled == false) return;

    float joystickThreshold = 0.05f;

    float joystickX = 0f;
    if (_joystick.Value.x > joystickThreshold)
      joystickX = 1f;
    else if (_joystick.Value.x < -joystickThreshold)
      joystickX = -1f;

    float horizontal = Input.GetAxis("Horizontal");
    if (horizontal != 0)
      joystickX = horizontal;

    _animator.SetFloat("VelocityX", Mathf.Abs(joystickX));

    Vector2 velocity = Rigidbody2D.velocity;
    if (CurrentLineMove)
    {
      velocity = CurrentLineMove.Velocity;
      velocity.x += joystickX * _runVelocity;
    }
    else
      velocity.x = joystickX * _runVelocity * _speedMultiplier;

    Rigidbody2D.velocity = velocity;

    if (joystickX > 0)
      SetMoveDirection(MoveDirection.Right);
    else if (joystickX < 0)
      SetMoveDirection(MoveDirection.Left);

    if (Grounded)
    {
      _groundedFrames++;
      if (_groundedFrames > 1)
        _animator.SetBool("Jump", false);

      _notGroundedFrames = 0;
    }
    else
    {
      _notGroundedFrames++;
      if (_notGroundedFrames > 1)
        _animator.SetBool("Jump", true);

      _groundedFrames = 0;
    }

    if (_jumpFlag)
    {
      Jump();
      _jumpFlag = false;
      if (CurrentLineMove)
        CurrentLineMove = null;
    }
  }

  public void SetVelocity(Vector3 velocityValue)
  {
    Rigidbody2D.velocity = velocityValue;
    StartCoroutine(LoseControl(0.5f));
  }

  public IEnumerator LoseControl(float time)
  {
    _controlled = false;
    yield return new WaitForSeconds(time);
    _controlled = true;
  }

  public void SetMoveDirection(MoveDirection moveDirection)
  {
    MoveDirection = moveDirection;
    if (moveDirection == MoveDirection.Left)
      _bodyTransform.localScale = _startScale;
    else
      _bodyTransform.localScale = Vector3.Scale(_startScale, new Vector3(-1f, 1f, 1f));
  }

  public void JumpOnEnemy()
  {
    PlayerHealth.MakeInvulnerable(0.1f);
    Jump();
  }

  public void Jump()
  {
    SoundManager.Instance.Play("Jump");
    _notGroundedFrames = 0;
    Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, _jumpVelocity);
    Grounded = false;
    StartSpeedBust(1.3f, 0.65f);
  }

  private Coroutine _speedBust;

  public void StartSpeedBust(float value, float period)
  {
    if (_speedBust != null) StopCoroutine(_speedBust);
    _speedBust = StartCoroutine(SpeedBust(value, period));
  }

  IEnumerator SpeedBust(float value, float period)
  {
    _speedMultiplier = value;
    yield return new WaitForSeconds(period);
    _speedMultiplier = 1f;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.relativeVelocity.y > 0)
    {
      Grounded = true;
      LineMove lineMove = collision.gameObject.GetComponent<LineMove>();
      if (lineMove)
      {
        foreach (var item in collision.contacts)
          Debug.DrawRay(item.point, item.normal, Color.yellow);

        if (collision.contacts[0].normal.y > 0.5)
          CurrentLineMove = lineMove;
      }
    }
  }

  private Collider2D _currentGroundCollider;

  private void OnCollisionStay2D(Collision2D collision)
  {
    if (_notGroundedFrames < 2) return;
    float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
    if (Rigidbody2D.velocity.y > 0.1f) return;
    if (angle < 60f)
    {
      if (Grounded == false)
      {
        Grounded = true;
        _currentGroundCollider = collision.collider;
        SoundManager.Instance.Play("Grounded");
      }
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (_currentGroundCollider && collision.collider == _currentGroundCollider)
    {
      Grounded = false;
      _currentGroundCollider = null;
    }

    LineMove lineMove = collision.gameObject.GetComponent<LineMove>();
    if (lineMove)
    {
      if (lineMove == CurrentLineMove)
        CurrentLineMove = null;
    }
  }
}