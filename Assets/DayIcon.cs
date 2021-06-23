using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DayIcon : MonoBehaviour, IPointerClickHandler {

    public int DayIndex;
    public Image Image;
    public Text NumberText;
    //public GameObject Cross;
    //public GameObject TodayCheckmark;
    public Image SelectionCheckmark;
    public Calendar Calendar;

    public void MarkAsPast() {
        Debug.Log("MarkAsPast");
        SetAlpha(1f);
        Image.raycastTarget = true;
        //Cross.SetActive(true);
        //TodayCheckmark.SetActive(false);
    }

    public void MarkAsToday() {
        Debug.Log("MarkAsToday");
        SetAlpha(1f);
        Image.raycastTarget = true;
        //Cross.SetActive(false);
        //TodayCheckmark.SetActive(true);
    }

    public void MarkAsSelected() {
        //SelectionCheckmark.enabled = true;
        StartCoroutine(AnimateCircle());
    }

    public void MarkAsUnselected() {
        SelectionCheckmark.enabled = false;
    }

    public IEnumerator AnimateCircle() {
        SelectionCheckmark.enabled = true;
        for (float t = 0; t < 1f; t+=Time.deltaTime * 3f) {
            SelectionCheckmark.fillAmount = t;
            yield return null;
        }
        SelectionCheckmark.fillAmount = 1f;
    }

    public void MarkInactive() {
        Debug.Log("MarkInactive");
        SetAlpha(0.3f);
        Image.raycastTarget = false;
        //Cross.SetActive(false);
        //TodayCheckmark.SetActive(false);
    }

    public void SetAlpha(float value) {
        Color c = Image.color;
        c.a = value;
        Image.color = c;

        Color textColor = NumberText.color;
        textColor.a = value;
        NumberText.color = textColor;
    }

    public void Setup(Calendar calendar, int index) {
        DayIndex = index;
        NumberText.text = (index + 1).ToString();
        Calendar = calendar;
    }

    public void OnPointerClick(PointerEventData eventData) {
        Calendar.SelectDay(DayIndex);
    }
}
