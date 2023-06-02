using DG.Tweening;
using UnityEngine;

public class IcecleEnemy : MonoBehaviour
{
  [SerializeField] private Transform _fallPoint;
  [SerializeField] private SpriteRenderer _sprite;
  [SerializeField] private Collider2D _collider;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerHealth health))
      health.TakeDamage();
  }

  private void Start() => ShakingAnimation();

  private void ShakingAnimation()
  {
    var shakeForce = new Vector3(0f, 0f, 3f);
    var delay = Random.Range(1f, 4f);

    transform
      .DOShakeRotation(1f, shakeForce, 10)
      .SetEase(Ease.Linear)
      .SetDelay(delay)
      .SetLink(gameObject).OnComplete(() => FallAnimation());
  }

  private void FallAnimation()
  {
    var _distance = Vector2.Distance(transform.position, _fallPoint.position);

    float _speed = _distance / 5;

    transform
      .DOMoveY(_fallPoint.position.y, _speed)
      .SetEase(Ease.InSine)
      .SetLink(gameObject).OnComplete(() => Deactivate());
  }

  private void Deactivate()
  {
    _collider.enabled = false;

    _sprite
      .DOFade(0, .4f)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(() => { Activate(); });
  }

  private void Activate()
  {
    transform.position = transform.parent.position;
    _collider.enabled = true;

    _sprite
      .DOFade(1, .4f)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(() => { ShakingAnimation(); });
  }
}