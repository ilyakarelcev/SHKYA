using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sun : MonoBehaviour
{
  [SerializeField] private Dwarf _dwarf;
  [SerializeField] private SpriteRenderer _sprite;
  [SerializeField] private Transform _movePoint;
  [SerializeField] private float _moveDuration;
  [SerializeField] private List<Transform> _shootDirections;

  [SerializeField] private List<GameObject> _walls;

  private void OnEnable() => _dwarf.InBossRoom += Show;

  private void OnDisable() => _dwarf.InBossRoom -= Show;

#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawLine(transform.position, _movePoint.position);

    Gizmos.color = Color.red;
    foreach (var direction in _shootDirections)
      Gizmos.DrawLine(transform.position, direction.position);
  }
#endif

  private void Show()
  {
    _sprite.DOFade(1, .5f).OnComplete(() =>
    {
      foreach (var wall in _walls)
        wall.SetActive(true);

      Move();
    });
  }

  private void Move()
  {
    transform
      .DOMove(_movePoint.position, _moveDuration)
      .SetEase(Ease.Linear)
      .SetUpdate(UpdateType.Fixed);
  }
}