using UnityEngine;

public class OfficeClock : HomeObject
{
  public GameObject Time9;
  public GameObject Time18;

  private void Start()
  {
    if (Saves.LoadWorkIsDoneState())
      Show18();
    else
      Show9();
  }

  public void Show9()
  {
    Time9.SetActive(true);
    Time18.SetActive(false);
  }

  public void Show18()
  {
    Time9.SetActive(false);
    Time18.SetActive(true);
  }

  public override void WhenReached()
  {
    if (Saves.LoadWorkIsDoneState())
      PlayerSay.Instance.Say("Что я здесь делаю? \n рабочий день окончен", 3f);
    else
      PlayerSay.Instance.Say("День только начался, \n а я уже устал", 3f);
  }
}