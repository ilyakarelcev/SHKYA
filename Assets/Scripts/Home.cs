using UnityEngine;

public class Home : MonoBehaviour
{
  public Calendar Calendar;

  public void Show()
  {
    gameObject.SetActive(true);
    Calendar.UpdateCalendar();
  }

  public void Hide()
  {
    gameObject.SetActive(false);
  }
}