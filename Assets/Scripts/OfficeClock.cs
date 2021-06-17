using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeClock : HomeObject {

    public GameObject Time9;
    public GameObject Time18;
    //[SerializeField] private Office _office;

    public void Show9() {
        Time9.SetActive(true);
        Time18.SetActive(false);
    }

    public void Show18() {
        Time9.SetActive(false);
        Time18.SetActive(true);
    }

    public override void WhenReached() {
        base.WhenReached();
        if (Progress.Instance.WorkDone) {
            PlayerSay.Instance.Say("Что я здесь делаю? \n рабочий день окончен", 3f);
        } else {
            PlayerSay.Instance.Say("День только начался, \n а я уже устал", 3f);
        }
    }

}
