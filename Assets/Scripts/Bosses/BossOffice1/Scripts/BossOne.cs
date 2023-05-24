using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using GG.Infrastructure.Utils;
using Unity.Mathematics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class BossOne : MonoBehaviour
{
  [SerializeField] private SpriteRenderer _sprite;
  [SerializeField] private Transform _movePoint;
  [SerializeField] private float _moveSpeed;
  [SerializeField] private float _shootCoolDown;
  [SerializeField] private List<Transform> _shootDirections;
  [SerializeField] private Bullet _bullet;
  [SerializeField] private TopSpawner _topSpawner;
  [SerializeField] private float _jumpCoolDown;

  private int _health = 5;
  private bool _isAlive = true;
  private Randomizer _randomizer;
  private Sequence _sequence;
  private Tween _moveTween;
  private float _elepsedTime = 0;
  private bool _isJump = false;

  private void Awake() => Activate();

  private void Update()
  {
    _elepsedTime += Time.deltaTime;

    if (_elepsedTime >= _jumpCoolDown && _isJump == false)
    {
      _isJump = true;
      JumpAttack();
    }
  }

  private void JumpAttack()
  {
    _moveTween.Kill();
    transform
      .DOJump(transform.position + Vector3.up, 1, 1, .5f)
      .SetEase(Ease.Linear)
      .OnComplete(() => { _topSpawner.JumpAttack(); });
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    ContactPoint2D contact = collision.contacts[0];


    if (collision.gameObject.TryGetComponent(out PlayerHealth player))
    {
      print(contact.normal.y);

      if (contact.normal.y < 0)
      {
        collision.gameObject.TryGetComponent(out PlayerMove mover);
        mover.Jump();
        GetDamage();
      }
      else
        player.TakeDamage();
    }
  }

  public void Activate()
  {
    _sprite.DOFade(1, 3f)
      .SetLink(gameObject)
      .OnComplete(() =>
      {
        StartCoroutine(Shoot());
        Move();
      });
  }

  public void Move()
  {
    _elepsedTime = 0;
    _isJump = false;

    _moveTween = transform
      .DOMoveX(_movePoint.position.x, _moveSpeed)
      .SetLoops(-1, LoopType.Yoyo)
      .SetLink(gameObject)
      .SetEase(Ease.Linear);
  }

  public void GetDamage()
  {
    _health--;

    _sequence = DOTween.Sequence();

    _sequence
      .Append(_sprite
        .DOColor(Color.magenta, .2f)
        .SetLink(gameObject))
      .Append(_sprite
        .DOColor(Color.white, .2f)
        .SetLink(gameObject));

    if (_health <= 0)
      Destroy(gameObject);
  }

  private IEnumerator Shoot()
  {
    var delay = new WaitForSeconds(_shootCoolDown);
    _randomizer = new Randomizer(_shootDirections.Count - 1);

    while (_isAlive)
    {
      int index = _randomizer.SelectNoRepeat();

      Bullet currentBullet = Instantiate(_bullet, transform.position, quaternion.identity);
      currentBullet.Move(_shootDirections[index].transform.position);

      yield return delay;
    }
  }
}