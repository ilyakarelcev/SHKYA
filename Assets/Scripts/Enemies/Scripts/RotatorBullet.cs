using DG.Tweening;
using UnityEngine;

public class RotatorBullet : MonoBehaviour
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

  public void Move(Transform movePoint, float speed)
  {
    _tween = transform
      .DOMove(movePoint.position, speed)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(Restart);
  }

  private void Restart() => transform.position = transform.parent.position;
}