using UnityEngine;

[System.Serializable]
public class ProgressData {

    public int NumberOfCoins;
    public int Level;
    public bool HalfDone;
    public bool WorkDone;

    public ProgressData(Progress progress) {
        NumberOfCoins = progress.NumberOfCoins;
        Level = progress.Level;
        HalfDone = progress.HalfDone;
        WorkDone = progress.WorkDone;
    }

}
