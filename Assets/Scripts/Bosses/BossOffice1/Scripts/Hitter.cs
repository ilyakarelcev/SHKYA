using UnityEngine;

public class Hitter : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody2D;
  [SerializeField] private PlayerMove _mover;
  [SerializeField] private PlayerHealth _health;

  public PlayerHealth PlayerHealth => _health;
  public float velocityY => _rigidbody2D.velocity.y;

  public void Jump()
  {
    _mover.Jump();
  }
}