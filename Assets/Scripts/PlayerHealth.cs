//using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private GameManager GameManager;

    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _heartIconPrefab;
    [SerializeField] private List<GameObject> _icons = new List<GameObject>();
    [SerializeField] private Transform _parent;

    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    private bool _invulnerable;

    private void Start() {
        SetMaxNumber(_maxHealth);
        DisplayHealth(_health);
    }

    public void SetMaxNumber(int value) {
        _maxHealth = value;
        for (int i = 0; i < value; i++) {
            GameObject newCanIcon = Instantiate(_heartIconPrefab, _parent);
            _icons.Add(newCanIcon);
        }
    }

    public bool TryThrowOne() {
        if (_health > 0) {
            _health--;
            DisplayHealth(_health);
            return true;
        } else {
            return false;
        }
    }

    public bool TryAddOne() {
        if (_health < _maxHealth) {
            _health++;
            DisplayHealth(_health);
            return true;
        } else {
            return false;
        }
    }

    public void DisplayHealth(int number) {
        for (int i = 0; i < _icons.Count; i++) {
            if (i < number) {
                _icons[i].SetActive(true);
            } else {
                _icons[i].SetActive(false);
            }
        }
    }

    public void TakeDamage() {
        if (_invulnerable) return;
        _health -= 1;
        if (_health > 0) {
            _invulnerable = true;
            Invoke("StopInvulnarable", 1f);
            foreach (var item in _spriteRenderers) {
                item.color = new Color(1f, 0.8f, 0.8f, 1f);
            }
        } else {
            GameManager.Lose();
        }
        SoundManager.Instance.Play("PlayerHit");
        //MMVibrationManager.Haptic(HapticTypes.Failure, false, true, this);
        DisplayHealth(_health);
    }

    public void MakeInvulnerable(float time) {
        _invulnerable = true;
        Invoke("StopInvulnarable", time);
    }

    void StopInvulnarable() {
        _invulnerable = false;
        foreach (var item in _spriteRenderers) {
            item.color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
