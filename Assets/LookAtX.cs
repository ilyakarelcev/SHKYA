using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtX : MonoBehaviour {

    private Transform _playerTransform;
    [SerializeField] private float _rotationLerpRate = 1f;

    private void Start() {
        _playerTransform = FindObjectOfType<Player>().PlayerCenter;
    }

    private void LateUpdate() {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0f,0f,90f) * toPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationLerpRate);
    }

}
