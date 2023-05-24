using System.Collections;
using DG.Tweening;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
  [SerializeField] private Transform _movePoint;
  [SerializeField] private float _duration;
  [SerializeField] private Rigidbody2D _rigidbody;

  private void Start() => Move();

  private void OnTriggerEnter2D(Collider2D collider) => collider.transform.SetParent(this.transform);

  private void OnTriggerExit2D(Collider2D collider) => collider.transform.SetParent(null);

  private void Move()
  {
    transform
      .DOMove(_movePoint.position, _duration)
      .SetEase(Ease.Linear)
      .SetLoops(-1, LoopType.Yoyo)
      .SetLink(gameObject)
      .SetUpdate(UpdateType.Fixed);
  }

  private IEnumerator Mover()
  {
    yield return null;
  }

#if UNITY_EDITOR

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, _movePoint.position);
  }

#endif
}