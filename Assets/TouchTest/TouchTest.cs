using UnityEngine;
using UnityEngine.EventSystems;

public class TouchTest : MonoBehaviour
{
  public static bool CheckOverGameObject()
  {
    if (EventSystem.current.IsPointerOverGameObject())
      return true;

    for (int i = 0; i < Input.touchCount; i++)
    {
      int id = Input.GetTouch(i).fingerId;
      
      if (EventSystem.current.IsPointerOverGameObject(id))
        return true;
    }

    return false;
  }
}