using UnityEngine;

public class PlayerFly : MonoBehaviour
{
  [SerializeField] private Joystick _joystick;
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;
  [SerializeField] private Collider2D _collider;

  private void Start()
  {
    _rigidbody.gravityScale = 0;
    _collider.enabled = true;
  }

  private void Update()
  {
    Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    if (direction.x != 0 || direction.y != 0)
      _rigidbody.velocity = direction.normalized * _speed;
    else
      _rigidbody.velocity = _joystick.Value.normalized * _speed;

    if (direction.x > 0)
      transform.localScale = Vector3.one;
    if (direction.x < 0)
      transform.localScale = new Vector3(-1, 1, 1);
  }

  public void DeactivateFlyMove() => _rigidbody.gravityScale = 2.5f;
}