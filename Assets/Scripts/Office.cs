using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour {

    public OfficeClock OfficeClock;

    public void Show() {
        gameObject.SetActive(true);
        if (Progress.Instance.WorkDone) {
            OfficeClock.Show18();
        } else {
            OfficeClock.Show9();
        }
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}
