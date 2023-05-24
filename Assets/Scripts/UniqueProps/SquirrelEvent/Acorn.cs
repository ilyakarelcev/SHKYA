using System;
using UnityEngine;

public class Acorn : MonoBehaviour
{
  public event Action IsTaken;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    gameObject.SetActive(false);
    IsTaken?.Invoke();
  }
}