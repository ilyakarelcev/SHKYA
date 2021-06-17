using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour {

    public int DayIndex;
    public DayIcon[] DayIcons;

    public void UpdateCalendar() {
        SetToday(Progress.Instance.Level);
    }

    public void SetToday(int dayIndex) {
        DayIndex = dayIndex;
        for (int i = 0; i < DayIcons.Length; i++) {
            if (i < dayIndex) {
                DayIcons[i].MarkAsPast();
            } else if (i == dayIndex) {
                DayIcons[i].MarkAsToday();
            } else {
                DayIcons[i].MarkInactive();
            }
        }
    }

    public void SelectDay(int dayIndex) {
        DayIndex = dayIndex;
        for (int i = 0; i < DayIcons.Length; i++) {
            if (i == dayIndex) {
                DayIcons[i].MarkAsSelected();
            } else {
                DayIcons[i].MarkAsUnselected();
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
        LevelManager.Instance.ShowLevel(DayIndex * 2); // Перескакиваем через уровень с походом домой
    }

}
