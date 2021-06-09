using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCameraMove : MonoBehaviour {

    [SerializeField] private Camera _camera;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private Vector3 _startPointerPosition;


    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            _startPointerPosition = GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0)) {
            Vector3 currentPointerPosition = GetMouseWorldPosition();
            Vector3 delta = currentPointerPosition - _startPointerPosition;
            float x = _camera.transform.position.x - delta.x;
            x = Mathf.Clamp(x, _minX, _maxX);
            _camera.transform.position = new Vector3(x, 0f, _camera.transform.position.z);
        }

    }

    Vector3 GetMouseWorldPosition() {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, 0f);
        plane.Raycast(ray, out float distance);
        Vector3 pointerPosition = ray.GetPoint(distance);
        return pointerPosition;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        float lineHeight = 6f;
        Gizmos.DrawLine(new Vector3(_minX, lineHeight, 0f), new Vector3(_minX, -lineHeight, 0f));
        Gizmos.DrawLine(new Vector3(_maxX, lineHeight, 0f), new Vector3(_maxX, -lineHeight, 0f));
    }

}
