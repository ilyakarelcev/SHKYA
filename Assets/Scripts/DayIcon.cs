using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DayIcon : MonoBehaviour, IPointerClickHandler {

    public int LevelIndex;
    public Image RaycastImage;
    public Image IconImage;
    public Text LevelNameText;
    public Image StarImage;

    public Calendar Calendar;

    public void MarkAsPast() {
        SetAlpha(1f);
        IconImage.raycastTarget = true;
    }

    public void MarkAsSelected() {
        //
    }

    public void MarkInactive() {
        Debug.Log("MarkInactive");
        SetAlpha(0.3f);
        IconImage.raycastTarget = false;
    }

    public void SetAlpha(float value) {
        Color c = IconImage.color;
        c.a = value;
        IconImage.color = c;
        Color textColor = LevelNameText.color;
        textColor.a = value;
        LevelNameText.color = textColor;
    }

    public void Setup(Calendar calendar, int index) {
        LevelIndex = index;
        LevelNameText.text = (index + 1).ToString();
        Calendar = calendar;
    }

    public void OnPointerClick(PointerEventData eventData) {
        Calendar.SelectDay(LevelIndex);
    }
}
