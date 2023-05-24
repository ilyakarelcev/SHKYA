using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rigidbody;
  [SerializeField] private float _speed;

  private int _health = 4;
  private Vector3 _direction;

  public void Move(Vector3 direction)
  {
    _direction = direction - transform.position;

    _rigidbody.velocity = _direction.normalized * _speed;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerHealth health))
    {
      print("player hit");
      Destroy(gameObject);
      health.TakeDamage();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    _health--;
    if (_health <= 0)
      Destroy(gameObject);

    ContactPoint2D contact = collision.contacts[0];
    Bounce(contact.normal);
  }

  private void Bounce(Vector2 normal)
  {
    _rigidbody.velocity += normal.normalized * _speed;
  }
}