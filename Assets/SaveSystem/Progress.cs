using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {

    public int NumberOfCoins;
    public int Level;

    public static Progress Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        // Загружаем данные из файла при запуске
        Load();
    }


    public void Save() {
        SaveSystem.SaveProgress(this);
    }

    public void Load() {
        ProgressData data = SaveSystem.Load();
        NumberOfCoins = data.NumberOfCoins;
        Level = data.Level;
    }

}
