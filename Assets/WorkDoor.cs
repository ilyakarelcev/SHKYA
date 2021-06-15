using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkDoor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            Player player = collision.attachedRigidbody.GetComponent<Player>();
            if (player) {
                FadeScreen.Instance.StartFade(1f);
                Invoke(nameof(DoToOffice), 1f);
            }
        }
    }

    void DoToOffice() {
        LevelManager.Instance.ShowOffice();
    }

}
