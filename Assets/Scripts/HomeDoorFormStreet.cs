using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeDoorFormStreet : MonoBehaviour
{
  [SerializeField] private LevelChooser _levelChooser;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.attachedRigidbody)
    {
      Player player = collision.attachedRigidbody.GetComponent<Player>();
      if (player)
        StartCoroutine(GoHome());
    }
  }

  private IEnumerator GoHome()
  {
    FadeScreen.Instance.StartFade(1f);
    yield return new WaitForSeconds(1f);
    Saves.UpLevelIndex();
    _levelChooser.SelectNextLevel();
  }
}