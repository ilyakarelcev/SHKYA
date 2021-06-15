using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSay : MonoBehaviour {

    [SerializeField] private TextMeshPro _textMeshPro;
    public static PlayerSay Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        _textMeshPro.gameObject.SetActive(false);
    }

    public void Say(string sayString, float showTime) {
        StartCoroutine(TypeAnimation(sayString, showTime));
    }

    public IEnumerator TypeAnimation(string sayString, float showTime) {
        _textMeshPro.gameObject.SetActive(true);
        _textMeshPro.text = "";
        for (int i = 0; i < sayString.Length; i++) {
            char c = sayString[i];
            _textMeshPro.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(showTime);
        _textMeshPro.gameObject.SetActive(false);
    }


}
