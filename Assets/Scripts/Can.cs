using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour {

    public Rigidbody2D Rigidbody2D;
    public Collider2D Collider2D;

    public void Throw(Vector3 velocity) {
        Rigidbody2D.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyWalking enemyWalking = other.GetComponent<EnemyWalking>();
        if (enemyWalking) {
            enemyWalking.Die();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}