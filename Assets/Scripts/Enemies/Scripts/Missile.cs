using UnityEngine;

public class Missile : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out Player player))
    {
      PlayerHealth playerHealth = collider.attachedRigidbody.GetComponent<PlayerHealth>();
      playerHealth.TakeDamage();
    }
    
    gameObject.SetActive(false);
  }
}