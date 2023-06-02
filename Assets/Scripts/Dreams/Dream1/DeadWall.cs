using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DeadWall : MonoBehaviour
{
  [SerializeField] private float _firstRoomDuration;
  [SerializeField] private List<Transform> _pathPoints;
  [SerializeField] private Collider2D _collider;
  [SerializeField] private SpriteRenderer _renderer;
  [SerializeField] private Dwarf _dwarf;
  [SerializeField] private GameManager _gameManager;
  
  private Vector3[] _path;
  private Sequence _sequence;

#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;

    for (int i = 0; i < _pathPoints.Count - 1; i++)
      Gizmos.DrawLine(_pathPoints[i].position, _pathPoints[i + 1].position);
  }
#endif

  private void OnEnable() => _dwarf.InBossRoom += Hide;

  private void OnDisable() => _dwarf.InBossRoom -= Hide;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerMove player))
    {
      _collider.enabled = false;
      FirstDeadMove();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.TryGetComponent(out PlayerHealth player))
    {
      SoundManager.Instance.Play("Water");
      _gameManager.Lose();
    }
  }

  private void FirstDeadMove()
  {
    _path = new Vector3[_pathPoints.Count];

    for (int i = 0; i < _path.Length; i++)
      _path[i] = _pathPoints[i].position;

    transform
      .DOPath(_path, _firstRoomDuration, PathType.CatmullRom)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .SetLookAt(.01f, transform.right)
      .SetUpdate(UpdateType.Fixed);
  }

  private void Hide()
  {
    _renderer
      .DOFade(0, .5f)
      .OnComplete(() => gameObject
        .SetActive(false));
  }

  // private void BossMove()
  // {
  //   transform.DORotate(new Vector3(0, 0, 145f), .1f);
  //   transform.DOScaleY(14, .1f);
  //
  //   transform
  //     .DOMove(_bossRoomPoint.position, _bossRoomDuration)
  //     .SetEase(Ease.Linear)
  //     .SetLink(gameObject)
  //     .SetUpdate(UpdateType.Fixed);
  // }
  //
  // private void BigRoomMove()
  // {
  //   _sequence = DOTween.Sequence();
  //
  //   _path = new Vector3[_bigRoomPath.Count];
  //
  //   for (int i = 0; i < _path.Length; i++)
  //     _path[i] = _bigRoomPath[i].position;
  //
  //   _sequence
  //     .Append(transform
  //       .DOScaleY(transform.localScale.y * 4, .5f)
  //       .SetEase(Ease.Flash))
  //     .Append(transform
  //       .DOPath(_path, 7f, PathType.CatmullRom)
  //       .SetEase(Ease.Linear)
  //       .SetLink(gameObject))
  //     .Append(transform
  //       .DOScaleY(8, .5f));
  // }
}