using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GG.Infrastructure.Utils;
using Unity.Mathematics;
using UnityEngine;

public class TopSpawner : MonoBehaviour
{
  [SerializeField] private List<Transform> _spawnPoints;
  [SerializeField] private MissleTop _missle;
  [SerializeField] private float _topSpawnerDelay;
  [SerializeField] private BossOne _boss;
  [SerializeField] private int _bossCoolDown;
  [SerializeField] private int _jumpMissileValue;
  [SerializeField] private Alarm _alarm;
  [SerializeField] private Chairs _chairs;

  private Randomizer _randomizer;
  private bool _preFight = true;

  private void OnEnable() => _alarm.IsDone += JumpAttack;

  private void OnDisable() => _alarm.IsDone -= JumpAttack;

  private void Start()
  {
    StartCoroutine(BossTimer());
    if (_preFight == false) return;
    BossSpawner();
  }

  private IEnumerator BossTimer()
  {
    _randomizer = new Randomizer(_spawnPoints.Count);
    var delay = new WaitForSeconds(_topSpawnerDelay);

    while (_preFight)
    {
      int index = _randomizer.SelectNoRepeat();
      Instantiate(_missle, _spawnPoints[index].position, quaternion.identity);
      yield return delay;
    }

    yield return null;
  }

  public void AttackAlarm() => _alarm.AlarmAnimation();

  private async void JumpAttack()
  {
    for (int i = 0; i < _jumpMissileValue; i++)
    {
      int index = _randomizer.SelectNoRepeat();
      Instantiate(_missle, _spawnPoints[index].position, quaternion.identity);
    }

    await Task.Delay(3000);
    _boss.MoveToPoint();
  }

  private async void BossSpawner()
  {
    if (_preFight == false) return;

    await Task.Delay(_bossCoolDown);
    _boss.gameObject.SetActive(true);
    // _chairs.gameObject.SetActive(false);
    _preFight = false;
  }
}