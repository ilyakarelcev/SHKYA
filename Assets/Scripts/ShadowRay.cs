using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ShadowRay : MonoBehaviour {

    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private Transform _shadowTransform;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private float _minAlpha;
    [SerializeField] private float _maxAlpha;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Update() {
        RaycastHit2D hit2D = Physics2D.Raycast(_rayOrigin.position, Vector2.down, 5f, _layerMask);
        if (hit2D) {
            _shadowTransform.position = hit2D.point;
            float distance = hit2D.distance;
            float interpolant = Mathf.InverseLerp(_minDistance, _maxDistance, distance);
            float alpha = Mathf.Lerp(_maxAlpha, _minAlpha, interpolant);
            _spriteRenderer.color = new Color(1, 1, 1, alpha);
        }

    }
}
