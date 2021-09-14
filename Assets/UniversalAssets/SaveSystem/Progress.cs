using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {

    public int NumberOfCoins;
    public int Level;
    public static Progress Instance;


    public bool WorkDone {
        get {
            return Level % 4 > 1;
        }
    }

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
        if (data != null) {
            NumberOfCoins = data.NumberOfCoins;
            Level = data.Level;
        } else {
            NumberOfCoins = 0;
            Level = 0;
        }
        
    }

    [ContextMenu("DeleteFile")]
    public void DeleteSaveFile() {
        SaveSystem.DeleteSaveFile();
    }

}
