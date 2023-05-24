using DG.Tweening;
using UnityEngine;

public class ThrowGuide : MonoBehaviour
{
  [SerializeField] private CanvasGroup _canvas;

  private void OnTriggerEnter2D(Collider2D collider) => _canvas.DOFade(1f, .5f);

  private void OnTriggerExit2D(Collider2D collider) => _canvas.DOFade(0f, .5f);
}