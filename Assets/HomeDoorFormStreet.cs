using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDoorFormStreet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            Player player = collision.attachedRigidbody.GetComponent<Player>();
            if (player) {
                TryGoToHome();
            }
        }
    }

    void TryGoToHome() {
        if (Progress.Instance.HalfDone) {
            FadeScreen.Instance.StartFade(1f);
            Invoke(nameof(GoToHome), 1f);
        } else { 
            //если не прошли путь, то в дверь зайти нельзя
        }
    }

    void GoToHome() {
        LevelManager.Instance.ShowHome(true);
    }

}
