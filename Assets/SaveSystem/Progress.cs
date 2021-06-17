using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {

    public int NumberOfCoins;
    public int Level;
    public bool HalfDone;
    public bool WorkDone;

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
        if (data != null) {
            NumberOfCoins = data.NumberOfCoins;
            Level = data.Level;
            HalfDone = data.HalfDone;
            WorkDone = data.WorkDone;
        } else {
            NumberOfCoins = 0;
            Level = 0;
            HalfDone = false;
            WorkDone = false;
        }
        
    }

    [ContextMenu("DeleteFile")]
    public void DeleteSaveFile() {
        SaveSystem.DeleteSaveFile();
    }

}
