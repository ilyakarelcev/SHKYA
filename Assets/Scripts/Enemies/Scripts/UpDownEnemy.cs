using DG.Tweening;
using UnityEngine;

public class UpDownEnemy : MonoBehaviour
{
  [SerializeField] private Transform _movePoint;

  private void Start() => Move();

  private void Move()
  {
    transform
      .DOMove(_movePoint.position, 2f)
      .SetLink(gameObject)
      .SetEase(Ease.Linear)
      .SetLoops(-1, LoopType.Yoyo)
      .SetUpdate(UpdateType.Fixed);
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerHealth playerHealth))
      playerHealth.TakeDamage();
    if (collider.TryGetComponent(out PlayerMove playerMove))
      playerMove.Jump();
  }

#if UNITY_EDITOR

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, _movePoint.position);
  }
#endif
}