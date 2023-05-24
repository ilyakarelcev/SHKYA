using System.Collections;
using UnityEngine;

public class PlayerAtHome : MonoBehaviour
{
  private Coroutine _playingCoroutine;
  [SerializeField] private float _speed = 1f;
  [SerializeField] private Transform _playerBody;

  public void MoveToObject(HomeObject homeObject)
  {
    if (transform.position.x > homeObject.PlayerTarget.position.x)
      _playerBody.localScale = new Vector3(1f, 1f, 1f);
    else
      _playerBody.localScale = new Vector3(-1f, 1f, 1f);

    if (_playingCoroutine != null)
      StopCoroutine(_playingCoroutine);

    _playingCoroutine = StartCoroutine(MoveAnimation(homeObject));
  }

  public IEnumerator MoveAnimation(HomeObject homeObject)
  {
    Vector3 startPosition = transform.position;
    Quaternion startRotation = transform.rotation;

    float distance = Vector2.Distance(startPosition, homeObject.PlayerTarget.position);
    float time = distance / _speed;

    for (float t = 0; t < 1f; t += Time.deltaTime / time)
    {
      transform.rotation = Quaternion.Lerp(startRotation, homeObject.PlayerTarget.rotation, t);
      transform.position = Vector3.Lerp(startPosition, homeObject.PlayerTarget.position, t);
      yield return null;
    }

    transform.rotation = homeObject.PlayerTarget.rotation;
    transform.position = homeObject.PlayerTarget.position;

    homeObject.WhenReached();
  }
}