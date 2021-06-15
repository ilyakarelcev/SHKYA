using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeComputer : HomeObject {

    [Header("OfficeComputer")]
    [SerializeField] private string WorkLevelName = "WorkLevel";

    public override void WhenReached() {
        base.WhenReached();
        StartWorkGame();
    }

    void StartWorkGame() {
        LevelManager.Instance.ShowLevel(WorkLevelName);
    }

}
