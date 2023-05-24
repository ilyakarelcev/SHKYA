using System.Collections;
using UnityEngine;

public class OfficeDoor : HomeObject
{
  [SerializeField] private LevelChooser _levelChooser;
  
  [TextArea] [SerializeField] private string _stringToSay;
  public Office Office;
  public Calendar Calendar;

  public override void WhenReached()
  {
    if (Saves.LoadWorkIsDoneState())
      StartCoroutine(GoOut());
    else
      PlayerSay.Instance.Say(_stringToSay, 3.5f);
  }

  private IEnumerator GoOut()
  {
    FadeScreen.Instance.StartFade(1f);
    yield return new WaitForSeconds(1f);
    _levelChooser.SelectNextLevel();
    Saves.SaveWorkState(false);
  }
}