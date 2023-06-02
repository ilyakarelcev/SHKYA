using UnityEngine;

public class Lightning : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.TryGetComponent(out PlayerHealth health))
      health.TakeDamage();
  }
}