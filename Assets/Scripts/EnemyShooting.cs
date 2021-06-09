using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Enemy {

    public EnemyBullet EnemyBulletPrefab;
    public Transform Spawn;
    public float BulletSpeed;

    private float _timer;

    [SerializeField]
    private float _shotPeriod;
    private Vector3 _startScale;
    [SerializeField] private AnimationCurve _scaleCurve;


    protected override void Start() {
        base.Start();
        _startScale = transform.localScale;
        _timer = Random.Range(0, _shotPeriod);
    }

    protected override void Update() {
        base.Update();
        if (!_isActive) return;

        _timer += Time.deltaTime;
        if (_timer > _shotPeriod) {
            _timer = 0f;
            StartCoroutine(ShotAnimation());
        }
    }

    IEnumerator ShotAnimation() {
        for (float t = 0; t < 1f; t += Time.deltaTime * 2f) {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = _startScale * scale;
            yield return null;
        }
        transform.localScale = _startScale;
        CreateBullet();
    }

    public void CreateBullet() {
        SoundManager.Instance.Play("EnemyShot");
        EnemyBullet newEnemyBullet = Instantiate(EnemyBulletPrefab, Spawn.position, Spawn.rotation);
        newEnemyBullet.SetVelocity(Spawn.right * BulletSpeed);
    }

}
