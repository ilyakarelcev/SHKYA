using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour {

    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;

    private float _leftX;
    private float _rightX;

    [SerializeField] private float _speed;

    [SerializeField] private float _damageValue = 10f;

    void Start() {
        _leftX = transform.position.x - _leftBorder;
        _rightX = transform.position.x + _rightBorder;
    }

    void Update() {
        float t = Mathf.PingPong(Time.time * _speed, 1f);
        float x = Mathf.Lerp(_leftX, _rightX, t);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private void OnDrawGizmos() {
        if (!Application.isPlaying) {
            Vector3 leftPosition = transform.position + new Vector3(-_leftBorder, 0f, 0f);
            Vector3 rightPosition = transform.position + new Vector3(_rightBorder, 0f, 0f);
            Gizmos.DrawSphere(leftPosition, 0.1f);
            Gizmos.DrawSphere(rightPosition, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerHealth playerHealth = collision.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth) {
            playerHealth.TakeDamage(_damageValue);
        }
    }

}
