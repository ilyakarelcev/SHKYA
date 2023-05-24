using DG.Tweening;
using UnityEngine;

public class CanSpawner : MonoBehaviour
{
  [SerializeField] private GameObject _can;
  [SerializeField] private Transform _canSpawnPoint;
  [SerializeField] private CanCounter _canCounter;
  [SerializeField] private CanvasGroup _canvas;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (_canCounter.Number == 0)
      SpawnCan();
    else
      _canvas.DOFade(1f, .3f);
  }

  private void OnTriggerExit2D(Collider2D other) => _canvas.DOFade(0f, .3f);

  private void SpawnCan() => Instantiate(_can, _canSpawnPoint.position, Quaternion.identity);
}