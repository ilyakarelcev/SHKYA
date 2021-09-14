using UnityEngine;

public class TestMenu : MonoBehaviour {

    Vector3 _targetPosition;
    [SerializeField] private Transform _menuObject;
    bool _isShown;



    void Update() {
        _menuObject.position = Vector3.Lerp(_menuObject.position, _targetPosition, Time.deltaTime * 5f);
    }

    // Этот метод вызывается при нажатии кнопки
    public void Switch() {
        _isShown = !_isShown;
        if (_isShown) {
            Show();
        } else {
            Hide();
        }
    }

    void Show() {
        _targetPosition = new Vector3(0, 300f, 0);
    }

    void Hide() {
        _targetPosition = new Vector3(0, -200f, 0);
    }

}
