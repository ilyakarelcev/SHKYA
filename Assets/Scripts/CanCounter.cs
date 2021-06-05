using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCounter : MonoBehaviour {

    public GameObject CanIconPrefab;
    public List<GameObject> CanIcons = new List<GameObject>();
    public Transform Parent;
    public int Number;
    public int MaxNumber;

    private void Start() {
        SetMaxNumber(5);
        DisplayCans(3);
    }

    public void SetMaxNumber(int value) {
        MaxNumber = value;
        for (int i = 0; i < value; i++) {
            GameObject newCanIcon = Instantiate(CanIconPrefab, Parent);
            CanIcons.Add(newCanIcon);
        }
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
        if (Number < MaxNumber) {
            Number++;
            DisplayCans(Number);
            return true;
        } else {
            return false;
        }
    }

    public void DisplayCans(int number) {
        for (int i = 0; i < CanIcons.Count; i++) {
            if (i < number) {
                CanIcons[i].SetActive(true);
            } else {
                CanIcons[i].SetActive(false);
            }
        }
    }


}
