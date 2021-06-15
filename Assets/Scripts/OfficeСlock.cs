using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeСlock : MonoBehaviour
{

    public GameObject Time9;
    public GameObject Time18;

    public void Show9() {
        Time9.SetActive(true);
        Time18.SetActive(false);
    }

    public void Show18() {
        Time9.SetActive(false);
        Time18.SetActive(true);
    }

}
