using UnityEngine;
// #if UNITY_EDITOR
using UnityEditor;

// #endif

public class LevelManager : MonoBehaviour
{
  [SerializeField] private GameObject PlatformerObject;
  [SerializeField] private Level WorkLevel;
  [SerializeField] private Office Office;
  [SerializeField] private Home Home;
  [SerializeField] private Level[] _allLevels;
  [SerializeField] private Transform PlayerTransform;

  public static LevelManager Instance;
  public Calendar Calendar;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void Start()
  {
    //if (Progress.Instance.HalfDone) {
    //    ShowOffice();
    //} else {
    //    ShowHome(false);
    //}
    //Calendar.UpdateCalendar();
  }
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Home")]
// #endif
  // public void ShowHome(bool doSave)
  // {
  //   if (doSave)
  //   {
  //     Progress.Instance.Level += 1;
  //     Progress.Instance.Save();
  //   }
  //
  //
  //   HideAllLevels();
  //   Office.Hide();
  //   Home.Show();
  // }
  //
  //
  // public void ShowOfficeFromStreet()
  // {
  //   // // ���� �� ������ �������� ��������� ��������� �������
  //   // if (Calendar.DayIndex == Progress.Instance.Level)
  //   // {
  //   //   //Progress.Instance.HalfDone = true;
  //   //   Progress.Instance.Save();
  //   // }
  //   //
  //   // ShowOffice();
  // }
  //
  // public void ShowOfficeFromWork()
  // {
  //   // ����������
  //   //Progress.Instance.WorkDone = true;
  //   Progress.Instance.Save();
  //   ShowOffice();
  // }
  //
  // public void ShowOffice()
  // {
  //   HideAllLevels();
  //   Office.Show();
  //   Home.Hide();
  // }
  //
  // void HideAllLevels()
  // {
  //   foreach (var level in _allLevels)
  //   {
  //     level.Hide();
  //   }
  //
  //   WorkLevel.Hide();
  //   PlatformerObject.SetActive(false);
  // }
  //
  // public void ShowLevel(string levelName)
  // {
  //   for (int i = 0; i < _allLevels.Length; i++)
  //   {
  //     if (_allLevels[i].LevelName == levelName)
  //       ShowLevel(i);
  //   }
  // }
  //
  // public void ShowLevel(int levelIndex)
  // {
  //   HideAllLevels();
  //   Level level = _allLevels[levelIndex];
  //   level.Show();
  //   PlayerTransform.position = level.PlayerStartPoint.position;
  //
  //   PlatformerObject.SetActive(true);
  //   Home.Hide();
  //   Office.Hide();
  // }
  //
  //
  // public void ShowWork()
  // {
  //   HideAllLevels();
  //   WorkLevel.Show();
  //   PlayerTransform.position = WorkLevel.PlayerStartPoint.position;
  //   PlatformerObject.SetActive(true);
  //   Home.Hide();
  //   Office.Hide();
  // }

// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Home", false, 1000)]
// #endif
//   static void ShowHome_()
//   {
//     FindObjectOfType<LevelManager>().ShowHome(false);
//   }
//
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Office")]
// #endif
//   static void ShowOffice_()
//   {
//     FindObjectOfType<LevelManager>().ShowOffice();
//   }
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Work")]
// #endif
//   static void ShowWork_()
//   {
//     FindObjectOfType<LevelManager>().ShowWork();
//   }
//
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Level_1")]
// #endif
//   static void ShowLevel_1()
//   {
//     FindObjectOfType<LevelManager>().ShowLevel("Level_1");
//   }
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Level_1_Back")]
// #endif
//   static void ShowLevel_1_Back()
//   {
//     FindObjectOfType<LevelManager>().ShowLevel("Level_1_Back");
//   }
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Level_X")]
// #endif
//   static void ShowLevel_X()
//   {
//     FindObjectOfType<LevelManager>().ShowLevel("Level_X");
//   }
// #if UNITY_EDITOR
//   [MenuItem("LevelManager/Level_X_Back")]
// #endif
//   static void ShowLevel_X_Back()
//   {
//     FindObjectOfType<LevelManager>().ShowLevel("Level_X_Back");
//   }
}