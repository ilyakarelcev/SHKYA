using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeObject : MonoBehaviour {

    public Transform PlayerTarget;
    private PlayerAtHome _playerAtHome;

    private void Start() {
        _playerAtHome = FindObjectOfType<PlayerAtHome>();
    }

    private void OnMouseUpAsButton() {
        _playerAtHome.MoveToObject(this);
        MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
    }

    public virtual void WhenReached() {
    }

}
