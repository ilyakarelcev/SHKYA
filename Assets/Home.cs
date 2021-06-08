using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {

    [SerializeField] private GameObject PlatformerObject;
    [SerializeField] private GameObject HomeObject;

    [SerializeField] private Level[] _allLevels;
    [SerializeField] private Transform PlayerTransform;
    

    public void LoadLevel(int levelIndex) {
        Level level = _allLevels[levelIndex];
        level.Show();
        PlayerTransform.position = level.PlayerStartPoint.position;

        PlatformerObject.SetActive(true);
        HomeObject.SetActive(false);
    }

}
