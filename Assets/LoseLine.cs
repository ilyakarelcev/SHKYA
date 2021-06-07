using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLine : MonoBehaviour {

    public float LineLength;
    public GameManager GameManager;
    public Transform PlayerTransform;

    void FixedUpdate() {
        if (PlayerTransform.position.y < transform.position.y) {
            GameManager.Lose();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.right * LineLength);
    }

}
