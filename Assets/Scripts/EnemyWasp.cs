using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWasp : Enemy {

    public float _speed;

    protected override void Update() {
        base.Update();

        if (!_isActive) return;
        Vector2 toPlayer = _playerTransform.position - transform.position;
        transform.position += (Vector3)toPlayer.normalized * Time.deltaTime;

    }

}
