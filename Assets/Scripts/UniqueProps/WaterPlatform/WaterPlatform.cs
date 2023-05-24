using DG.Tweening;
using UnityEngine;

public class WaterPlatform : MonoBehaviour
{
  [SerializeField] private Transform _movePoint;
  [SerializeField] private Transform _defaultPosition;

  private Tween _tween;

  private void Start()
  {
    _defaultPosition.position = transform.position;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (_tween != null)
      _tween.Kill();

    collider.transform.SetParent(transform);

    if (collider.TryGetComponent(out Player player))
      _tween = transform.DOMove(_movePoint.position, 1f)
        .SetLink(gameObject)
        .SetUpdate(UpdateType.Fixed);
  }

  private void OnTriggerExit2D(Collider2D collider)
  {
    if (_tween != null)
      _tween.Kill();

    collider.transform.SetParent(null);

    if (collider.TryGetComponent(out Player player))
      _tween = transform.DOMove(_defaultPosition.position, 1f)
        .SetLink(gameObject)
        .SetUpdate(UpdateType.Fixed);
  }

  private void SetChild(Transform transform)
  {
    transform.SetParent(transform);
  }
}