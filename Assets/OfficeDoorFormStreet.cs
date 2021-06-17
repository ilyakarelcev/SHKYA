using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class OfficeDoorFormStreet : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            Player player = collision.attachedRigidbody.GetComponent<Player>();
            if (player) {
                FadeScreen.Instance.StartFade(1f);
                Invoke(nameof(GoToOffice), 1f);
            }
        }
    }

    void GoToOffice() {
        LevelManager.Instance.ShowOffice();
    }

}
