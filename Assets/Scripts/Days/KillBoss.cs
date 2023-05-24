using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBoss : MonoBehaviour
{
  public void CompleteBoss()
  {
    Saves.UpLevelIndex();
    Saves.SaveWorkState(true);
    SceneManager.LoadScene("Office");
  }
}