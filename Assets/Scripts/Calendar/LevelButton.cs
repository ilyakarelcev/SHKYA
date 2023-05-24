using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
  [SerializeField] private LevelChooser _levelChooser;
  
  public int LevelIndex;

  public Image RaycastImage;
  public Image IconImage;
  public TextMeshProUGUI LevelNameText;
  public Image StarImage;
  public Image SelectionImage;

  public Calendar Calendar;
  public Material DefaultMaterial;
  public Material SelectedMaterial;

  public void MarkInactive()
  {
    SetAlpha(0.3f);
    RaycastImage.raycastTarget = false;
    StarImage.enabled = false;
  }

  public void MarkAsPast()
  {
    SetAlpha(1f);
    RaycastImage.raycastTarget = true;
    StarImage.enabled = true;
  }

  public void MarkAsCurrent()
  {
    SetAlpha(1f);
    RaycastImage.raycastTarget = true;
    StarImage.enabled = false;
  }

  public void MarkAsSelected()
  {
    SelectionImage.enabled = true;
    LevelNameText.fontMaterial = SelectedMaterial;
  }

  public void MarkAsUnselected()
  {
    SelectionImage.enabled = false;
    LevelNameText.fontMaterial = DefaultMaterial;
  }

  public void SetAlpha(float value)
  {
    IconImage.color = new Color(1, 1, 1, value);
    Color textColor = LevelNameText.color;
    textColor.a = value;
    LevelNameText.color = textColor;
  }

  public void Setup(Calendar calendar, int index)
  {
    LevelIndex = index;
    Calendar = calendar;
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    //Debug.Log("OnPointerClick");
    print("click");
    _levelChooser.ChangeLevelIndex(LevelIndex);
    Calendar.SelectDay(LevelIndex);
  }
}