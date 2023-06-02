using UnityEngine;

public class BossCollider : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerHealth health))
    {
      collider.gameObject.TryGetComponent(out PlayerMove mover);
      health.TakeDamage();
      mover.Jump();
    }
  }
}