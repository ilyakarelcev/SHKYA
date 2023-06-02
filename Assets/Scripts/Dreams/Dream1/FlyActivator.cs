using UnityEngine;

public class FlyActivator : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerMove playerMove))
    {
      collider.TryGetComponent(out PlayerFly fly);

      if (playerMove.enabled == true)
      {
        playerMove.DeactivateMoveState();
        fly.enabled = true;
        playerMove.enabled = false;
      }
      else
      {
        fly.DeactivateFlyMove();
        fly.enabled = false;
        playerMove.enabled = true;
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collider)
  {
    if (collider.TryGetComponent(out PlayerMove player))
      gameObject.SetActive(false);
  }
}