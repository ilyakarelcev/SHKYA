using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private float _health;

    private float _maxHealth;
    private bool _invulnerable;

    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private Slider _slider;

    private void Start() {
        _maxHealth = _health;
        _slider.value = _health;
    }

    public void TakeDamage(float value) {
        if (_invulnerable) return;
        _health -= value;
        _slider.value = _health;
        _invulnerable = true;
        Invoke("StopInvulnarable", 1f);
        foreach (var item in _spriteRenderers) {
            item.color = new Color(1f, 0.8f, 0.8f, 1f);
        }
    }

    void StopInvulnarable() {
        _invulnerable = false;
        foreach (var item in _spriteRenderers) {
            item.color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
