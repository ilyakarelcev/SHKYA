using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
using UnityEngine.UI;
using System;

public class Vibration : MonoBehaviour {

    public HapticTypes CurrentHapticType;
    public Dropdown Dropdown;

    private void Start() {
        string[] names = Enum.GetNames(typeof(HapticTypes));
        List<string> namesLisst = new List<string>(names);
        Dropdown.AddOptions(namesLisst);
    }

    public void SelectFromDropdown(int index) {
        CurrentHapticType = (HapticTypes)index;
    }

    public void SetHapticsActive(bool value) {
        MMVibrationManager.SetHapticsActive(value);
    }

    public void Vibrate() {
        //Debug.Log("Vibrate");
        MMVibrationManager.Haptic(CurrentHapticType, false, true, this);
    }

}
