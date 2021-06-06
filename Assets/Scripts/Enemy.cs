using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ActivationMethod { 
    ByDistance,
    FromTheBack
}

public class Enemy : MonoBehaviour {

    //[SerializeField] private float _damageValue = 10f;
    protected bool _isActive;

    [SerializeField] protected ActivationMethod _activationMethod;

    [SerializeField] private float  _distanceToActivate = 10f;
    protected Transform _playerTransform;

    protected virtual void Start() {
        _playerTransform = FindObjectOfType<Player>().PlayerCenter;
    }

    protected virtual void Update() {
        if (_activationMethod == ActivationMethod.ByDistance) {
            float distance = Vector3.Distance(transform.position, _playerTransform.position);
            if (distance < _distanceToActivate) {
                _isActive = true;
            } else {
                _isActive = false;
            }
        } else if (_activationMethod == ActivationMethod.FromTheBack) {
            if (transform.position.x < _playerTransform.position.x + _distanceToActivate) {
                _isActive = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerHealth playerHealth = collision.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth == null) return;
        PlayerMove playerMove = FindObjectOfType<PlayerMove>();
        if (playerMove.Rigidbody2D.velocity.y < -0.1f) {
            playerMove.Grounded = true;
            playerMove.Jump();
            Die();
        } else {
            playerHealth.TakeDamage();
        }
    }

    protected virtual void OnDrawGizmosSelected() {
        Handles.color = Color.red * 0.7f;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }

    public virtual void Die() {
        Destroy(gameObject);
    }

}
