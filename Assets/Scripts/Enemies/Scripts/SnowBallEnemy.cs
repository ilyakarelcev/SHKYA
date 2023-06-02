using DG.Tweening;
using UnityEngine;

public class SnowBallEnemy : MonoBehaviour
{
  [SerializeField] private Transform _movePoint;
  [SerializeField] private SpriteRenderer _sprite;

  private Vector3 _standartScale;
  private Tween _scaleTween;
  private Tween _moveTween;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.TryGetComponent(out PlayerHealth health))
    {
      collision.gameObject.TryGetComponent(out PlayerMove mover);
      mover.Jump();
      health.TakeDamage();
      Reset();
    }
  }

  private void Start()
  {
    _standartScale = transform.localScale;
    Move();
  }

  private void Reset()
  {
    if (_scaleTween != null)
    {
      _scaleTween.Kill();
      _moveTween.Kill();
    }

    transform.position = transform.parent.position;
    transform.localScale = _standartScale;

    Show();
  }

  private void Move()
  {
    var speed = Vector2.Distance(transform.position, _movePoint.position) / 5;

    UpScaleAnimation(speed);

    _moveTween = transform
      .DOMove(_movePoint.position, speed)
      .SetEase(Ease.InQuad)
      .OnComplete(Hide)
      .SetLink(gameObject);
  }

  private void UpScaleAnimation(float speed)
  {
    _scaleTween = transform
      .DOScale(transform.localScale * 5, speed)
      .SetEase(Ease.Linear)
      .SetLink(gameObject);
  }

  private void Show()
  {
    _sprite
      .DOFade(1, .4f)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(Move)
      .SetLink(gameObject);
  }

  private void Hide()
  {
    _sprite
      .DOFade(0, .4f)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(Reset);
  }
}