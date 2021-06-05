using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour {

    [SerializeField] private Joystick _joystick;
    //[SerializeField] private LineRenderer _lineRenderer;
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

    private void Start() {
        _joystick.EventOnDown.AddListener(OnDown);
        //_joystick.EventOnPressed.AddListener(OnPressed);
        _joystick.EventOnUp.AddListener(OnUp);
    }

    private bool _down;
    private bool _throwing;

    private void Update() {
        if (_down) {
            if (_joystick.Value.y > 0.1f) {
                StartJump();
                _down = false;
            } else if (_joystick.Value.y < -0.1f) {
                StartThrow();
                _down = false;
            }
        }

        if (_throwing) {
            if (CanCounter.Number == 0) return;
            PlayerMove.SetMoveDirection(_joystick.Value.x > 0 ? MoveDirection.Left : MoveDirection.Right);
            Vector3 velocity = -1f * new Vector3(_joystick.Value.x, _joystick.Value.y, 0f) * _speed;
            dotIndex = 0;
            for (float t = 0f; t < 1f; t += 0.05f) {
                float x = velocity.x * t;
                float y = (_can.Rigidbody2D.gravityScale * Physics.gravity.y * t * t) / 2f + velocity.y * t;
                Vector3 dotPosition = _spawn.position + new Vector3(x, y, 0f);
                dotPosition.z = 0f;
                ShowDot(dotPosition);
            }
            HideOtherDots();
        }

    }

    void OnDown(Vector2 point) {
        _down = true;
    }

    public void StartThrow() {
        _throwing = true;
        if (CanCounter.Number == 0) return;
        _animator.SetBool("Throw", true);
        IsReadyToThrow = true;
    }
    public void StartJump() {
        PlayerMove.Jump();
    }

    //void OnPressed(Vector2 point) {
    //}

    void OnUp(Vector2 point) {
        if (_throwing) {
            if (CanCounter.Number == 0) return;
            _animator.SetBool("Throw", false);
            dotIndex = 0;
            HideOtherDots();
            Throw();
            IsReadyToThrow = false;
            _throwing = false;
        }
    }

    public void Throw() {
        if (CanCounter.TryThrowOne()) {
            Can newCan = Instantiate(_can, _spawn.position, Quaternion.identity);
            Physics2D.IgnoreCollision(_playerCollider2D, newCan.Collider2D);
            Vector3 velocity = -1f * new Vector3(_joystick.Value.x, _joystick.Value.y, 0f) * _speed;
            newCan.Throw(velocity);
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
