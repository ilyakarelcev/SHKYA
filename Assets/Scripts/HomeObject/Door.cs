public class Door : HomeObject
{
  public Calendar Calendar;

  public override void WhenReached() => Calendar.Show();
}