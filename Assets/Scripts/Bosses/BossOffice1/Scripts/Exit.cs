using DG.Tweening;
using UnityEngine;

public class Exit : MonoBehaviour
{
  [SerializeField] private SpriteRenderer _sprite;

  private void Awake()
  {
    _sprite
      .DOColor(Color.green, 1f)
      .SetLink(gameObject)
      .SetEase(Ease.Linear);
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerMove player))
      print("load next scene");
  }
}