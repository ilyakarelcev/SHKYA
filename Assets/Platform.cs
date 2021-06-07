using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private void OnCollisionStay2D(Collision2D collision) {
        Player player = collision.rigidbody.GetComponent<Player>();
        if (player) {
            if (Vector2.Angle(collision.contacts[0].normal, Vector2.up) < 10f) {
                Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal);
                player.transform.parent = transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Player player = collision.rigidbody.GetComponent<Player>();
        if (player) {
            player.transform.parent = null;
        }
    }

}
