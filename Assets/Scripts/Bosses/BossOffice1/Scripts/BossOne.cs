using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossOne : MonoBehaviour
{
  [SerializeField] private GameObject _fire;
  [SerializeField] private List<Transform> _leftDirections;
  [SerializeField] private List<Transform> _rightDirections;
  [SerializeField] private SpriteRenderer _sprite;
  [SerializeField] private Transform _leftMovePoint;
  [SerializeField] private Transform _rightMovePoint;
  [SerializeField] private TopSpawner _topSpawner;
  [SerializeField] private SideSpawner _sideSpawner;
  [SerializeField] private Bullet _bullet;
  [SerializeField] private float _moveSpeed;
  [SerializeField] private int _resistTime;
  [SerializeField] private float _shootCoolDown;
  [SerializeField] private int _health;
  [SerializeField] private Transform _damageZone;
  [SerializeField] private Alarm _alarm;
  [SerializeField] private Exit _exit;

  private bool _isFire = false;
  private List<Bullet> _bullets = new List<Bullet>();
  private Transform _currentMovePoint;
  private bool _resistState = false;
  private Sequence _sequence;
  private Tween _moveTween;

#if UNITY_EDITOR

  // private void OnDrawGizmos()
  // {
  //   Gizmos.color = Color.green;
  //   foreach (var direction in _leftDirections)
  //     Gizmos.DrawLine(transform.position, direction.position);
  //
  //   Gizmos.color = Color.blue;
  //   foreach (var direction in _rightDirections)
  //     Gizmos.DrawLine(transform.position, direction.position);
  // }
#endif

  private void OnEnable() => _alarm.IsDone += StartShooting;

  private void OnDisable() => _alarm.IsDone -= StartShooting;

  private void Awake()
  {
    _currentMovePoint = _rightMovePoint;
    Activate();
  }

  public void CheckDamage(PlayerHealth playerHealth)
  {
    {
      if (_isFire == true)
      {
        playerHealth.TakeDamage();
        return;
      }

      if (_resistState == false)
        GetDamage();
      // else
      //   playerHealth.TakeDamage();
    }
  }

  public void Activate()
  {
    _sprite.DOFade(1, 1f)
      .SetLink(gameObject)
      .OnComplete(() => { StartCoroutine(Shooting()); });
  }

  public void GetDamage()
  {
    DamageResist();
    _health--;
    _sequence = DOTween.Sequence();

    _sequence
      .Append(_sprite
        .DOColor(Color.red, .2f)
        .SetLink(gameObject))
      .Append(_sprite
        .DOColor(Color.white, .2f)
        .SetLink(gameObject));

    if (_health <= 0)
    {
      foreach (var bullet in _bullets)
        bullet.gameObject.SetActive(false);

      _exit.gameObject.SetActive(true);
      Destroy(gameObject);
    }
  }

  private void JumpAttack()
  {
    _moveTween.Kill();
    transform
      .DOJump(transform.position + Vector3.up, 1, 1, .5f)
      .SetEase(Ease.Linear)
      .SetLink(gameObject)
      .OnComplete(() => { _topSpawner.AttackAlarm(); });
  }

  private void AttackAlarm() => _alarm.AlarmAnimation();

  private void StartShooting() => StartCoroutine(Shooting());

  private IEnumerator Shooting()
  {
    var currentDirections = GetDirections();

    var delay = new WaitForSeconds(_shootCoolDown);

    for (int i = 0; i < currentDirections.Count; i++)
    {
      Bullet currentBullet = Instantiate(_bullet, transform.position, quaternion.identity);
      currentBullet.Move(currentDirections[i].transform.position);
      _bullets.Add(currentBullet);
      yield return delay;
    }

    MoveToPoint();
  }

  public void MoveToPoint()
  {
    _fire.SetActive(false);
    _isFire = false;

    Transform positionPoint = GetMovePoint();

    if (_moveTween != null)
      _moveTween.Kill();

    _moveTween = transform
      .DOMoveX(positionPoint.position.x, _moveSpeed)
      .SetLink(gameObject)
      .SetEase(Ease.Linear)
      .SetAutoKill(true)
      .OnComplete(() =>
      {
        int index = Random.Range(0, 2);
        ChooseAttack(index);
      });
  }

  private Transform GetMovePoint()
  {
    if (_currentMovePoint == _leftMovePoint)
    {
      _currentMovePoint = _rightMovePoint;
      return _rightMovePoint;
    }
    else
    {
      _currentMovePoint = _leftMovePoint;
      return _leftMovePoint;
    }
  }

  private async void ChooseAttack(int index)
  {
    _fire.SetActive(true);
    _isFire = true;

    await Task.Delay(2000);


    if (index > 0)
      AttackAlarm();
    else
      JumpAttack();
  }

  private async void DamageResist()
  {
    _resistState = true;
    await Task.Delay(_resistTime * 1000);
    _resistState = false;
  }

  private List<Transform> GetDirections()
  {
    if (_currentMovePoint == _rightMovePoint)
      return _leftDirections;
    else
      return _rightDirections;
  }
}