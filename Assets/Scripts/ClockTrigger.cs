using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTrigger : MonoBehaviour {

    [SerializeField] private Transform _animatedButton;
    private bool _isPressed;
    public delegate void SomeAction();
    public event SomeAction OnBottonPressed;

    private void OnTriggerEnter2D(Collider2D other) {
        if (_isPressed) return;
        if (other.attachedRigidbody) {
            if (other.attachedRigidbody.GetComponent<Player>()) {
                Press();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!_isPressed) return;
        if (other.attachedRigidbody) {
            if (other.attachedRigidbody.GetComponent<Player>()) {
                Unpress();
            }
        }
    }

    void Press() {
        _isPressed = true;
        _animatedButton.localPosition = new Vector3(0f, -0.2f, 0f);
        OnBottonPressed?.Invoke();
    }

    void Unpress() {
        _isPressed = false;
        _animatedButton.localPosition = new Vector3(0f, 0f, 0f);
    }

}
