using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanCounter : MonoBehaviour {

    //public GameObject CanIconPrefab;
    //public List<GameObject> CanIcons = new List<GameObject>();
    //public Transform Parent;
    public int Number = 0;
    [SerializeField] private int _maxNumber = 5;
    [SerializeField] private Text _numberText;
    [SerializeField] private Image _throwButtonImage;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _animationTime = 0.5f;

    private void Start() {
        SetMaxNumber(_maxNumber);
        DisplayCans(Number);
    }

    public void SetMaxNumber(int value) {
        _maxNumber = value;
        //for (int i = 0; i < value; i++) {
        //    GameObject newCanIcon = Instantiate(CanIconPrefab, Parent);
        //    CanIcons.Add(newCanIcon);
        //}
    }

    public bool TryThrowOne() {
        if (Number > 0) {
            Number--;
            DisplayCans(Number);
            return true;
        } else {
            return false;
        }
    }

    public bool TryAddOne() {
        if (Number < _maxNumber) {
            AddOne();
            return true;
        } else {
            return false;
        }
    }

    void AddOne() {
        Number++;
        DisplayCans(Number);
        SoundManager.Instance.Play("CollectCan");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact, false, true, this);
    }

    public void DisplayCans(int number) {
        StartCoroutine(ButtonAnimation());
        _numberText.text = number.ToString() + "/" + _maxNumber;
        if (number == 0) {
            _throwButtonImage.raycastTarget = false;
            _throwButtonImage.color = new Color(1f, 1f, 1f, 0.36f);
        } else {
            _throwButtonImage.raycastTarget = true;
            _throwButtonImage.color = new Color(1f, 1f, 1f, 1f);
        }
        //for (int i = 0; i < CanIcons.Count; i++) {
        //    if (i < number) {
        //        CanIcons[i].SetActive(true);
        //    } else {
        //        CanIcons[i].SetActive(false);
        //    }
        //}
    }

    IEnumerator ButtonAnimation() {
        for (float t = 0; t < 1f; t += Time.deltaTime / _animationTime) {
            float scale = _animationCurve.Evaluate(t);
            _throwButtonImage.transform.localScale = Vector3.one * scale;
            yield return null;
        }
        _throwButtonImage.transform.localScale = Vector3.one;
    }

}
