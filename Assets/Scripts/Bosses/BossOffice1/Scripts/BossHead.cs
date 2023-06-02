using UnityEngine;

public class BossHead : MonoBehaviour
{
  [SerializeField] private BossOne _boss;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out Hitter hitter))
    {
      if (hitter.velocityY < 0)
      {
        hitter.Jump();
        _boss.CheckDamage(hitter.PlayerHealth);
      }
    }
  }
}