using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Throwing : MonoBehaviour {

    [SerializeField] private Joystick _joystick;
    [SerializeField] private List<Transform> _dots = new List<Transform>();
    [SerializeField] private Transform _dotPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawn;

    [SerializeField] private Can _can;

    public Animator _animator;
    public Collider2D _playerCollider2D;
    public CanCounter CanCounter;

    public bool IsReadyToThrow;
    public PlayerMove PlayerMove;

    [SerializeField] private ThrowArrow _throwArrow;
    //[SerializeField] private AudioSource _throwSound;

    private bool _down;
    private bool _throwing;
    private Vector3 _velocity;

    private void Start() {
        _joystick.EventOnDown.AddListener(OnDown);
        _joystick.EventOnUp.AddListener(OnUp);
        _throwArrow.Hide();
    }

    

    private void Update() {

        if (_down) {
            if (Mathf.Abs(_joystick.Value.y) > 0.05f) {
                StartThrow();
                _down = false;
            }
        }

        if (_throwing) {

            if (CanCounter.Number == 0) return;
            float angle;
            if (PlayerMove.MoveDirection == MoveDirection.Right) {
                angle = Mathf.Lerp(-90f, 90f, _joystick.Value.y * 0.5f + 0.5f);
            } else {
                angle = Mathf.Lerp(270f, 90f, _joystick.Value.y * 0.5f + 0.5f);
            }

            _spawn.localEulerAngles = new Vector3(0, 0, angle);
            _velocity = _spawn.right * _speed;

            dotIndex = 0;
            for (float t = 0f; t < 2f; t += 0.035f) {
                float x = _velocity.x * t;
                float y = (_can.Rigidbody2D.gravityScale * Physics.gravity.y * t * t) / 2f + _velocity.y * t;
                Vector3 dotPosition = _spawn.position + new Vector3(x, y, 0f);
                dotPosition.z = 0f;
                ShowDot(dotPosition);
            }

            HideOtherDots();

            _throwArrow.Setup(_spawn.position, _velocity / _speed);

        }

    }

    void OnDown(Vector2 point) {
        if (CanCounter.Number == 0) return;
        _down = true;
    }

    public void StartThrow() {
        //Debug.Log("StartThrow");
        _throwing = true;
        if (CanCounter.Number == 0) return;
        SoundManager.Instance.Play("ThrowReady");
        _animator.SetBool("Throw", true);
        IsReadyToThrow = true;
        _throwArrow.Show();
    }

    void OnUp(Vector2 point) {
        if (_throwing) {
            if (CanCounter.Number == 0) return;
            _animator.SetBool("Throw", false);
            dotIndex = 0;
            HideOtherDots();
            Throw();
            IsReadyToThrow = false;
            _throwing = false;
            _throwArrow.Hide();
        }
    }

    public void Throw() {
        if (CanCounter.TryThrowOne()) {
            Can newCan = Instantiate(_can, _spawn.position, Quaternion.identity);
            Physics2D.IgnoreCollision(_playerCollider2D, newCan.Collider2D);
            newCan.Throw(_velocity);
            SoundManager.Instance.Play("Throw");
        }

    }

    int dotIndex = 0;
    public void ShowDot(Vector3 position) {
        if (_dots.Count < dotIndex + 1) {
            _dots.Add(Instantiate(_dotPrefab));
        }
        _dots[dotIndex].gameObject.SetActive(true);
        _dots[dotIndex].position = position;
        dotIndex++;
    }

    public void HideOtherDots() {
        for (int i = dotIndex; i < _dots.Count; i++) {
            _dots[i].gameObject.SetActive(false);
        }
    }

}
