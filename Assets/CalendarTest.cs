using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarTest : MonoBehaviour {

    public Calendar Calendar;
    public int DayNumber;
    
    [ContextMenu("SetToday")]
    public void SetToday() {
        Calendar.SetToday(DayNumber);
    }

}
