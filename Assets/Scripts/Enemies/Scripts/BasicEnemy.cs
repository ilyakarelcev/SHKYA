using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class BasicEnemy : MonoBehaviour
{
  [SerializeField] private float _speed;
  [SerializeField] private List<Transform> _movePoints;

  private Sequence _sequence;

  private void Start()
  {
    // Move();
  }

  private void Move()
  {
    _sequence = DOTween.Sequence();


    _sequence
      .Append(transform
        .DOMove(_movePoints[0].position, 1f))
      .Append(transform
        .DOJump(_movePoints[1].position, 3f, 1, 1f))
      .Append(transform
        .DOMove(_movePoints[2].position, 1f))
      .SetEase(Ease.Linear);

    _sequence
      .SetLoops(-1, LoopType.Yoyo);
  }
}