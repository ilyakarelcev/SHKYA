using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundItem : MonoBehaviour {

    public string Name;
    public AudioSource AudioSource;
    [SerializeField] private float _minPitch = 0.9f;
    [SerializeField] private float _maxPitch = 1.1f;

    public void Play() {
        AudioSource.pitch = Random.Range(_minPitch, _maxPitch);
        AudioSource.Play();
    }

}
