using UnityEngine;

public abstract class HomeObject : MonoBehaviour
{
  public Transform PlayerTarget;
  [SerializeField] private PlayerAtHome _playerAtHome;

  private void OnMouseUpAsButton()
  {
    _playerAtHome.MoveToObject(this);
  }

  public virtual void WhenReached()
  {
  }
}