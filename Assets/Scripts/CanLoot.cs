using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanLoot : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        CanCounter canCounter = collision.attachedRigidbody.GetComponent<CanCounter>();
        if (canCounter) {
            if (canCounter.TryAddOne()) {
                Destroy(gameObject);
            }
        }
    }

}
