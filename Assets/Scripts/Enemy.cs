using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private float _damageValue = 10f;
    protected bool _isActive;

    [SerializeField] private float  _distanceToActivate = 10f;
    protected Transform _playerTransform;

    protected virtual void Start() {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    protected virtual void Update() {
        float distance = Vector3.Distance(transform.position, _playerTransform.position);
        if (distance < _distanceToActivate) {
            _isActive = true;
        } else {
            _isActive = false;
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
            playerHealth.TakeDamage(_damageValue);
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
