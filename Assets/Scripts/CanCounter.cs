using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanCounter : MonoBehaviour
{
  public int Number = 0;
  [SerializeField] private int _maxNumber = 5;
  [SerializeField] private Text _numberText;
  [SerializeField] private Image _throwButtonImage;
  [SerializeField] private AnimationCurve _animationCurve;
  [SerializeField] private float _animationTime = 0.5f;

  private void Start()
  {
    SetMaxNumber(_maxNumber);
    DisplayCans(Number);
  }

  public void SetMaxNumber(int value) => _maxNumber = value;

  public bool TryThrowOne()
  {
    if (Number > 0)
    {
      Number--;
      DisplayCans(Number);
      return true;
    }
    else
    {
      return false;
    }
  }

  public bool TryAddOne()
  {
    if (Number < _maxNumber)
    {
      AddOne();
      return true;
    }
    else
      return false;
  }

  void AddOne()
  {
    Number++;
    DisplayCans(Number);
    SoundManager.Instance.Play("CollectCan");
  }

  public void DisplayCans(int number)
  {
    StartCoroutine(ButtonAnimation());
    _numberText.text = number.ToString() + "/" + _maxNumber;
    if (number == 0)
    {
      _throwButtonImage.raycastTarget = false;
      _throwButtonImage.color = new Color(1f, 1f, 1f, 0.36f);
    }
    else
    {
      _throwButtonImage.raycastTarget = true;
      _throwButtonImage.color = new Color(1f, 1f, 1f, 1f);
    }
  }

  IEnumerator ButtonAnimation()
  {
    for (float t = 0; t < 1f; t += Time.deltaTime / _animationTime)
    {
      float scale = _animationCurve.Evaluate(t);
      _throwButtonImage.transform.localScale = Vector3.one * scale;
      yield return null;
    }

    _throwButtonImage.transform.localScale = Vector3.one;
  }
}