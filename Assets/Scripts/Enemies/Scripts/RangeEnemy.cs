using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private LayerMask _layerMask;
  [SerializeField] private int _coolDown;
  [SerializeField] private Transform _shootPoint;
  [SerializeField] private GameObject _missile;
  [SerializeField] private GameObject CoinEffectPrefab;

  private bool _haveTarget;
  private bool _isShoot;

  private void Update()
  {
    FindPlayer();

    if (!_haveTarget) return;
    if (_isShoot) return;

    Shoot();
  }

  private void Shoot()
  {
    _isShoot = true;

    _missile.SetActive(true);
    _missile.transform.DOJump(_player.transform.position, 2f, 1, 2)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .SetUpdate(UpdateType.Fixed)
      .OnComplete(() =>
      {
        CoolDown();
        _missile.SetActive(false);
        _missile.transform.position = _shootPoint.transform.position;
      });
  }

  private void FindPlayer()
  {
    _haveTarget = Physics2D.OverlapCircle
      (transform.position, 5, _layerMask);
  }

  private async void CoolDown()
  {
    await Task.Delay(1000);
    _isShoot = false;
  }
}