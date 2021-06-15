using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] private float _lifeTime = 5f;

    protected virtual void Start() {
        Invoke("Die", _lifeTime);
    }

    public void SetVelocity(Vector3 velocity) {
        _rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            PlayerHealth playerHealth = collision.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth) {
                OnTriggerEffect(playerHealth);
                Die();
            }
        }        
    }

    protected virtual void OnTriggerEffect(PlayerHealth playerHealth) {
        playerHealth.TakeDamage(); //_damageValue
    }

    void Die() {
        Destroy(gameObject);
    }

}

