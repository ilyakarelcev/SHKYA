using UnityEngine;

public class Office : MonoBehaviour
{
  [SerializeField] private OfficeClock OfficeClock;

  // ReSharper disable Unity.PerformanceAnalysis
  public void Show()
  {
    gameObject.SetActive(true);

    if (Application.isPlaying)
    {
      if (Saves.LoadWorkIsDoneState())
        OfficeClock.Show18();
      else
        OfficeClock.Show9();
    }
  }

  public void Hide() => gameObject.SetActive(false);
}