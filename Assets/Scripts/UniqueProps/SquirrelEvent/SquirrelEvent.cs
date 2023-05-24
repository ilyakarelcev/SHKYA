using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquirrelEvent : MonoBehaviour
{
  
  [SerializeField] private List<string> _words;
  [SerializeField] private List<Acorn> _acorns;
  [SerializeField] private string _defaultWord;
  [SerializeField] private Button _acornButton;
  [SerializeField] private CanvasGroup _canvas;
  [SerializeField] private TMP_Text _squirrelText;
  [SerializeField] private TMP_Text _acornValue;
  [SerializeField] private Button _button;
  [SerializeField] private Transform _playerPosition;
  [SerializeField] private GameObject _accornMissile;
  [SerializeField] private Transform Squirrel;
  [SerializeField] private GameObject _gates;


  private int _currentWordIndex = 0;
  private int _currentValue = 0;

  private void Start() => _squirrelText.text = _currentValue.ToString();

  private void OnEnable()
  {
    foreach (var acorn in _acorns)
      acorn.IsTaken += ChangeAcornCounter;

    _button.onClick.AddListener(ShootAcorn);
  }

  private void OnDisable()
  {
    foreach (var acorn in _acorns)
      acorn.IsTaken -= ChangeAcornCounter;

    _button.onClick.RemoveListener(ShootAcorn);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.TryGetComponent(out Player player)) return;

    _canvas.DOFade(1f, .3f);
    _squirrelText.text = _defaultWord;
    _acornButton.gameObject.SetActive(true);
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (!other.TryGetComponent(out Player player)) return;

    _canvas.DOFade(0f, .3f);
    _acornButton.gameObject.SetActive(false);
  }

  private void ChangeAcornCounter()
  {
    _currentValue++;
    _acornValue.text = Convert.ToString(_currentValue);
  }

  private void ShootAcorn()
  {
    if (_currentValue == 0) return;

    _currentValue--;

    var currentAcorn = Instantiate(_accornMissile, _playerPosition.position, Quaternion.identity, transform);
    currentAcorn.transform
      .DOJump(Squirrel.position, 2, 1, 1f)
      .SetEase(Ease.Linear)
      .OnComplete(() => ChangeText());

    _acornValue.text = Convert.ToString(_currentValue);
  }

  private void ChangeText()
  {
    _squirrelText.text = _words[_currentWordIndex];

    if (_currentWordIndex == 4)
      OpenGates();

    _currentWordIndex++;
  }

  [ContextMenu("Открыть ворота")]
  private void OpenGates()
  {
    gameObject.SetActive(false);
  }
}