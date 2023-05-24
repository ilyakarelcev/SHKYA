using UnityEngine;

public class Jumper : MonoBehaviour
{
  [SerializeField] private Vector2 _force;
  
  private void OnTriggerEnter2D(Collider2D colider)
  {
    if (colider.TryGetComponent(out PlayerMove player))
      player.JumpOnJumper(_force);
  }
}