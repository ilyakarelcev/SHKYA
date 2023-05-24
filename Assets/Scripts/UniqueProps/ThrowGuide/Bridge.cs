using DG.Tweening;
using UnityEngine;

public class Bridge : MonoBehaviour
{
  [SerializeField] private GameObject _button;
  [SerializeField] private GameObject _throwGuide;
  [SerializeField] private CanSpawner _canSpawner;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out Can can))
      Open();
  }

  private void Open()
  {
    _canSpawner.gameObject.SetActive(false);
    _throwGuide.SetActive(false);
    _button.SetActive(false);

    transform
      .DORotate(new Vector3(0, 0, 0), 1f)
      .SetEase(Ease.Linear);
  }
}