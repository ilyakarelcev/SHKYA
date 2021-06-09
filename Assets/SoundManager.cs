using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public SoundItem[] SoundItems;
    public static SoundManager Instance;

    private void Awake() {
        if (Instance) {
            Destroy(gameObject);
        }
        Instance = this;
        SoundItems = FindObjectsOfType<SoundItem>();
    }

    public void Play(string soundName) {
        for (int i = 0; i < SoundItems.Length; i++) {
            if (SoundItems[i].Name == soundName) {
                SoundItems[i].Play();
            }
        }
    }


}
