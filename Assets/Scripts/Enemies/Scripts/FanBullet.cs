using DG.Tweening;
using UnityEngine;

public class FanBullet : MonoBehaviour
{
  private Tween _tween;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.TryGetComponent(out PlayerHealth health))
    {
      health.TakeDamage();
      _tween.Kill();
      Restart();
    }
  }

  public void Move(Transform movePoint, int speed)
  {
    _tween = transform
      .DOJump(movePoint.position, 3, 1, speed)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(Restart);
  }

  private void Restart() => transform.position = transform.parent.position;
}