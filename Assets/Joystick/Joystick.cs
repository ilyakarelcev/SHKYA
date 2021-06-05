using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatchVariant {
    Horizontal,
    Vertical
}

public class Joystick : MonoBehaviour {

    [SerializeField] private RectTransform _backgroundTransform;
    [SerializeField] private RectTransform _stickTransform;
    [Range(0, 1)]
    [SerializeField] private float _size;
    [Range(0, 1)]
    [SerializeField] private float _stickSize;

    public Vector2 Value { get; private set; }
    public bool IsPressed { get; private set; }

    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private MatchVariant _matchVariant;

    [SerializeField] private float _xMin = 0f;
    [SerializeField] private float _xMax = 0.5f;

    [SerializeField] private RectTransform ActiveAreaRect;

    private void OnValidate() {

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
        _backgroundTransform.sizeDelta = Vector2.one * _size * Screen.width;
        Hide();
    }

    //private bool _began;
    [SerializeField] private int _fingerId = -1;

    void Update() {
        //if (_began == false) {

        foreach (Touch touch in Input.touches) {

            if (touch.phase == TouchPhase.Began) {
                if (_fingerId == -1) {
                    float relativeXPosition = touch.position.x / Screen.width;
                    Debug.Log(relativeXPosition);
                    Debug.Log(Time.time);
                    if (IsPointInsideRect(ActiveAreaRect, touch.position)) {
                        Debug.Log("inside");
                        _fingerId = touch.fingerId;
                        OnDown(touch.position);
                        break;
                    }
                }

            } else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
                if (touch.fingerId == _fingerId) {
                    OnPressed(touch.position);
                }
            } else if (touch.phase == TouchPhase.Ended) {
                if (touch.fingerId == _fingerId) {
                    _fingerId = -1;
                    OnUp(touch.position);
                }
            }

        }

        //}

        /*
        if (Input.GetMouseButtonDown(0)) {
            OnDown();
        }

        if (Input.GetMouseButton(0)) {
            OnUp();
        }

        if (Input.GetMouseButtonUp(0)) {
            OnPressed();
        }
        */
    }

    bool IsPointInsideRect(RectTransform rect, Vector2 point) {
        if (point.x < (rect.position.x + rect.rect.xMax)
            && point.x > (rect.position.x + rect.rect.xMin)
            && point.y < (rect.position.y + rect.rect.yMax)
            && point.y > (rect.position.y + rect.rect.yMin)) {
            return true;
        } else {
            return false;
        }
            
    }

    public void OnDown(Vector2 touchPosition) {
        IsPressed = true;
        Show();
        _backgroundTransform.position = touchPosition;
    }

    public void OnPressed(Vector2 touchPosition) {
        Vector2 toMouse = touchPosition - (Vector2)_backgroundTransform.position;
        float distance = toMouse.magnitude;
        float pixelSize = _size * Screen.width;
        float radius = pixelSize * 0.5f;
        float toMouseClamped = Mathf.Clamp(distance, 0, radius);
        Vector2 stickPosition = toMouse.normalized * toMouseClamped;
        Value = stickPosition / radius;
        _stickTransform.localPosition = stickPosition;
    }

    public void OnUp(Vector2 touchPosition) {
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
