using UnityEngine;

public class BasicCloud : MonoBehaviour
{
  [SerializeField] private Vector3 _scale = new Vector3(.1f, .1f, .1f);

  // private void OnCollisionEnter2D(Collision2D collision)
  // {
  //   if (collision.gameObject.TryGetComponent(out PlayerHealth health))
  //     health.TakeDamage();
  // }

  // private void Start()
  // {
  //   var delay = Random.Range(3, 5);
  //   
  //   transform
  //     .DOScale(transform.localScale + _scale, delay)
  //     .SetLoops(-1, LoopType.Yoyo)
  //     .SetEase(Ease.Linear)
  //     .SetLink(gameObject);
  // }
}