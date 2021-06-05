using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private float _damageValue = 10f;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        PlayerHealth playerHealth = collision.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth == null) return;
        
        Vector2 playerPosition = playerHealth.transform.position;
        Vector2 enemyPosition = transform.position;

        Vector2 toPlayer = playerPosition - enemyPosition;
        float angle = Vector2.Angle(toPlayer, Vector3.up);
        if (angle < 90f) {
            collision.attachedRigidbody.GetComponent<PlayerMove>().Grounded = true;
            Die();
        } else {
            playerHealth.TakeDamage(_damageValue);
        }
        Debug.Log(angle);
        
    }

    public virtual void Die() {
        Destroy(gameObject);
    }

}
