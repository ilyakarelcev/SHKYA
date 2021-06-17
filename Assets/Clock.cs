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

    public Office Office;
    private bool _done = false;
    public GameObject Enemies;

    private void Start() {
        CurrentTime = StartTime;
        ClockTrigger.OnBottonPressed += OnButtonPressed;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            OnButtonPressed();
        }
    }

    void OnButtonPressed() {
        if (_done) return;
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
        //Time.timeScale = 0f;
        _done = true;
        Enemies.SetActive(false);
        WinWindow.SetActive(true);
        Office.WhenWin();
    }

    public void GoToOfficeButton() {
        //Time.timeScale = 1f;
        WinWindow.SetActive(false);
        FadeScreen.Instance.StartFade(1f);
        Invoke(nameof(GoToOffice), 1f);
    }

    void GoToOffice() {
        LevelManager.Instance.ShowOffice();
    }

}
