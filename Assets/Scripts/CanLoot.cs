using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanLoot : MonoBehaviour {

    private CanCounter _canCounter;

    private void Start() {
        _canCounter = FindObjectOfType<CanCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.attachedRigidbody.GetComponent<Player>();
        if (player) {
            if (_canCounter.TryAddOne()) {
                Destroy(gameObject);
            }
        }
    }

}
