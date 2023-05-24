using UnityEngine;
using UnityEngine.SceneManagement;

public class Calendar : MonoBehaviour
{
  [SerializeField] private LevelChooser _levelChooser;

  public LevelButton[] LevelButtons;

  private int _dayIndex;

  private void Start()
  {
    _dayIndex = Saves.LoadLastLevelIndex();

    Setup();
    UpdateDays(_dayIndex);
    SelectDay(_dayIndex);
  }

  [ContextMenu("Setup")]
  public void Setup()
  {
    LevelButtons = GetComponentsInChildren<LevelButton>();
    for (int i = 0; i < LevelButtons.Length; i++)
    {
      LevelButtons[i].Setup(this, i+1);
    }
  }

  public void UpdateCalendar()
  {
    //if (Application.isPlaying) {
    //    SetToday(Progress.Instance.Level);
    //}
  }

  public void UpdateDays(int levelIndex)
  {
    for (int i = 0; i < LevelButtons.Length; i++)
    {
      if (i < levelIndex)
        LevelButtons[i].MarkAsPast();
      else if (i == levelIndex)
        LevelButtons[i].MarkAsCurrent();
      else
        LevelButtons[i].MarkInactive();
    }
  }

  public void SelectDay(int dayIndex)
  {
    for (int i = 0; i < LevelButtons.Length; i++)
    {
      if (i == dayIndex)
        LevelButtons[i].MarkAsSelected();
      else
        LevelButtons[i].MarkAsUnselected();
    }
  }

  public void Show()
  {
    gameObject.SetActive(true);
    SelectDay(_dayIndex);
  }

  public void Hide() => gameObject.SetActive(false);

  public void GoButton()
  {
    Hide();
    _levelChooser.SelectNextLevel();
  }
}