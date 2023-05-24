using UnityEngine;

public class Level : MonoBehaviour
{
  public bool _isPlatformer;
  
  public void ChangeActiveState(bool state) => gameObject.SetActive(state);
}