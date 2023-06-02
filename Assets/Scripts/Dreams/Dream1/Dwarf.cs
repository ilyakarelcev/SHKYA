using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Dwarf : MonoBehaviour
{
  [SerializeField] private Transform _firstPlatformPoint;
  [SerializeField] private Transform _secondPlatformPoint;
  [SerializeField] private List<Transform> _skyPointsBeforeBoss;

  [FormerlySerializedAs("_skyPoints")] [SerializeField]
  private List<Transform> _skyPointsAfterBoss;

  [SerializeField] private Collider2D _collider;
  [SerializeField] private float _firstPlatformDuration;
  [SerializeField] private float _durationBeforeBoss;
  [SerializeField] private float _durationAfterBoss;
  [SerializeField] private float _durationInBoss;

  private Vector3[] _path;
  private bool _firstStage = true;
  private bool _secondStage = false;
  private bool _thirdStage = false;
  private bool _lastMove = false;

  public event Action IsRunning;
  public event Action InBossRoom;

#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    for (int i = 0; i < _skyPointsAfterBoss.Count - 1; i++)
      Gizmos.DrawLine(_skyPointsAfterBoss[i].position, _skyPointsAfterBoss[i + 1].position);
  }
#endif

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerMove player))
    {
      _collider.enabled = false;
      if (_firstStage)
        Move();
      if (_secondStage)
        FirstMove();
      if (_thirdStage)
        SecondMove();
      if (_lastMove)
        LastMove();
    }
  }

  private void Move()
  {
    IsRunning?.Invoke();
    _firstStage = false;

    transform
      .DOMoveX(_firstPlatformPoint.position.x, _firstPlatformDuration)
      .SetEase(Ease.Linear)
      .SetUpdate(UpdateType.Fixed)
      .SetLink(gameObject)
      .OnComplete(() =>
      {
        _secondStage = true;
        _collider.enabled = true;
      });
  }

  private void FirstMove()
  {
    _secondStage = false;

    _path = new Vector3[_skyPointsBeforeBoss.Count];
    for (int i = 0; i < _path.Length; i++)
      _path[i] = _skyPointsBeforeBoss[i].position;

    transform
      .DOPath(_path, _durationBeforeBoss, PathType.CatmullRom)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .SetUpdate(UpdateType.Fixed)
      .OnComplete(() =>
      {
        _collider.enabled = true;
        _thirdStage = true;
      });
  }

  private void SecondMove()
  {
    InBossRoom?.Invoke();
    _collider.enabled = false;

    transform
      .DOMove(_skyPointsAfterBoss[0].position, _durationInBoss)
      .SetUpdate(UpdateType.Fixed)
      .SetEase(Ease.Linear).OnComplete(() =>
      {
        _lastMove = true;
        _collider.enabled = true;
      });
  }

  private void LastMove()
  {
    _collider.enabled = false;

    _path = new Vector3[_skyPointsAfterBoss.Count];
    for (int i = 0; i < _path.Length; i++)
      _path[i] = _skyPointsAfterBoss[i].position;

    transform
      .DOPath(_path, _durationAfterBoss, PathType.CatmullRom)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .SetUpdate(UpdateType.Fixed);
  }
}