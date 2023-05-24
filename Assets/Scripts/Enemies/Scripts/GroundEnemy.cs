using DG.Tweening;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private LayerMask _layerMask;
  [SerializeField] private GameObject _missile;
  [SerializeField] private int _shootDistance;
  [SerializeField] private Transform _shootPoint;
  [SerializeField] private float _duration = 3f;
  [SerializeField] private BoxCollider2D _collider;
  [SerializeField] private GameObject CoinEffectPrefab;

  private bool _haveTarget;
  private Vector2 _direction;
  private bool _isShoot;
  private bool _inGround;

  private void Update()
  {
    FindPlayer();

    if (!_haveTarget) return;
    if (_inGround) return;
    if (_isShoot) return;

    Shoot();
  }

  private void FindPlayer()
  {
    _haveTarget = Physics2D.OverlapCircle
      (transform.position, 5, _layerMask);
  }

  private void Shoot()
  {
    _direction = (_player.transform.position - transform.position).normalized;

    _isShoot = true;

    Show();

    _missile.SetActive(true);
    _missile.transform
      .DOLocalMove(_direction * _shootDistance, _duration)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(() =>
      {
        _missile.SetActive(false);
        _missile.transform.position = _shootPoint.position;
        Hide();
      });
  }

  private void Hide()
  {
    transform.DOScaleY(0, 1f)
      .SetLink(gameObject)
      .OnComplete(() =>
      {
        _collider.enabled = false;
        _isShoot = false;
        _inGround = true;
        Show();
      });
  }

  private void Show()
  {
    transform
      .DOScaleY(1, .1f)
      .SetLink(gameObject)
      .OnComplete(() =>
      {
        _inGround = false;
        _collider.enabled = true;
      });
  }
}