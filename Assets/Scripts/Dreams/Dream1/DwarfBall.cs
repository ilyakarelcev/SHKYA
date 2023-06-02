using System;
using DG.Tweening;
using UnityEngine;

public class DwarfBall : MonoBehaviour
{
  [SerializeField] private Dwarf _dwarf;
  [SerializeField] private Transform _movePoint;
  [SerializeField] private float _duration;

  private void OnEnable() => _dwarf.IsRunning += Move;

  private void OnDisable() => _dwarf.IsRunning -= Move;

  private void Move()
  {
    transform
      .DOMoveX(_movePoint.position.x, _duration)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .SetUpdate(UpdateType.Fixed);
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerHealth health))
    {
      collider.TryGetComponent(out PlayerMove move);
      health.TakeDamage();
      move.Jump();

      gameObject.SetActive(false);
    }
  }
}