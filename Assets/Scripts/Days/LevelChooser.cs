using System.Collections.Generic;
using UnityEngine;

public class LevelChooser : MonoBehaviour
{
  [SerializeField] private List<Level> _levels;
  [SerializeField] private GameObject _platformer;

  private Level _currentLevel;
  private int _currentLevelIndex;
  private int _levelIndex;

  private void Start() => CheckSave();

  private void CheckSave()
  {
    _currentLevel = _levels[Saves.LoadLastLevelIndex()];
    _currentLevel.gameObject.SetActive(true);

    if (_currentLevel._isPlatformer)
      _platformer.SetActive(true);
  }

  public void ChangeLevelIndex(int index)
  {
    _levelIndex = index;
  }

  public void SelectNextLevel()
  {
    if (_levelIndex < Saves.LoadLastLevelIndex()+1)
    {
      _currentLevelIndex = _levelIndex;
      print("с кнопки меньше или равен");
    }

    else
    {
      print("с кнопки ");
      _currentLevelIndex = Saves.LoadLastLevelIndex()+1;
    }
      

    _currentLevel.gameObject.SetActive(false);
    _platformer.SetActive(false);

    _currentLevel = _levels[_currentLevelIndex];
    _currentLevel.gameObject.SetActive(true);
    if (_currentLevel._isPlatformer)
      _platformer.SetActive(true);
  }
}