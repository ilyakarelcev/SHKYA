using UnityEngine;

public class Saves : MonoBehaviour
{
  private const string LastLevelIndex = "LastLevelIndex";
  private const string WorkDone = "WorkDone";
  private const string Coins = "Coins";

  public static int LoadLastLevelIndex() => ES3.Load(LastLevelIndex, 0);
  
  public static void UpLevelIndex()
  {
    ES3.Save(LastLevelIndex, ES3.Load(LastLevelIndex, 0) + 1);
  }

  public static bool LoadWorkIsDoneState()
  {
    bool state = ES3.Load(WorkDone, false);
    return state;
  }
  
  public static void SaveWorkState(bool state) => ES3.Save(WorkDone, state);
}