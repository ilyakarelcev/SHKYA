using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoor : HomeObject {

    [TextArea]
    [SerializeField] private string _stringToSay;
    public Office Office;
    [SerializeField] private string LevelName = "Level2";

    public override void WhenReached() {
        base.WhenReached();
        if (Office.IsWorkDone) {
            FadeScreen.Instance.StartFade(1f);
            Invoke(nameof(GoOut),1f);
        } else {
            PlayerSay.Instance.Say(_stringToSay, 3.5f);
        }
        
    }

    public void GoOut() {
        LevelManager.Instance.ShowLevel(LevelName);
    }

}
