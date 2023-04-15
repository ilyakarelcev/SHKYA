//using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HomeObject : MonoBehaviour {

    public Transform PlayerTarget;
    [SerializeField] private PlayerAtHome _playerAtHome;

    private void OnMouseUpAsButton() {
        _playerAtHome.MoveToObject(this);
        //MMVibrationManager.Haptic(HapticTypes.Selection, false, true, this);
    }

    public virtual void WhenReached() {
    }

}
