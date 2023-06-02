using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ES3Types;
using Unity.Mathematics;
using UnityEngine;

public class SideSpawner : MonoBehaviour
{
  [SerializeField] private List<Transform> _leftDirections;
  [SerializeField] private List<Transform> _rightDirections;
  [SerializeField] private Transform _leftGun;
  [SerializeField] private Transform _rightGun;
  [SerializeField] private Bullet _bullet;
  [SerializeField] private float _coolDown;
  [SerializeField] private BossOne _boss;
  [SerializeField] private Alarm _alarm;

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    foreach (var direction in _leftDirections)
      Gizmos.DrawLine(_leftGun.transform.position, direction.position);
    foreach (var direction in _rightDirections)
      Gizmos.DrawLine(_rightGun.transform.position, direction.position);
  }

  private void OnEnable() => _alarm.IsDone += StartAttack;

  private void OnDisable() => _alarm.IsDone -= AttackAlarm;

  public void AttackAlarm() => _alarm.AlarmAnimation();

  protected virtual void StartAttack() => StartCoroutine(Attack());

  private IEnumerator Attack()
  {
    var delay = new WaitForSeconds(_coolDown);

    for (int i = 0; i < _leftDirections.Count; i++)
    {
      Bullet currentBullet = Instantiate(_bullet, _leftGun.transform.position, quaternion.identity);
      currentBullet.Move(_leftDirections[i].transform.position);

      yield return delay;
    }

    for (int i = 0; i < _rightDirections.Count; i++)
    {
      Bullet currentBullet = Instantiate(_bullet, _rightGun.transform.position, quaternion.identity);
      currentBullet.Move(_rightDirections[i].transform.position);

      yield return delay;
    }

    Delay();
  }

  private async void Delay()
  {
    await Task.Delay(5000);
    _boss.MoveToPoint();
  }
}