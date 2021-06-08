using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private CoinCounter _coinCounter;

    private void Start() {
        _coinCounter = FindObjectOfType<CoinCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            Player player = collision.attachedRigidbody.GetComponent<Player>();
            if (player) {
                _coinCounter.AddOne();
                Collect();
            }
        }
    }

    void Collect() {
        Destroy(gameObject);
    }

}
