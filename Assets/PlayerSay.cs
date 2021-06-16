using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSay : MonoBehaviour {

    [SerializeField] private TextMeshPro _textMeshPro;
    public static PlayerSay Instance;
    private Coroutine _currentCoroutine;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        _textMeshPro.gameObject.SetActive(false);
    }

    public void Say(string sayString, float showTime) {
        if (_currentCoroutine != null) {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = StartCoroutine(TypeAnimation(sayString, showTime));
    }

    public IEnumerator TypeAnimation(string sayString, float showTime) {
        _textMeshPro.gameObject.SetActive(true);
        _textMeshPro.text = "";
        for (int i = 0; i < sayString.Length; i++) {
            char c = sayString[i];
            _textMeshPro.text += c;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(showTime);
        _textMeshPro.gameObject.SetActive(false);
    }

    private void OnDisable() {
        if (_currentCoroutine != null) {
            StopCoroutine(_currentCoroutine);
        }
        _textMeshPro.gameObject.SetActive(false);
    }

}
