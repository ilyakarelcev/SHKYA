using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanEnemy : MonoBehaviour
{
  [SerializeField] private List<FanBullet> _bullets;
  [SerializeField] private List<Transform> _shootPoints;
  [SerializeField] private int _shootCoolDown;

  private void Start() => Shoot();

  private void Shoot()
  {
    for (int i = 0; i < _bullets.Count; i++)
      _bullets[i].Move(_shootPoints[i], _shootCoolDown - 1);

    StartCoroutine(Delay());
  }

  private IEnumerator Delay()
  {
    var delay = new WaitForSeconds(_shootCoolDown);

    yield return delay;
    Shoot();
  }
}