using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoor : HomeObject {

    [TextArea]
    [SerializeField] private string _stringToSay;

    public override void WhenReached() {
        base.WhenReached();
        PlayerSay.Instance.Say(_stringToSay, 5f);
    }
}
