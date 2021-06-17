using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : HomeObject {

    public Calendar Calendar;

    public override void WhenReached() {
        base.WhenReached();
        Calendar.Show();
    }

}
