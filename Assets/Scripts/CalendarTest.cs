using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarTest : MonoBehaviour {

    public Calendar Calendar;
    public int DayNumber;
    
    [ContextMenu("SetToday")]
    public void SetToday() {
        Calendar.UpdateDays(DayNumber);
    }

    [ContextMenu("SelectDay")]
    public void SelectDay() {
        Calendar.SelectDay(DayNumber);
    }

}
