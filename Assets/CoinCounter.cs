using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {

    [SerializeField] private Text _coinText;
    [SerializeField] private Transform _counterTransform;
    [SerializeField] private int _numberOfCoins;
    [SerializeField] private AudioSource _coinSound;

    [Header ("Animation")]
    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _scaleAnimationCurve;
    


    public void AddOne() {
        _numberOfCoins++;
        UpdateText();
        _coinSound.Play();
        MMVibrationManager.Haptic(HapticTypes.MediumImpact, false, true, this);
        StartCoroutine(AddOneAnimation());
    }

    void UpdateText() {
        _coinText.text = _numberOfCoins.ToString();
    }

    private IEnumerator AddOneAnimation() {
        for (float t = 0; t < 1f; t+=Time.deltaTime / _animationTime) {
            float scale = _scaleAnimationCurve.Evaluate(t);
            _counterTransform.localScale = Vector3.one * scale;
            yield return null;
        }
        _counterTransform.localScale = Vector3.one;
    }

}
