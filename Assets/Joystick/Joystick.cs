using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InputType {
    Mouse,
    Touch,
    Keyboard
}

public class Joystick : MonoBehaviour {

    [SerializeField] private InputType _inputType;

    [SerializeField] private RectTransform _backgroundTransform;
    [SerializeField] private RectTransform _stickTransform;

    [Range(0, 1)] [SerializeField] private float _size;
    [Range(0, 1)] [SerializeField] private float _stickSize;

    public Vector2 Value { get; private set; }
    public bool IsPressed { get; private set; }

    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private RectTransform _activeAreaRect;
    [SerializeField] private MatchVariant _matchVariant;

    [HideInInspector] public UnityEvent<Vector2> EventOnDown;
    [HideInInspector] public UnityEvent<Vector2> EventOnPressed;
    [HideInInspector] public UnityEvent<Vector2> EventOnUp;

    private void OnValidate() {
        UpdateSize();
    }

    public void UpdateSize() {
        Vector2 backgroundSize;
        if (_matchVariant == MatchVariant.Horizontal) {
            backgroundSize = Vector2.one * _size * _canvasRectTransform.sizeDelta.x;
        } else {
            backgroundSize = Vector2.one * _size * _canvasRectTransform.sizeDelta.y;
        }
        _backgroundTransform.sizeDelta = backgroundSize;
        _stickTransform.sizeDelta = backgroundSize * _stickSize;
    }

    void Start() {
        UpdateSize();
        //_backgroundTransform.sizeDelta = Vector2.one * _size * Screen.width;
        Hide();
    }

    [SerializeField] private int _fingerId = -1;

    void Update() {

        if (_inputType == InputType.Touch) {
            TouchInput();
        } else if (_inputType == InputType.Mouse) {
            if (Input.GetMouseButtonDown(0)) {
                if (IsPointInsideRect(_activeAreaRect, Input.mousePosition)) {
                    OnDown(Input.mousePosition);
                }
            }
            if (IsPressed) {
                OnPressed(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0)) {
                OnUp(Input.mousePosition);
            }
        } else if (_inputType == InputType.Keyboard) {
            bool pressed = false;
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            if (x != 0 || y != 0) {
                Value = new Vector2(x,y);
                Debug.Log(Value);
                pressed = true;
            }
            if (IsPressed == false) {
                if (pressed) {
                    //IsPressed = true;
                    OnDown(Vector3.zero);
                }
            } else {
                if (pressed == false) {
                    //IsPressed = false;
                    OnUp(Vector3.zero);
                }
            }
            if (IsPressed) {
                //OnPressed(Vector3.zero);
            }
        }
    }

    public void TouchInput() {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                if (_fingerId == -1) {
                    if (IsPointInsideRect(_activeAreaRect, touch.position)) {
                        _fingerId = touch.fingerId;
                        OnDown(touch.position);
                        break;
                    }
                }
            } else if (touch.phase == TouchPhase.Ended) {
                if (touch.fingerId == _fingerId) {
                    _fingerId = -1;
                    OnUp(touch.position);
                }
            }
            if (touch.fingerId == _fingerId) {
                if (IsPressed) {
                    OnPressed(touch.position);
                }
            }
        }
    }

    bool IsPointInsideRect(RectTransform rectTransform, Vector2 point) {
        Vector2 pointToCheck = point;
        //Vector2 pointToCheck = _canvasRectTransform.InverseTransformPoint(point);

        if (pointToCheck.x < (rectTransform.position.x + rectTransform.rect.xMax)
            && pointToCheck.x > (rectTransform.position.x + rectTransform.rect.xMin)
            && pointToCheck.y < (rectTransform.position.y + rectTransform.rect.yMax)
            && pointToCheck.y > (rectTransform.position.y + rectTransform.rect.yMin)) {
            return true;
        } else {
            return false;
        }

    }

    public void OnDown(Vector2 touchPosition) {
        //Debug.Log("OnDown");
        IsPressed = true;
        Show();
        _backgroundTransform.position = touchPosition;
        EventOnDown.Invoke(touchPosition);
    }

    public void OnPressed(Vector2 touchPosition) {
        if (IsPressed == false) return;
        Vector2 toMouse = touchPosition - (Vector2)_backgroundTransform.position;
        float distance = toMouse.magnitude;
        float pixelSize = _size * Screen.width;
        float radius = pixelSize * 0.5f;
        float toMouseClamped = Mathf.Clamp(distance, 0, radius);
        Vector2 stickPosition = toMouse.normalized * toMouseClamped;
        Value = stickPosition / radius;
        _stickTransform.localPosition = stickPosition;
        EventOnPressed.Invoke(touchPosition);
    }

    public void OnUp(Vector2 touchPosition) {
        if (IsPressed == false) return;
        EventOnUp.Invoke(touchPosition);
        IsPressed = false;
        Hide();
        Value = Vector2.zero;
        
    }

    private void Show() {
        _backgroundTransform.gameObject.SetActive(true);
        _stickTransform.gameObject.SetActive(true);
    }

    private void Hide() {
        _backgroundTransform.gameObject.SetActive(false);
        _stickTransform.gameObject.SetActive(false);
    }

}
