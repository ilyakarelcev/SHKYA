using DG.Tweening;
using UnityEngine;

public class AngryCloud : MonoBehaviour
{
  [SerializeField] private GameObject _lightning;
  [SerializeField] private float _speed;
  [SerializeField] private Vector3 _punchScale;
  [SerializeField] private GameObject _model;
  [SerializeField] private Collider2D _collider;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.TryGetComponent(out PlayerHealth health))
      health.TakeDamage();
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerFly player))
      Shoot(player.transform);
  }

  private void Shoot(Transform player)
  {
    _collider.enabled = false;

    _lightning.transform
      .DOLookAt(player.position, .1f, up: Vector3.down);

    _model.transform
      .DOPunchScale(_punchScale, .4f)
      .SetLink(gameObject);

    _lightning.transform
      .DOMove(player.transform.position, _speed)
      .SetEase(Ease.Flash)
      .SetLink(gameObject)
      .OnComplete(() => { _lightning.transform.position = transform.position; });
  }
}