using UnityEditor;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private GameObject _model;
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private Transform _jumpCheck;
  [SerializeField] private LayerMask _layerMask;
  [SerializeField] private int _jumpPower;
  [SerializeField] private GameObject CoinEffectPrefab;
  [SerializeField] private float _distanceToActivate;

  private float _currentDistance;
  private bool _isGrounded;
  private bool _isNeedJump;
  private Vector2 _direction;
  private bool _isActive = false;

  private void Update()
  {
    if (_isActive == false)
      FindPlayer();
    else
    {
      GroundCheck();
      JumpChecker();
      SetDirection();

      if (_isGrounded)
        Move();

      if (_isNeedJump && _isGrounded)
        Jump();
    }
  }

  private void FindPlayer()
  {
    _currentDistance = Vector3.Distance(transform.position, _player.transform.position);

    if (_currentDistance < _distanceToActivate)
    {
      _model.SetActive(true);
      _isActive = true;
      _rigidbody.isKinematic = false;
    }
  }

  private void SetDirection()
  {
    if (_rigidbody.velocity.x > 0)
      transform.localScale = new Vector3(1, 1, 1);
    else
      transform.localScale = new Vector3(-1, 1, 1);
  }

  private void GroundCheck() =>
    _isGrounded =
      Physics2D.OverlapCapsule
        (_groundCheck.position, new Vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0, _layerMask);

  private void JumpChecker()
  {
    _isNeedJump = Physics2D.OverlapBox(_jumpCheck.position, new Vector2(.5f, 0.1f), 0, _layerMask);
  }

  private void Move()
  {
    _currentDistance = Vector3.Distance(transform.position, _player.transform.position);

    _direction = new Vector2(_player.transform.position.x - transform.position.x, 0).normalized;
    if (_currentDistance > 1.2f)
      _rigidbody.velocity = _direction * _speed;
  }

  private void Jump() => _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

  private void OnDrawGizmos()
  {
#if UNITY_EDITOR
    Handles.color = Color.red * 0.7f;
    Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
#endif
  }
}