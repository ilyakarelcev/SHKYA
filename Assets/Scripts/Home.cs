using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {

    [SerializeField] private GameObject PlatformerObject;
    [SerializeField] private GameObject HomeObject;

    [SerializeField] private Level[] _allLevels;
    [SerializeField] private Transform PlayerTransform;

    private int _currentLevelIndex = 0;

    private void Start() {
        ShowHome();
    }

    public void SetLevelIndex(int index) {
        _currentLevelIndex = index;
    }

    public void ShowHome() {
        foreach (var level in _allLevels) {
            level.Hide();
        }
        PlatformerObject.SetActive(false);
        HomeObject.SetActive(true);
    }

    public void StartLevel() {
        ShowLevel(_currentLevelIndex);
    }

    public void ShowLevel(int levelIndex) {
        Level level = _allLevels[levelIndex];
        level.Show();
        PlayerTransform.position = level.PlayerStartPoint.position;

        PlatformerObject.SetActive(true);
        HomeObject.SetActive(false);
    }

}
