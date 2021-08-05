using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _multX;
    [SerializeField] private float _multY;

    private Vector3 _playerStratPosition;
    private Vector3 _stratPosition;

    private void Start() {
        _playerStratPosition = _playerTransform.position;
        _stratPosition = transform.position;
    }

    void Update() {
        Vector3 playerDelta = _playerTransform.position - _playerStratPosition;
        Vector3 offset = new Vector3(playerDelta.x * _multX, playerDelta.y * _multY, 0f);
        transform.position = _stratPosition + offset;
    }

}
