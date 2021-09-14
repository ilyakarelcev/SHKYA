using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour {

    public int DayIndex;
    public LevelButton[] LevelButtons;

    [ContextMenu("Setup")]
    public void Setup() {
        LevelButtons = GetComponentsInChildren<LevelButton>();
        for (int i = 0; i < LevelButtons.Length; i++) {
            LevelButtons[i].Setup(this, i);
        }
    }

    public void UpdateCalendar() {
        //if (Application.isPlaying) {
        //    SetToday(Progress.Instance.Level);
        //}
    }


    private void Start() {
        Setup();
        UpdateDays(Progress.Instance.Level);
        SelectDay(Progress.Instance.Level);
    }

    public void UpdateDays(int levelIndex) {
        DayIndex = levelIndex;
        for (int i = 0; i < LevelButtons.Length; i++) {
            if (i < levelIndex) {
                LevelButtons[i].MarkAsPast();
            } else if (i == levelIndex) {
                LevelButtons[i].MarkAsCurrent();
            } else {
                LevelButtons[i].MarkInactive();
            }
        }
    }

    public void SelectDay(int dayIndex) {
        DayIndex = dayIndex;
        for (int i = 0; i < LevelButtons.Length; i++) {
            if (i == dayIndex) {
                LevelButtons[i].MarkAsSelected();
            } else {
                LevelButtons[i].MarkAsUnselected();
            }
        }
    }

    public void Show() {
        gameObject.SetActive(true);
        SelectDay(Progress.Instance.Level);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void GoButton() {
        Hide();
        LevelManager.Instance.ShowLevel(DayIndex);
    }

}
