using UnityEngine;
using Random = UnityEngine.Random;

public class MissleTop : MonoBehaviour
{
  [SerializeField] private LayerMask _layer;
  [SerializeField] private Rigidbody2D _rigidbody;
  private float _minScale = .1f;
  private float _maxScale = .3f;

  private void Start()
  {
    SetGravityScale();
  }

  private void SetGravityScale()
  {
    var newScale = Random.Range(_minScale, _maxScale);

    _rigidbody.gravityScale = newScale;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerHealth health))
    {
      health.TakeDamage();
      Destroy(gameObject);
    }

    if (collider.TryGetComponent(out Deactivator deactivator))
      Destroy(gameObject);
  }
}