using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour {

    public Office�lock Office�lock;

    public void Show() {
        gameObject.SetActive(true);
        if (Progress.Instance.WorkDone) {
            Office�lock.Show18();
        } else {
            Office�lock.Show9();
        }
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}
