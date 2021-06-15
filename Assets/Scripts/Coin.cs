using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            Player player = collision.attachedRigidbody.GetComponent<Player>();
            if (player) {
                CoinCounter.Instance.AddOne();
                Collect();
            }
        }
    }

    void Collect() {
        Destroy(gameObject);
    }

}
