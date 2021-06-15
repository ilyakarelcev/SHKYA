using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour {

    public TextMeshPro TextMeshPro;
    public int StartTime = 540;
    public int CurrentTime;
    public GameObject WinWindow;
    public ClockTrigger ClockTrigger;

    [SerializeField] private Transform _coinSpawn;
    [SerializeField] private GameObject CoinEffectPrefab;

    private void Start() {
        CurrentTime = StartTime;
        ClockTrigger.OnBottonPressed += OnButtonPressed;
    }

    void OnButtonPressed() {
        IncreaseTime(15);
        Instantiate(CoinEffectPrefab, _coinSpawn.position, Quaternion.identity);
        CoinCounter.Instance.AddOne();
    }

    public void IncreaseTime(int value) {
        CurrentTime += value;
        DisplayTime();
        if (CurrentTime == 18 * 60) {
            Win();
        }
    }

    void DisplayTime() {
        int hours = CurrentTime / 60;
        int minutes = CurrentTime % 60;
        TextMeshPro.text = hours.ToString("00") + ":" + minutes.ToString("00");
    }

    void Win() {
        WinWindow.SetActive(true);
        Time.timeScale = 0f;
    }

}
