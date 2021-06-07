using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtX : MonoBehaviour {

    public Transform _playerTransform;

    private void Start() {
        _playerTransform = FindObjectOfType<Player>().PlayerCenter;
    }

    private void LateUpdate() {
        Vector3 toPlayer = _playerTransform.position - transform.position;
        transform.right = toPlayer;
    }

}
