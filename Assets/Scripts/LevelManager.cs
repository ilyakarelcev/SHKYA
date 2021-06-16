using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField] private GameObject PlatformerObject;

    [SerializeField] private GameObject HomeObject;
    [SerializeField] private GameObject OfficeObject;

    [SerializeField] private Level[] _allLevels;
    [SerializeField] private Transform PlayerTransform;
    private int _currentLevelIndex = 0;
    public static LevelManager Instance;

    public int CurrentDay;
    public Text CurrentDayText;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        //ShowHome();
        SetCurrentDay(0);
    }

    public void SetCurrentDay(int value) {
        CurrentDay = value;
        CurrentDayText.text = "Δενό " + (value + 1).ToString();
    }

    

    public void SetLevelIndex(int index) {
        _currentLevelIndex = index;
    }

    public void ShowHome() {
        HideAllLevels();

        OfficeObject.SetActive(false);
        HomeObject.SetActive(true);
    }
    public void ShowOffice() {
        HideAllLevels();

        OfficeObject.SetActive(true);
        HomeObject.SetActive(false);
    }

    void HideAllLevels() {
        foreach (var level in _allLevels) {
            level.Hide();
        }
        PlatformerObject.SetActive(false);
    }


    public void StartLevel() {
        ShowLevel(_currentLevelIndex);
    }

    public void ShowLevel(string levelName) {
        for (int i = 0; i < _allLevels.Length; i++) {
            if (_allLevels[i].LevelName == levelName) {
                ShowLevel(i);
            }
        }
    }

    public void ShowLevel(int levelIndex) {
        HideAllLevels();
        Level level = _allLevels[levelIndex];
        level.Show();
        PlayerTransform.position = level.PlayerStartPoint.position;

        PlatformerObject.SetActive(true);
        HomeObject.SetActive(false);
        OfficeObject.SetActive(false);
    }

}
