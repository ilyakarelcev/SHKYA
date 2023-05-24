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

  private Randomizer _randomizer;
  private bool _preFight = true;

  private void Start()
  {
    StartCoroutine(BossTimer());
    BossSpawner();
  }

  private IEnumerator BossTimer()
  {
    _randomizer = new Randomizer(_spawnPoints.Count - 1);
    var delay = new WaitForSeconds(_topSpawnerDelay);

    while (_preFight)
    {
      int index = _randomizer.SelectNoRepeat();
      Instantiate(_missle, _spawnPoints[index].position, quaternion.identity);
      yield return delay;
    }

    yield return null;
  }

  public void JumpAttack()
  {
    for (int i = 0; i < _jumpMissileValue; i++)
    {
      int index = _randomizer.SelectNoRepeat();
      Instantiate(_missle, _spawnPoints[index].position, quaternion.identity);
    }

    _boss.Move();
  }

  private async void BossSpawner()
  {
    await Task.Delay(_bossCoolDown);
    _boss.gameObject.SetActive(true);
    _preFight = false;
  }
}