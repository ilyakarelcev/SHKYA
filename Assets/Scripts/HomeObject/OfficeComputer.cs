using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeComputer : HomeObject
{
  [SerializeField] private LevelChooser _levelChooser;

  [Header("OfficeComputer")] [TextArea] [SerializeField]
  private string _stringToSay;

  [TextArea] [SerializeField] private string _stringToSayWorkDone;
  public Office Office;

  public override void WhenReached()
  {
    if (Saves.LoadWorkIsDoneState())
      PlayerSay.Instance.Say(_stringToSayWorkDone, 3.5f);
    else
      StartCoroutine(GoFight());
  }

  private IEnumerator GoFight()
  {
    PlayerSay.Instance.Say(_stringToSay, 3.5f);
    FadeScreen.Instance.StartFade(1f);
    yield return new WaitForSeconds(1f);
    Saves.UpLevelIndex();
    _levelChooser.SelectNextLevel();
  }
}