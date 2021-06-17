using UnityEngine;

[System.Serializable]
public class ProgressData {

    public int NumberOfCoins;
    public int Level;

    public ProgressData(Progress progress) {
        NumberOfCoins = progress.NumberOfCoins;
        Level = progress.Level;
    }

}
