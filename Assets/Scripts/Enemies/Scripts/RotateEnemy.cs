using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
  [SerializeField] private List<Transform> _shootDirections;
  [SerializeField] private List<RotatorBullet> _bullets;
  [SerializeField] private float _shootCoolDown;

  private Vector3 _rotateValue = new Vector3(0, 0, 45);
  private Vector3 _rotateModifire = new Vector3(0, 0, 45);

#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.yellow;
    foreach (var point in _shootDirections)
      Gizmos.DrawLine(transform.position, point.position);
  }
#endif

  private void Start() => Shoot();

  private void Shoot()
  {
    for (int i = 0; i < _bullets.Count; i++)
      _bullets[i].Move(_shootDirections[i], _shootCoolDown);

    Rotate();
  }

  private void Rotate()
  {
    transform
      .DORotate(_rotateValue, .5f)
      .SetDelay(_shootCoolDown + .3f)
      .SetLink(gameObject)
      .OnComplete(() =>
      {
        _rotateValue += _rotateModifire;
        Shoot();
      });
  }
}