using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
  public Rigidbody2D Rigidbody2D;
  public Collider2D Collider2D;

  public void Throw(Vector3 velocity)
  {
    Rigidbody2D.angularVelocity = -400f;
    Rigidbody2D.velocity = velocity;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.TryGetComponent(out Player player)) return;

    Enemy enemy = other.GetComponent<Enemy>();
    if (enemy)
    {
      enemy.Die();
      Destroy(gameObject);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.TryGetComponent(out Player player)) return;

    Die();
  }

  void Die()
  {
    Destroy(gameObject);
    SoundManager.Instance.Play("CanHit");
  }
}