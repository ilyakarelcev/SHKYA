using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //[SerializeField] private float _damageValue = 10f;
    [SerializeField] public Rigidbody2D _rigidbody;

    private void Start() {
        Invoke("Die", 5f);
    }

    public void SetVelocity(Vector3 velocity) {
        _rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            PlayerHealth playerHealth = collision.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth) {
                playerHealth.TakeDamage(); //_damageValue
                Die();
            }
        }
        
    }
    //private void OnCollisionEnter(Collision collision) {
    //}

    void Die() {
        Destroy(gameObject);
    }
}

