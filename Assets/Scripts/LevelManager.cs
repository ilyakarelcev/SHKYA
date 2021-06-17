using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField] private GameObject PlatformerObject;

    //[SerializeField] private GameObject HomeObject;
    //[SerializeField] private GameObject OfficeObject;
    [SerializeField] private Home Home;
    [SerializeField] private Office Office;
    [SerializeField] private Level WorkLevel;

    [SerializeField] private Level[] _allLevels;
    [SerializeField] private Transform PlayerTransform;

    public static LevelManager Instance;

    public Calendar Calendar;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {

        if (Progress.Instance.HalfDone) {
            ShowOffice();
        } else {
            ShowHome(false);
        }

    }

    public void ShowHome(bool doSave) {
        if (doSave) {
            // если мы сейчас проходим последний доступный уровень
            //if (Calendar.DayIndex == Progress.Instance.Level) {  
            //}
            Progress.Instance.Level += 1;
            Progress.Instance.HalfDone = false;
            Progress.Instance.WorkDone = false;
            Progress.Instance.Save();
        }
        

        HideAllLevels();
        //OfficeObject.SetActive(false);
        Office.Hide();
        //HomeObject.SetActive(true);
        Home.Show();
    }


    public void ShowOfficeFromStreet() {
        // если мы сейчас проходим последний доступный уровень
        if (Calendar.DayIndex == Progress.Instance.Level) {
            Progress.Instance.HalfDone = true;
            Progress.Instance.Save();
        }
        ShowOffice();
    }

    public void ShowOfficeFromWork() {
        // сохранение
        Progress.Instance.WorkDone = true;
        Progress.Instance.Save();
        ShowOffice();
    }

    public void ShowOffice() {
        HideAllLevels();
        Office.Show();
        //OfficeObject.SetActive(true);
        Home.Hide();
        //HomeObject.SetActive(false);
    }

    void HideAllLevels() {
        foreach (var level in _allLevels) {
            level.Hide();
        }
        WorkLevel.Hide();
        PlatformerObject.SetActive(false);
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
        Home.Hide();
        Office.Hide();
    }

    public void ShowWork() {
        HideAllLevels();
        WorkLevel.Show();
        PlayerTransform.position = WorkLevel.PlayerStartPoint.position;
        PlatformerObject.SetActive(true);
        Home.Hide();
        Office.Hide();
    }

}
