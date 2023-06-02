using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Chairs : MonoBehaviour
{
  [SerializeField] private Chair _chairOne;
  [SerializeField] private Chair _chairTwo;
  [SerializeField] private Transform _spawn;
  [SerializeField] private Transform _movePoint;

  private void Start()
  {
    OneChair();
  }

  private async void OneChair()
  {
    await Task.Delay(1000);

    _chairOne.gameObject.SetActive(true);
    _chairOne.transform.position = _spawn.position;

    _chairOne.transform
      .DOMoveX(_movePoint.position.x, 3f)
      .SetLink(gameObject)
      .SetEase(Ease.Linear)
      .SetLoops(2,LoopType.Yoyo)
      .OnComplete(() =>
      {
        _chairOne.gameObject.SetActive(false);
        TwoChairs();
      });
  }

  private async void TwoChairs()
  {
    await Task.Delay(1000);

    _chairTwo.gameObject.SetActive(true);
    _chairTwo.transform.position = _spawn.position;

    _chairTwo.transform
      .DOMoveX(_movePoint.position.x, 3f)
      .SetLink(gameObject)
      .SetEase(Ease.Linear)
      .SetLoops(2,LoopType.Yoyo)
      .OnComplete(() =>
      {
        _chairTwo.gameObject.SetActive(false);
        OneChair();
      });
  }
}