using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaper : EnemyBullet {

    protected override void Start() {
        base.Start();
        _rigidbody.angularVelocity = Random.Range(-300f, 300f);
    }

    protected override void OnTriggerEffect(PlayerHealth playerHealth) {
        //base.OnTriggerEffect(playerHealth);
        float x = Mathf.Sign(_rigidbody.velocity.x) * 8;
        float y = 10f;
        playerHealth.GetComponent<PlayerMove>().SetVelocity(new Vector3(x,y,0f));
    }

}
