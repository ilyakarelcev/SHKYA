using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeComputer : HomeObject {

    [Header("OfficeComputer")]
    [SerializeField] private string WorkLevelName = "WorkLevel";
    [TextArea]
    [SerializeField] private string _stringToSay;
    [TextArea]
    [SerializeField] private string _stringToSayWorkDone;
    public Office Office;

    public override void WhenReached() {
        base.WhenReached();
        if (Office.IsWorkDone) {
            PlayerSay.Instance.Say(_stringToSayWorkDone, 3.5f);
        } else {
            PlayerSay.Instance.Say(_stringToSay, 3.5f);
            FadeScreen.Instance.StartFade(1f);
            Invoke(nameof(StartWorkGame), 1f);
        }
        
    }


    void StartWorkGame() {
        LevelManager.Instance.ShowLevel(WorkLevelName);
    }

}