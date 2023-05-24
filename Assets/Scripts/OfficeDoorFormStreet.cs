using UnityEngine;

public class OfficeDoorFormStreet : MonoBehaviour
{
  [SerializeField] private LevelChooser _levelChooser;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.attachedRigidbody)
    {
      Player player = collision.attachedRigidbody.GetComponent<Player>();
      if (player)
      {
        Saves.UpLevelIndex();
        _levelChooser.SelectNextLevel();
      }
    }
  }
}