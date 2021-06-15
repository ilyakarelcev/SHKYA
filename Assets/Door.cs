using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : HomeObject {

    [SerializeField] private Home _home;

    public override void WhenReached() {
        base.WhenReached();
        _home.StartLevel();
    }

}
