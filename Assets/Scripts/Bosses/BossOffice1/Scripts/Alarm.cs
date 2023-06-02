using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Alarm : MonoBehaviour
{
  [SerializeField] private List<SpriteRenderer> _sprite;

  private Sequence _sequence;
  private Sequence _sequence2;

  public event Action IsDone;

  public void AlarmAnimation()
  {
    _sequence = DOTween.Sequence();
    _sequence2 = DOTween.Sequence();

    if (_sprite.Count == 1)
    {
      foreach (var sprite in _sprite)
      {
        _sequence
          .Append(sprite.DOColor(Color.red, .3f).SetLink(gameObject))
          .Append(sprite.DOColor(Color.clear, .3f).SetLink(gameObject))
          .SetLink(gameObject);
      }
    }
    else
    {
      _sequence
        .Append(_sprite[0].DOColor(Color.red, .3f).SetLink(gameObject))
        .Append(_sprite[0].DOColor(Color.clear, .3f).SetLink(gameObject))
        .SetLink(gameObject);

      _sequence2
        .Append(_sprite[1].DOColor(Color.red, .3f).SetLink(gameObject))
        .Append(_sprite[1].DOColor(Color.clear, .3f).SetLink(gameObject))
        .SetLink(gameObject);
    }

    IsDone?.Invoke();
  }
}